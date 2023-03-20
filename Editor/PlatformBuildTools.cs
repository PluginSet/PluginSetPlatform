
using System.Collections.Generic;
using PluginSet.Core;
using PluginSet.Core.Editor;
using UnityEditor;

namespace PluginSet.Platform.Editor
{
    [BuildTools]
    public static class PlatformBuildTools
    {
        [OnSyncEditorSetting]
        public static void OnSyncEditorSetting(BuildProcessorContext context)
        {
            Global.CopyDependenciesInLib("com.pluginset.platform");
            context.AddLinkAssembly("PluginSet.Platform");
            
            var asset = context.BuildChannels;
            var buildParams = asset.Get<PlatformBuildParams>();

            var pluginConfig = context.Get<PluginSetConfig>("pluginsConfig");
            var config = pluginConfig.AddConfig<PluginPlatformConfig>("Platform");
            config.ShareSuccessBack = buildParams.ShareSuccessBack;
        }

        [AndroidProjectModify]
        public static void AndroidProjectModify(BuildProcessorContext context, AndroidProjectManager projectManager)
        {
            projectManager.LauncherManifest.AddUsePermission("android.permission.READ_EXTERNAL_STORAGE");
            projectManager.LauncherManifest.AddUsePermission("android.permission.WRITE_EXTERNAL_STORAGE");
        }
    }
}
