using System;

using ClickLib.Clicks;
using Dalamud.Logging;/*
using XivCommon;*/
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonAirshipExplorationResult feature.
/// </summary>
internal class AddonAirshipExplorationResultFeature : OnSetupFeature
{/*
    private XivCommonBase xivCommon;*/

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

    }
}
