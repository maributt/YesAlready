using System;
using System.Threading;
using System.Threading.Tasks;
using ClickLib.Clicks;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Component.GUI;
using YesAlready;
using YesAlready.BaseFeatures;

/// <summary>
/// AddonMJIGatheringHouse feature.
/// </summary>
internal class AddonMJIFarmManagement : OnSetupFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddonMJIFarmManagement"/> class.
    /// </summary>
    public AddonMJIFarmManagement()
        : base("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 30 8B EA 49 8B F0 BA ?? ?? ?? ?? 48 8B F9 E8 ?? ?? ?? ?? 48 8B C8")
    {
    }

    /// <inheritdoc/>
    protected override string AddonName => "MJIFarmManagement";

    /// <inheritdoc/>
    protected unsafe override void OnSetupImpl(IntPtr addon, uint a2, IntPtr data)
    {
        if (!Service.Configuration.CroplandAutoCollectAll)
            return;

        Task.Run(() => {
            Thread.Sleep(100);
            if (!((AtkUnitBase*)addon)->GetButtonNodeById(24)->IsEnabled)
            {
                ClickMJIFarmManagement.Using(addon).Close();
                return;
            }

            ClickMJIFarmManagement.Using(addon).CollectAll();
            Thread.Sleep(100);
            ClickMJIFarmManagement.Using(addon).Close();
        });
    }
}