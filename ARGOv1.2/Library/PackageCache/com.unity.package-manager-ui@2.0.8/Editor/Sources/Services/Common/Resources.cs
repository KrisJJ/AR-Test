<<<<<<< HEAD
﻿using UnityEngine.Experimental.UIElements;

namespace UnityEditor.PackageManager.UI
{
    internal static class Resources
    {
        private static string TemplateRoot { get { return PackageManagerWindow.ResourcesPath + "Templates"; } }

        private static string TemplatePath(string filename)
        {
            return string.Format("{0}/{1}", TemplateRoot, filename);
        }

        public static VisualElement GetTemplate(string templateFilename)
        {
            return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(TemplatePath(templateFilename)).CloneTree(null);
        }
    }
=======
﻿using UnityEngine.Experimental.UIElements;

namespace UnityEditor.PackageManager.UI
{
    internal static class Resources
    {
        private static string TemplateRoot { get { return PackageManagerWindow.ResourcesPath + "Templates"; } }

        private static string TemplatePath(string filename)
        {
            return string.Format("{0}/{1}", TemplateRoot, filename);
        }

        public static VisualElement GetTemplate(string templateFilename)
        {
            return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(TemplatePath(templateFilename)).CloneTree(null);
        }
    }
>>>>>>> 7e9cc7564d17352c33f6ea8482525655190ffcea
}