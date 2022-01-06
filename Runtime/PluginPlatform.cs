
using System;
using PluginSet.Core;

namespace PluginSet.Platform
{
    [PluginRegister]
    public partial class PluginPlatform : PluginBase
    {
        public override string Name => "Platform";
        
        protected override void Init(PluginSetConfig config)
        {
            var platform = config.Get<PluginPlatformConfig>("Platform");
            InitShare(platform);
        }
    }
}
