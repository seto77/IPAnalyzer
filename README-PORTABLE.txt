IPAnalyzer portable ZIP package (260602Cl)
==========================================

The MSI installer is the recommended installation method for IPAnalyzer.
This portable ZIP package is provided as an alternative for managed Windows
PCs where MSI installation, administrator approval, or separate .NET Desktop
Runtime installation is difficult. In this document, "portable" means
"no installer required"; IPAnalyzer still uses the current user's AppData
folder for settings and copied default data. (260602Cl)

How to run
----------

1. Extract the ZIP file to a user-writable folder.
   Example: Documents\IPAnalyzer or Desktop\IPAnalyzer

2. Run IPAnalyzer.exe from the extracted IPAnalyzer folder.

3. Do not run IPAnalyzer.exe directly from inside the ZIP viewer.
   Extract the full folder first so that the bundled DLLs, database files,
   localization files, and documents remain next to IPAnalyzer.exe.

Runtime
-------

This portable package is self-contained for Windows x64. A separate .NET
Desktop Runtime 10 installation is not required; the required .NET runtime
files are bundled in this folder. When Microsoft releases .NET runtime
security updates, this package should be rebuilt and redistributed so that
the bundled runtime is also updated. (260602Cl)

Notes for managed PCs
---------------------

- Administrator privileges are not required by IPAnalyzer itself.
- IPAnalyzer stores user settings and copied default data under the current
  user's application data folder.
- IPAnalyzer may also store per-user options under HKCU
  (HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer).
- Windows Defender SmartScreen or institutional security software may still
  warn about newly downloaded unsigned research software. Download IPAnalyzer
  only from the official GitHub Releases page:
  https://github.com/seto77/IPAnalyzer/releases/latest

Verification
------------

If SHA256SUMS.txt is provided with the release, you can verify the downloaded
ZIP file in PowerShell:

  Get-FileHash .\IPAnalyzer-*-win-x64-portable.zip -Algorithm SHA256
