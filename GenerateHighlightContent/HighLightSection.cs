using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GenerateHighlightContent
{
    public class HighLightSection : ConfigurationSection
    {
        public override bool IsReadOnly()
        {
            return true;
        }

        [ConfigurationProperty("FolderName", DefaultValue = "highlight")]
        public string FolderName { get { return base["FolderName"].ToString(); } }

        [ConfigurationProperty("ProcessName", DefaultValue = "highlight.exe")]
        public string ProcessName { get { return base["ProcessName"].ToString(); } }

        [ConfigurationProperty("GeneralArguments", IsRequired = true, IsDefaultCollection = true)]
        public GeneralArgumentsCollection GeneralArguments
        {
            get
            {
                return (GeneralArgumentsCollection)base["GeneralArguments"];
            }
        }

        [ConfigurationProperty("OutputArguments", IsRequired = true, IsDefaultCollection = true)]
        public OutputArgumentsCollection OutputArguments
        {
            get
            {
                return (OutputArgumentsCollection)base["OutputArguments"];
            }
        }
    }

    public abstract class HighLightElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public Argument this[int index]
        {
            get { return (Argument)BaseGet(index); }
        }

        public Argument this[string key]
        {
            get { return (Argument)BaseGet(key); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Argument();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Argument)element).Name;
        }
    }

    public class GeneralArgumentsCollection : HighLightElementCollection { }

    public class OutputArgumentsCollection : HighLightElementCollection { }

    public class Argument : ConfigurationElement
    {
        public override bool IsReadOnly()
        {
            return true;
        }

        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name { get { return base["Name"].ToString(); } }

        [ConfigurationProperty("Key", IsRequired = true)]
        public string Key { get { return base["Key"].ToString(); } }

        [ConfigurationProperty("Value", IsRequired = true)]
        public string Value { get { return base["Value"].ToString(); } }

        [ConfigurationProperty("Option", DefaultValue = false)]
        public bool Option { get { return Convert.ToBoolean(base["Option"]); } }
    }
}
