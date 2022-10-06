using System;

using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonJournalResult feature.
/// </summary>
internal class AddonLobbyDKTCheckFeature : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonLobbyDKTCheckFeature"/> class.
    /// </summary>
    public AddonLobbyDKTCheckFeature()
        : base("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC CC 48 89 5C 24 ?? 57 48 83 EC 20 48 8B 01 49 8B F8 48 8B D9 FF 90 ?? ?? ?? ?? BA ?? ?? ?? ??")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "LobbyDKTCheck";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.DKTCheckSkip)
            return;

        ClickLobbyDKTCheck.Using(addon).SelectWorld();
    }
}