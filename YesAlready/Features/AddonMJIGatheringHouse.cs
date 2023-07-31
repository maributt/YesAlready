using System;
using System.Threading;
using System.Threading.Tasks;

using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonMJIGatheringHouse feature.
/// </summary>
internal class AddonMJIGatheringHouse : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonMJIGatheringHouse"/> class.
    /// </summary>
    public AddonMJIGatheringHouse()
        : base("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 55 41 54 41 55 41 56 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 60 41 BE ?? ?? ?? ??")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "MJIGatheringHouse";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.GranaryAutoCollect)
            return;
        Task.Run(() =>
        {
            var a = (AtkUnitBase*)addon;
            Thread.Sleep(1);
            var b1 = a->GetButtonNodeById(40);
            var b2 = a->GetButtonNodeById(5);
            PluginLog.Debug($"b1->IsEnabled: {b1->IsEnabled}, b2->IsEnabled: {b2->IsEnabled}");
            if (b1->IsEnabled)
                ClickMJIGatheringHouse.Using(addon).CollectGranary(0);
            Thread.Sleep(100);
            if (b2->IsEnabled)
                ClickMJIGatheringHouse.Using(addon).CollectGranary(1);
        });
    }
}
