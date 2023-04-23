using System;

using ClickLib.Clicks;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonRetainerTaskAsk feature.
/// </summary>
internal class AddonRetainerItemTransferProgressFeature : UpdateFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonRetainerItemTransferProgressFeature"/> class.
    /// </summary>
    public AddonRetainerItemTransferProgressFeature()
        : base("48 89 5C 24 ?? 57 48 83 EC 20 F6 81 ?? ?? ?? ?? ?? 49 8B F8 48 8B D9 75 0D 32 C0 48 8B 5C 24 ?? 48 83 C4 20 5F C3 48 8B CF E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ??")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "RetainerItemTransferProgress";

    /// <inheritdoc/>
    protected unsafe override void UpdateImpl(IntPtr addon, IntPtr a2, IntPtr a3)
    {
        if (!Service.Configuration.RetainerItemTransferProgressAutoClose)
            return;

        if (((AtkComponentButton*)((AtkUnitBase*)addon)->UldManager.NodeList[2]->GetComponent())->ButtonTextNode->NodeText.ToString() == "Close Window")
            ClickRetainerItemTransferProgress.Using(addon).CloseWindow();
    }
}
