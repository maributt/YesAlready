using System;
using System.Text.RegularExpressions;
using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonJournalResult feature.
/// </summary>
internal class AddonSynthesisSimpleDialogFeature : OnSetupFeature
{

    /// <summary>
    /// Initializes a new instance of the <see cref="AddonSynthesisSimpleDialogFeature"/> class.
    /// </summary>
    public AddonSynthesisSimpleDialogFeature()
        : base("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 BA ?? ?? ?? ?? 49 8B F0 48 8B F9 E8 ?? ?? ?? ?? 33 DB 48 85 C0")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "SynthesisSimpleDialog";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.QuickSynthesisMaxEnabled)
            return;

        var nodeText = ((AtkUnitBase*)addon)->UldManager.NodeList[6]->GetAsAtkTextNode()->NodeText.ToString();
        var match = Regex.Match(nodeText, @"\d+");
        var maxAmountMatch = match.Value;

        if (match.Success && int.TryParse(maxAmountMatch, out int maxAmount))
            ClickSynthesisSimpleDialog.Using(addon).Synthesize(maxAmount, true);
    }
}