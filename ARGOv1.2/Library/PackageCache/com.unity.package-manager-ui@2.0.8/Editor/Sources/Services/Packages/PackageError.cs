<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class PackageError
    {
        public string PackageName;
        public Error Error;

        public PackageError(string packageName, Error error)
        {
            PackageName = packageName;
            Error = error;
        }
    }
}
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class PackageError
    {
        public string PackageName;
        public Error Error;

        public PackageError(string packageName, Error error)
        {
            PackageName = packageName;
            Error = error;
        }
    }
}
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
