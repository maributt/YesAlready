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
internal class AddonLobbyDKTWorldListFeature : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonLobbyDKTWorldListFeature"/> class.
    /// </summary>
    public AddonLobbyDKTWorldListFeature()
        : base("E9 ?? ?? ?? ?? CC CC CC CC CC CC CC CC CC CC CC 48 89 5C 24 ?? 57 48 83 EC 20 48 8B 01 49 8B F8 48 8B D9 FF 90 ?? ?? ?? ?? BA ?? ?? ?? ??")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "LobbyDKTWorldList";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.DKTCheckSkip)
            return;

        var checkAddon = Service.GameGui.GetAddonByName("LobbyDKTCheck", 1);

        if (checkAddon == IntPtr.Zero) return;
        //PluginLog.LogDebug($"{this.AddonName} says: a2:{a2}\naddon: ${addon:x}|{addon}\ndata: {data:x}|{data}");
        ClickLobbyDKTCheck.Using(checkAddon).SelectWorld();

        /*var addonPtr = (AddonLobbyDKTCheck*)addon;
        *//*if (!selectWorldButton->IsEnabled)
            return;*//*

        ClickLobbyDKTCheck.Using(addon).SelectWorld();*/
    }
}
