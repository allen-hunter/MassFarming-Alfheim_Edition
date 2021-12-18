using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace MassFarming
{
    [BepInPlugin("Alfheim.Farming", "Alfheim_Farming", "1.3.3")]
    public class MassFarming : BaseUnityPlugin
    {
        public static ConfigEntry<KeyboardShortcut> MassActionHotkey { get; private set; }
        public static ConfigEntry<KeyboardShortcut> ControllerPickupHotkey { get; private set; }
        public static ConfigEntry<float> MassInteractRange { get; private set; }
        public static int PlantGridSize { get; private set; }
        public static bool IgnoreStamina { get; private set; }
        public static bool IgnoreDurability { get; private set; }
        public static List<string> AllowedPickables { get; private set; }

        public void Awake()
        {
            Debug.Log("MassFarming-Alfheim_Edition is based on the work of xeio87 - https://www.nexusmods.com/valheim/users/111762253");
            MassActionHotkey = Config.Bind("Hotkeys", nameof(MassActionHotkey), new KeyboardShortcut(KeyCode.LeftShift), "Mass activation hotkey for multi-pickup/multi-plant.");
            ControllerPickupHotkey = Config.Bind("Hotkeys", nameof(ControllerPickupHotkey), new KeyboardShortcut(KeyCode.JoystickButton4), "Mass activation hotkey for multi-pickup/multi-plant for controller.");

            MassInteractRange = Config.Bind("Pickup", nameof(MassInteractRange), 5f, "Range of auto-pickup.");

            // we do not want these in the control of the user, so we moved them from ConfigEntries
            PlantGridSize = 5; // Config.Bind("Plant", nameof(PlantGridSize), 5, "Grid size of auto-plant. Reccomend odd-number, default is '5' so (5x5).");
            IgnoreStamina = false; // Config.Bind("Plant", nameof(IgnoreStamina), false, "Ignore stamina requirements when planting extra rows.");
            IgnoreDurability = false; // Config.Bind("Plant", nameof(IgnoreDurability), false, "Ignore durability when planting extra rows.");

            AllowedPickables = new List<string>();
            //explicit support for Blueberries, raspberries, cloudberries, thistle, dandelion, red mushrooms, yellow mushrooms, blue mushrooms, honey, carrots, turnips, onion (seeded version for those to), flax, barley
            AllowedPickables.Add("Barley");         // tested pick, plant
            AllowedPickables.Add("Beehive");        // tested pick
            AllowedPickables.Add("Blueberries");    // tested pick
            AllowedPickables.Add("Carrot");         // tested pick, plant
            AllowedPickables.Add("CarrotSeeds");    // tested pick, plant
            AllowedPickables.Add("Cloudberry");     // tested pick
            AllowedPickables.Add("Dandelion");      // tested pick
            AllowedPickables.Add("Flax");           // tested pick, plant
            AllowedPickables.Add("Mushroom");       // tested pick
            AllowedPickables.Add("MushroomYellow"); // tested pick
            AllowedPickables.Add("MushroomBlue");   // tested pick
            AllowedPickables.Add("Onion");          // tested pick, plant
            AllowedPickables.Add("OnionSeeds");     // tested pick, plant
            AllowedPickables.Add("Raspberry");      // tested pick
            AllowedPickables.Add("Thistle");        // tested pick
            AllowedPickables.Add("Turnip");         // tested pick, plant
            AllowedPickables.Add("TurnipSeeds");    // tested pick, plant
            

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }
    }
}
