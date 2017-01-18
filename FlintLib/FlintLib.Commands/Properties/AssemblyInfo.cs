using System.Reflection;
using System.Runtime.InteropServices;

using FlintLib.Common;

[assembly: AssemblyTitle("FlintLib.Commands")]
[assembly: AssemblyDescription(ProductInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("FlintLib.Commands")]
[assembly: AssemblyCopyright(ProductInfo.Copyright)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("1501a789-a607-4905-93de-b4df51423d0c")]

/* =====================================================================================
 * Version information for an assembly consists of the following four values:
 * 
 *     Major Version
 *     Minor Version
 *     Build Number
 *     Revision
 *     
 * The major version number is supplied by FlintLib.Common.ProductInfo. It only gets 
 * incremented on major rewrites and changes, such that referencing code would need
 * major rewrites itself in order to be compatible. It also indicates major changes
 * that affect all parts of FlintLib.
 * 
 * The minor version should be incremented whenever an interface change will require
 * referencing code to be updated in order to work properly. This can accommodate minor
 * changes to existing interfaces, and also additions that will not necessarily "break"
 * referencing code.
 * 
 * The build number should match the sprint number at the conclusion of which there was
 * a release.
 * 
 * The revision is marked as '*' and as such is managed by Visual Studio.
 ===================================================================================== */
[assembly: AssemblyVersion(ProductInfo.VersionMajor + ".0.1.*")]
