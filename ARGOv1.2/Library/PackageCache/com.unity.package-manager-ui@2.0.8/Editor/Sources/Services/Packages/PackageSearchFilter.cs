<<<<<<< HEAD
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class PackageSearchFilter
    {
        private static PackageSearchFilter instance = new PackageSearchFilter();
        public static PackageSearchFilter Instance { get { return instance; } }

        public string SearchText { get; set; }
        
        public static void InitInstance(ref PackageSearchFilter value)
        {
            if (value == null)  // UI window opened
                value = instance;
            else // Domain reload
                instance = value;
        }

        public void ResetSearch()
        {
            SearchText = string.Empty;
        }
    }
=======
﻿using System;

namespace UnityEditor.PackageManager.UI
{
    [Serializable]
    internal class PackageSearchFilter
    {
        private static PackageSearchFilter instance = new PackageSearchFilter();
        public static PackageSearchFilter Instance { get { return instance; } }

        public string SearchText { get; set; }
        
        public static void InitInstance(ref PackageSearchFilter value)
        {
            if (value == null)  // UI window opened
                value = instance;
            else // Domain reload
                instance = value;
        }

        public void ResetSearch()
        {
            SearchText = string.Empty;
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}