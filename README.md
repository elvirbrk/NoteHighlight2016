# NoteHighlight2016
![Alt text](/img/menu.png?raw=true "Menu")

[![GitHub release](https://img.shields.io/github/release/elvirbrk/NoteHighlight2016.svg)](https://github.com/elvirbrk/NoteHighlight2016/releases/tag/v3.7)[![Github Releases](https://img.shields.io/github/downloads/elvirbrk/NoteHighlight2016/latest/total.svg)](https://github.com/elvirbrk/NoteHighlight2016/releases/tag/v3.7)
[![Github previous](https://img.shields.io/github/downloads/elvirbrk/NoteHighlight2016/v3.6/total.svg)](https://github.com/elvirbrk/NoteHighlight2016/releases/tag/v3.6)
[![Github All Releases](https://img.shields.io/github/downloads/elvirbrk/NoteHighlight2016/total.svg)](https://github.com/elvirbrk/NoteHighlight2016/releases)

[![Follow @NoteHighlight](https://img.shields.io/twitter/follow/NoteHighlight.svg?style=social&label=Follow%20@NoteHighlight)](https://twitter.com/NoteHighlight?ref_src=twsrc%5Etfw)<br >
Follow on Twitter for updates and general questions. For bug reports and feature requests please use [Issues](https://github.com/elvirbrk/NoteHighlight2016/issues) page.

Based on NoteHighlight 2013 (https://notehighlight2013.codeplex.com) and VanillaAddin (https://github.com/OneNoteDev/VanillaAddIn) to create working addin for OneNote 2016 and OneNote for O365 (32-bit and 64-bit) 

Syntax highlighting performed using https://gitlab.com/saalen/highlight

# Install
To install just run MSI file from [releases](https://github.com/elvirbrk/NoteHighlight2016/releases). For Office 64-bit use NoteHighlight2016.msi, and for Office 32-bit use NoteHighlight2016x86.msi.
See [here](https://support.office.com/en-us/article/About-Office-What-version-of-Office-am-I-using-932788B8-A3CE-44BF-BB09-E334518B8B19?ui=en-US&rs=en-US&ad=US) how to check which Office version you have.

In case AddIn doesn't show after install, check if this helps [Not showing after install](https://github.com/elvirbrk/NoteHighlight2016/issues/7)

# Usage
## Add new code
1. Select language from menu
2. Enter source code in pop-up window and press OK
3. Highlighted source code will show up in page

![Alt text](/img/usage.png?raw=true "Usage")

## Format existing text or edit formatted text
1. Select text that you want to format or edit (you can select whole or only part of note). In case part on note is already formatted, you can select whole source code box.
2. From NoteHighlight menu select desired language
3. NoteHighlight form will open with selected text
4. Edit text or change formatting same as for new code

# Additional languages
1. Go to installation folder and find file ribbon.xml and open it with text editor <br />
Default installation folder: C:\Program Files (x86)\CodingRoad\NoteHighlight2016\ or C:\Program Files\CodingRoad\NoteHighlight2016\
2. Edit property "visible" from "false" to "true" for languages that you want to use. It is necessary to restart OneNote for changes to take effect

It is also possible to add new languages (supported by highlight tool) by adding new rows to ribbon.xml but if you need new language then you are smart enough to figure it out :)

# Sample of Themes
samples directory [Theme Samples](./img/Theme%20Samples/ThemeSample.md)