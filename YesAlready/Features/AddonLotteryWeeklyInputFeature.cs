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
internal class AddonLotteryWeeklyInputFeature : OnSetupFeature
{

    private readonly Random random;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonLotteryWeeklyInputFeature"/> class.
    /// </summary>
    public AddonLotteryWeeklyInputFeature()
        : base("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ??")
    {
        this.random = new Random();
    }

    /// <inheritdoc/>
    protected override string AddonName => "LotteryWeeklyInput";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.LotteryWeeklyInputAuto)
            return;

        var checkAddon = Service.GameGui.GetAddonByName(this.AddonName, 1);

        if (checkAddon == IntPtr.Zero) return;
        ClickLotteryWeeklyInput.Using(addon).Purchase(this.random.Next(0, 10000));
    }
}
