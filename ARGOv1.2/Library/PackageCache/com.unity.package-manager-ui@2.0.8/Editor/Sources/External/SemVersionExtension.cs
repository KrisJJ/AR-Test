<<<<<<< HEAD
﻿namespace Semver
{
    internal static class SemVersionExtension
    {
        public static string VersionOnly(this SemVersion version)
        {
            return "" + version.Major + "." + version.Minor + "." + version.Patch;
        }
        
        public static string ShortVersion(this SemVersion version)
        {
            return version.Major + "." + version.Minor;
        }                
    }
=======
﻿namespace Semver
{
    internal static class SemVersionExtension
    {
        public static string VersionOnly(this SemVersion version)
        {
            return "" + version.Major + "." + version.Minor + "." + version.Patch;
        }
        
        public static string ShortVersion(this SemVersion version)
        {
            return version.Major + "." + version.Minor;
        }                
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}