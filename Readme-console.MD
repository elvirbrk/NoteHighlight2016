README: OneNote Console API sample
===================
1 - Overview
===================
The VanillaConsole is a sample console app that a developer can use to bootstrap her own app to automate OneNote.

In order to replace properly use this in your own project, you should:
* replace add-in GUID in vdproj - D5ECCD00-CF2D-409B-B65A-BDBACB9F21DB with a new GUID
* replace Guid in AddIn.cs - D5ECCD00-CF2D-409B-B65A-BDBACB9F21DB
* replace add-in progid in vdproj "MyApplication.VanillaAddIn" with a new ProgId
* replace ProgId in AddIn.cs
* replace all "VanillaAddIn" strings
* replace ProductCode, PackageCode, and UpgradeCode in .vdproj
* replace Guid in [assembly: Guid("45FCCCEB-10CB-4C29-B8D2-1C8033139534")]
* update license.rtf

===================
2 - Dependencies
===================
The project is written in C# and requires .NET 4.5 or above. 

==================
3 - Building
==================
Open Visual Studio and build.

==================
4 - Debugging
==================
Set VanillaConsole as the Startup Project, and run it.

5 - Known Issues
==================
There is an issue that can occur whereby the addin will stop installing. To remedy this make sure that all of the project's
interop dlls reference points are set to %systemroot%\assemblies\GAC_MSIL and that they have Embed Interop Types set to false.
