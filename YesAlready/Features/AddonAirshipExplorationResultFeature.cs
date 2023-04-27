using System;
using System.Threading;

using ClickLib.Clicks;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonAirshipExplorationResult feature.
/// </summary>
internal class AddonAirshipExplorationResultFeature : OnSetupFeature
{
    private static readonly uint RedeployBtnId = 27U;
    private static readonly uint FinalizeBtnId = 28U;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonAirshipExplorationResultFeature"/> class.
    /// </summary>
    public AddonAirshipExplorationResultFeature()
        : base("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 60 44 8B E2 4D 8B F8")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "AirshipExplorationResult";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.VoyageLogRedeployEnabled)
            return;
        new Thread(() =>
        {
            Thread.Sleep(100);
            if (((AtkUnitBase*)addon)->GetButtonNodeById(RedeployBtnId)->IsEnabled)
                ClickAirshipExplorationResult.Using(addon).Redeploy(((AtkUnitBase*)addon)->GetButtonNodeById(RedeployBtnId));
            else
                ClickAirshipExplorationResult.Using(addon).FinalizeReport(((AtkUnitBase*)addon)->GetButtonNodeById(FinalizeBtnId));
        }).Start();
    }
}
