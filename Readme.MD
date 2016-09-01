For the README of the console app sample, see: [Readme-console.MD](Readme-console.MD)

README: OneNote COM Vanilla AddIn

===================
1 - Overview
===================

The VanillaAddIn is a sample template that a developer can use to bootstrap her own OneNote COM Add-In project.

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

An installer component is also included and requires Visual Studio 2010 to build natively. If you do want 
to use Visual Studio 2015 or above to build this project, then you can install the Visual Studio Installer
Project Extension available here 
for VS2013: https://visualstudiogallery.msdn.microsoft.com/9abe329c-9bba-44a1-be59-0fbf6151054d

for VS2015: https://visualstudiogallery.msdn.microsoft.com/f1cc3f3e-c300-40a7-8797-c509fb8933b9

==================
3 - Building
==================
Open Visual Studio as an administrator. This is required because the build modifies the GAC on your machine.

Provided that you have all of the indicated dependencies, then you should be able to build this project directly
from the VS interface.

If you get a build break where Microsoft.Office.Core cannot be detected, you may need to modify the csproj manually. 
It depends on what Office version you have installed. Try swapping:
     "VersionMinor" to either "7" or "8"
     and/or
     "WrapperTool" to either "tlbimp" or "primary"
      <VersionMinor>8</VersionMinor>
      <WrapperTool>tlbimp</WrapperTool>

==================
4 - Installation
==================
To install the addin to OneNote, simply right click the installer project in Visual Studio, build, and click Install. 
This should set up everything automatically for you.
After installation, make sure that the toolbar is enabled in OneNote. Go to File>Settings>Add Ins and make sure that 
the project, is flagged as Active. 

==================
5 - Debugging
==================
After the project has been installed, run OneNote. To start debugging you need to attach to the process 'dllhost.exe'

Do NOT attach to OneNote, it won't work!

If you want to debug on an x86 OneNote, build x86 Platform, and run the Setup.
If you want to debug on an x64 OneNote, build x64 Platform, and run the Setupx64.

==================
6 - Releasing
==================
After the first release, ensure that you increment the version number of the vdproj files (and product GUID) for each subsequent release.
This ensures that when the msi is run, it will not ask the user to uninstall the older version.

==================
7 - Known Issues
==================
There is an issue that can occur whereby the addin will stop installing. To remedy this make sure that all of the project's
interop dlls reference points are set to %systemroot%\assemblies\GAC_MSIL and that they have Embed Interop Types set to false.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
