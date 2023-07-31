using System;

using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonLotteryWeeklyRewardList feature.
/// </summary>
internal class AddonLotteryWeeklyRewardListFeature : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonLotteryWeeklyRewardListFeature"/> class.
    /// </summary>
    public AddonLotteryWeeklyRewardListFeature()
        : base("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 8B FA 48 8B D9")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "LotteryWeeklyRewardList";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.LotteryWeeklyRewardListAutoClose)
            return;

        var checkAddon = Service.GameGui.GetAddonByName(this.AddonName, 1);

        if (checkAddon == IntPtr.Zero) return;
        ClickLotteryWeeklyRewardList.Using(addon).Close();
    }
}
