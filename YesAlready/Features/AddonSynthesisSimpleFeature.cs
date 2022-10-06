using System;

using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonSynthesisSimple feature.
/// </summary>
internal class AddonSynthesisSimpleFeature : UpdateFeature
{
    private ClickTalk? clickTalk = null;
    private IntPtr lastTalkAddon = IntPtr.Zero;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonSynthesisSimpleFeature"/> class.
    /// </summary>
    public AddonSynthesisSimpleFeature()
        : base("40 53 48 83 EC 30 F6 81 ?? ?? ?? ?? ?? 48 8B D9 0F 29 74 24 ?? 0F 28 F1 74 64")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "SynthesisSimple";

    /// <inheritdoc/>
    protected unsafe override void UpdateImpl(IntPtr addon, IntPtr a2, IntPtr a3)
    {
        if (!Service.Configuration.QuickSynthesisCloseWhenDoneEnabled)
            return;

        var endBtn = ((AtkUnitBase*)addon)->UldManager.NodeList[2]->GetComponent();
        var btnText = endBtn->UldManager.NodeList[2]->GetAsAtkTextNode()->NodeText.ToString();

        if (btnText == "End Synthesis")
            ClickSynthesisSimple.Using(addon).EndSynthesis();
    }
}