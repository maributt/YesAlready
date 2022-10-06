using System;

using ClickLib.Clicks;
using Dalamud.Logging;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonAirshipExplorationDetail feature.
/// </summary>
internal class AddonAirshipExplorationDetailFeature : OnSetupFeature
{
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
        PluginLog.LogDebug($"a2: {a2}");
        if (!Service.Configuration.VoyageDetailsDeployEnabled)
            return;

        ClickAirshipExplorationDetail.Using(addon).Deploy();
        // check if submarine needs repairs
        // check if enough fuel to send on voyage
        // ClickAirshipExplorationDetail.Using(addon).Close();
        var res = Service.GameGui.GetAddonByName("AirshipExplorationResult", 1);
        if (res != IntPtr.Zero)
            ClickAirshipExplorationResult.Using(res).Close();
    }
}