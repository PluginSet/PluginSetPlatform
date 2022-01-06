using PluginSet.Core;
using UnityEngine;

namespace PluginSet.Platform
{
    [PluginSetConfig("Platform")]
    public class PluginPlatformConfig: ScriptableObject
    {
        [Tooltip("调用分享API时，是否回调成功\n（默认回调失败）\n（未实现本地分享真实回调接口）")]
        public bool ShareSuccessBack;
    }
}