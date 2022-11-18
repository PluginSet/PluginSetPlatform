
using System.Collections.Generic;
using PluginSet.Core;
using PluginSet.Core.Editor;
using UnityEditor;

namespace PluginSet.Platform.Editor
{
    [BuildTools]
    public static class PlatformBuildTools
    {
        [AndroidGradleProperties(0)]
        static Dictionary<string, string> gradleProperties => new Dictionary<string, string>()
        {
            {"android.useAndroidX", "true"},
            {"android.enableJetifier", "true"},
        };
        
        [OnSyncEditorSetting]
        public static void OnSyncEditorSetting(BuildProcessorContext context)
        {
            Global.CopyDependenciesInLib("com.pluginset.platform");
            context.AddLinkAssembly("PluginSet.Platform");
            
            var asset = context.BuildChannels;
            var buildParams = asset.Get<PlatformBuildParams>("Platform");

            var pluginConfig = context.Get<PluginSetConfig>("pluginsConfig");
            var config = pluginConfig.Get<PluginPlatformConfig>("Platform");
            config.ShareSuccessBack = buildParams.ShareSuccessBack;
        }

        [AndroidProjectModify]
        public static void AndroidProjectModify(BuildProcessorContext context, AndroidProjectManager projectManager)
        {
            if (projectManager.LauncherGradle.TargetSdkVersion >= 30)
            {
                var node = projectManager.LauncherManifest.AddUsePermission("android.permission.QUERY_ALL_PACKAGES");
                node.SetAttribute("ignore", AndroidConst.NS_TOOLS, "QueryAllPackagesPermission");
            }
        }
    }
}
