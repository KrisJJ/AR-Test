<<<<<<< HEAD
﻿using System.Linq;
using UnityEngine;

namespace UnityEditor.PackageManager.UI
{
    class ApplicationUtil
    {
        public static bool IsPreReleaseVersion
        {
            get
            {
                var lastToken = Application.unityVersion.Split('.').LastOrDefault();
                return lastToken.Contains("a") || lastToken.Contains("b");
            }
        }
    }
=======
﻿using System.Linq;
using UnityEngine;

namespace UnityEditor.PackageManager.UI
{
    class ApplicationUtil
    {
        public static bool IsPreReleaseVersion
        {
            get
            {
                var lastToken = Application.unityVersion.Split('.').LastOrDefault();
                return lastToken.Contains("a") || lastToken.Contains("b");
            }
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}