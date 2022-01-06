using System;
using PluginSet.Core;

namespace PluginSet.Platform
{
    public partial class PluginPlatform
#if!UNITY_EDITOR
        : IShareTextPlugin, IShareImagePlugin
#if UNITY_ANDROID
        , IShareMusicPlugin, IShareVideoPlugin, IShareWebPagePlugin
#endif
#endif
    {
#if !UNITY_EDITOR
        public bool IsEnableShare => true;
#else
        public bool IsEnableShare => false;
#endif

        private bool _shareSuccessCall = false;

        private void InitShare(PluginPlatformConfig config)
        {
            _shareSuccessCall = config.ShareSuccessBack;
        }

        public void ShareText(string text, Action success = null, Action fail = null, string title = null, string image = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidShare.ShareText(text, title);
            DefaultShareBack(success, fail);
#elif UNITY_IOS && !UNITY_EDITOR
            IOSShare.ShareText(text, title);
            DefaultShareBack(success, fail);
#endif
        }

        public void ShareImage(string imagePath, Action success = null, Action fail = null, string title = null, string desc = null,
            string image = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidShare.ShareImage(imagePath, title, desc);
            DefaultShareBack(success, fail);
#elif UNITY_IOS && !UNITY_EDITOR
            IOSShare.ShareImage(imagePath, title, desc);
            DefaultShareBack(success, fail);
#else
#endif
        }

        public void ShareMusic(string musicFile, Action success = null, Action fail = null, string title = null, string desc = null,
            string image = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidShare.ShareMusic(musicFile, title, desc);
            DefaultShareBack(success, fail);
#else
            throw new NotImplementedException();
#endif
        }

        public void ShareVideo(string videoFile, Action success = null, Action fail = null, string extra = null, string title = null,
            string desc = null, string image = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidShare.ShareVideo(videoFile, title, desc);
            DefaultShareBack(success, fail);
#else
            throw new NotImplementedException();
#endif
        }

        public void ShareWebPage(string webUrl, Action success = null, Action fail = null, string title = null, string desc = null,
            string image = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidShare.ShareWebPage(webUrl, title, desc);
            DefaultShareBack(success, fail);
#else
            throw new NotImplementedException();
#endif
        }

        private void DefaultShareBack(Action success, Action fail)
        {
            var callback = _shareSuccessCall ? success: fail;
            callback?.Invoke();
        }
        
    }
}