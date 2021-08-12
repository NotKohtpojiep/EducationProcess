using System.Diagnostics;
using System.Reflection;

namespace EducationProcess.HandyDesktop.Tools
{
    internal class VersionHelper
    {
        internal static string GetVersion()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

#if NET5_0
            var netVersion = "NET 5.0";
#endif
            return $"v {versionInfo.FileVersion} {netVersion}";
        }

        internal static string GetCopyright() =>
            FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright;
    }
}
