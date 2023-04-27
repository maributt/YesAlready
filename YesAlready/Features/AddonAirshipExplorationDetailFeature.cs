using System;
using System.Threading;

using ClickLib.Clicks;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonAirshipExplorationDetail feature.
/// </summary>
internal class AddonAirshipExplorationDetailFeature : OnSetupFeature
{
    private static readonly uint DeployBtnId = 26U;
    private static readonly uint CancelBtnId = 27U;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonAirshipExplorationDetailFeature"/> class.
    /// </summary>
    public AddonAirshipExplorationDetailFeature()
        : base("48 89 5C 24 ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 8B FA 49 8B F0 BA ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? BA ?? ?? ?? ??")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "AirshipExplorationDetail";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.VoyageDetailsDeployEnabled)
            return;
        new Thread(() =>
        {
            Thread.Sleep(100);
            if (((AtkUnitBase*)addon)->GetButtonNodeById(DeployBtnId)->IsEnabled)
                ClickAirshipExplorationDetail.Using(addon).Deploy(((AtkUnitBase*)addon)->GetButtonNodeById(DeployBtnId));
            else
                ClickAirshipExplorationDetail.Using(addon).Cancel(((AtkUnitBase*)addon)->GetButtonNodeById(CancelBtnId));
        }).Start();
    }
}