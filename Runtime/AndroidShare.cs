using PluginSet.Core;
using UnityEngine;

#if UNITY_ANDROID
namespace PluginSet.Platform
{
    public static class AndroidShare
    {
        private static AndroidJavaClass _share;

        private static AndroidJavaClass Share
        {
            get
            {
                if (_share == null)
                    _share = new AndroidJavaClass("com.pluginset.platform.Share");

                return _share;
            }
        }

        public static void ShareText(string content, string title)
        {
            Share.CallStatic("ShareText", AndroidHelper.CurrentActivity, content, title);
        }
        
        public static void ShareImage(string imagePath, string title, string desc)
        {
            Share.CallStatic("ShareImage", AndroidHelper.CurrentActivity, imagePath, title, desc);
        }

        public static void ShareMusic(string musicPath, string title, string desc)
        {
            Share.CallStatic("ShareMusic", AndroidHelper.CurrentActivity, musicPath, title, desc);
        }
        
        public static void ShareVideo(string videoPath, string title, string desc)
        {
            Share.CallStatic("ShareVideo", AndroidHelper.CurrentActivity, videoPath, title, desc);
        }
        
        public static void ShareWebPage(string webUrl, string title, string desc)
        {
            Share.CallStatic("ShareWebPage", AndroidHelper.CurrentActivity, webUrl, title, desc);
        }
    }
}
#endif