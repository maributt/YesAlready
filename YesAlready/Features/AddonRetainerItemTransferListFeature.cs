using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.UI;
using System.Threading;
using YesAlready.BaseFeatures;

namespace YesAlready.Features;

/// <summary>
/// AddonRetainerTaskAsk feature.
/// </summary>
internal unsafe class AddonRetainerItemTransferListFeature : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonRetainerItemTransferListFeature"/> class.
    /// </summary>
    public AddonRetainerItemTransferListFeature()
        : base("4C 8B DC 53 55 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B D9")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "RetainerItemTransferList";

    /// <inheritdoc/>
    protected override void OnSetupImpl(nint addon, uint a2, nint data)
    {
        if (!Service.Configuration.RetainerItemTransferListAutoConfirm)
            return;
        ClickRetainerItemTransferList.Using(addon).Confirm();
    }
}