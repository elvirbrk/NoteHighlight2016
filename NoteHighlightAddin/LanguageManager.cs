using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NoteHighlightAddin
{
    public class LanguageManager
    {
        private readonly string _ribbonXmlPath;
        private readonly string _langDefPath;

        public LanguageManager(string ribbonXmlPath, string langDefPath)
        {
            _ribbonXmlPath = ribbonXmlPath;
            _langDefPath = langDefPath;
        }

        /// <summary>
        /// Gets all available languages from the langDef folder
        /// </summary>
        public List<LanguageInfo> GetAvailableLanguages()
        {
            var languages = new List<LanguageInfo>();

            try
            {
                if (Directory.Exists(_langDefPath))
                {
                    var files = Directory.GetFiles(_langDefPath, "*.lang");
                    foreach (var file in files)
                    {
                        var filename = Path.GetFileNameWithoutExtension(file);
                        languages.Add(new LanguageInfo 
                        { 
                            Tag = filename, 
                            Label = ConvertTagToLabel(filename),
                            FilePath = file
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error reading language definitions: {ex.Message}");
            }

            return languages.OrderBy(l => l.Label).ToList();
        }

        /// <summary>
        /// Gets currently visible languages from ribbon.xml
        /// </summary>
        public List<LanguageInfo> GetVisibleLanguages()
        {
            var languages = new List<LanguageInfo>();

            try
            {
                if (!File.Exists(_ribbonXmlPath))
                    return languages;

                var doc = XDocument.Load(_ribbonXmlPath);
                var ns = XNamespace.Get("http://schemas.microsoft.com/office/2006/01/customui");

                var buttons = doc.Descendants(ns + "button")
                    .Where(b => b.Attribute("visible")?.Value == "true" || 
                               (b.Attribute("visible") == null && b.Parent?.Name?.LocalName == "group" && 
                                b.Parent.Attribute("label")?.Value == "Language"))
                    .ToList();

                foreach (var button in buttons)
                {
                    var id = button.Attribute("id")?.Value;
                    var label = button.Attribute("label")?.Value;
                    var tag = button.Attribute("tag")?.Value;

                    if (!string.IsNullOrEmpty(tag))
                    {
                        languages.Add(new LanguageInfo 
                        { 
                            Id = id,
                            Label = label ?? tag, 
                            Tag = tag 
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error reading ribbon.xml: {ex.Message}");
            }

            return languages;
        }

        /// <summary>
        /// Adds a new language button to ribbon.xml
        /// </summary>
        public bool AddLanguage(string tag, string label)
        {
            try
            {
                if (!File.Exists(_ribbonXmlPath))
                    return false;

                var doc = XDocument.Load(_ribbonXmlPath);
                var ns = XNamespace.Get("http://schemas.microsoft.com/office/2006/01/customui");

                // Find the Language group
                var languageGroup = doc.Descendants(ns + "group")
                    .FirstOrDefault(g => g.Attribute("label")?.Value == "Language");

                if (languageGroup == null)
                    return false;

                // Check if language already exists
                var existingButton = languageGroup.Descendants(ns + "button")
                    .FirstOrDefault(b => b.Attribute("tag")?.Value == tag);

                if (existingButton != null)
                {
                    // Set visible to true if it exists but was hidden
                    existingButton.SetAttributeValue("visible", "true");
                }
                else
                {
                    // Create new button element
                    var buttonId = $"button{tag.ToUpper().Replace("#", "Sharp").Replace("+", "Plus")}";
                    var screentip = $"Enter {label} Code";

                    var newButton = new XElement(ns + "button",
                        new XAttribute("id", buttonId),
                        new XAttribute("label", label),
                        new XAttribute("size", "large"),
                        new XAttribute("screentip", screentip),
                        new XAttribute("onAction", "AddInButtonClicked"),
                        new XAttribute("tag", tag),
                        new XAttribute("image", "Other.png"),
                        new XAttribute("visible", "true"));

                    languageGroup.Add(newButton);
                }

                doc.Save(_ribbonXmlPath);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error adding language: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Removes a language button from ribbon.xml (sets visible to false)
        /// </summary>
        public bool RemoveLanguage(string tag)
        {
            try
            {
                if (!File.Exists(_ribbonXmlPath))
                    return false;

                var doc = XDocument.Load(_ribbonXmlPath);
                var ns = XNamespace.Get("http://schemas.microsoft.com/office/2006/01/customui");

                var button = doc.Descendants(ns + "button")
                    .FirstOrDefault(b => b.Attribute("tag")?.Value == tag);

                if (button != null)
                {
                    button.SetAttributeValue("visible", "false");
                    doc.Save(_ribbonXmlPath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error removing language: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Converts a tag to a friendly label (e.g., "csharp" -> "C#", "cpp" -> "C++")
        /// </summary>
        private string ConvertTagToLabel(string tag)
        {
            var labelMap = new Dictionary<string, string>
            {
                { "cs", "C#" },
                { "csharp", "C#" },
                { "java", "Java" },
                { "js", "JavaScript" },
                { "ts", "TypeScript" },
                { "py", "Python" },
                { "php", "PHP" },
                { "rb", "Ruby" },
                { "ruby", "Ruby" },
                { "cpp", "C++" },
                { "c", "C" },
                { "sql", "SQL" },
                { "html", "HTML" },
                { "xml", "XML" },
                { "css", "CSS" },
                { "json", "JSON" },
                { "sh", "Bash" },
                { "bat", "Batch" },
                { "ps1", "PowerShell" },
                { "fsharp", "F#" },
                { "go", "Go" },
                { "rs", "Rust" },
                { "swift", "Swift" },
                { "kt", "Kotlin" },
                { "scala", "Scala" },
                { "r", "R" },
                { "perl", "Perl" },
                { "lua", "Lua" },
                { "md", "Markdown" },
                { "yaml", "YAML" },
                { "toml", "TOML" }
            };

            if (labelMap.ContainsKey(tag.ToLower()))
                return labelMap[tag.ToLower()];

            // Capitalize first letter and space before capitals
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tag);
        }
    }

    public class LanguageInfo
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Tag { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
