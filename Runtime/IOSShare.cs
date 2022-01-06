using PluginSet.Core;
using UnityEngine;
using System.Runtime.InteropServices;
#if UNITY_IOS
#if !UNITY_EDITOR
namespace PluginSet.Platform
{
    public static class IOSShare
    {
        [DllImport("__Internal")]
        public static extern void SysShareText(string content, string title);

        [DllImport("__Internal")]
        public static extern void SysShareImage(string imagePath, string title, string desc);
        public static void ShareText(string content, string title)
        {
            SysShareText(content, title);
        }

        public static void ShareImage(string imagePath, string title, string desc)
        {
            SysShareImage(imagePath, title, desc);
        }
    }
}
#endif
#endif