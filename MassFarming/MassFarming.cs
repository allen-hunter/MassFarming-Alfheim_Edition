using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace MassFarming
{
    [BepInPlugin("xeio.MassFarming", "MassFarming-Alfheim_Edition", "1.3.1")]
    public class MassFarming : BaseUnityPlugin
    {
        public static ConfigEntry<KeyboardShortcut> MassActionHotkey { get; private set; }
        public static ConfigEntry<KeyboardShortcut> ControllerPickupHotkey { get; private set; }
        public static ConfigEntry<float> MassInteractRange { get; private set; }
        public static int PlantGridSize { get; private set; }
        public static bool IgnoreStamina { get; private set; }
        public static bool IgnoreDurability { get; private set; }

        public void Awake()
        {
            MassActionHotkey = Config.Bind("Hotkeys", nameof(MassActionHotkey), new KeyboardShortcut(KeyCode.LeftShift), "Mass activation hotkey for multi-pickup/multi-plant.");
            ControllerPickupHotkey = Config.Bind("Hotkeys", nameof(ControllerPickupHotkey), new KeyboardShortcut(KeyCode.JoystickButton4), "Mass activation hotkey for multi-pickup/multi-plant for controller.");

            MassInteractRange = Config.Bind("Pickup", nameof(MassInteractRange), 5f, "Range of auto-pickup.");

            // we do not want these in the control of the user, so we moved them from ConfigEntries
            PlantGridSize = 5; // Config.Bind("Plant", nameof(PlantGridSize), 5, "Grid size of auto-plant. Reccomend odd-number, default is '5' so (5x5).");
            IgnoreStamina = false; // Config.Bind("Plant", nameof(IgnoreStamina), false, "Ignore stamina requirements when planting extra rows.");
            IgnoreDurability = false; // Config.Bind("Plant", nameof(IgnoreDurability), false, "Ignore durability when planting extra rows.");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }
    }
}
