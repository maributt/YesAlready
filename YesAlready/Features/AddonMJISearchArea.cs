using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YesAlready;
using YesAlready.BaseFeatures;

/// <summary>
/// AddonMJIGatheringHouse feature.
/// </summary>
internal class AddonMJISearchArea : UpdateFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonMJISearchArea"/> class.
    /// </summary>
    public AddonMJISearchArea()
        : base("48 89 74 24 ?? 57 48 83 EC 20 F6 81 ?? ?? ?? ?? ?? 49 8B F8 48 8B F1 75 0D")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "MJISearchArea";

    /// <inheritdoc/>
    protected unsafe override void UpdateImpl(IntPtr addon, IntPtr a2, IntPtr a3)
    {
        if (!Service.Configuration.AutoMaxExploration)
            return;
        var b = ((AtkUnitBase*)addon)->GetButtonNodeById(51);
        Task.Run(() =>
        {
            Thread.Sleep(100);
            if (b->IsEnabled)
                ClickMJISearchArea.Using(addon).Confirm();
        });
    }
}