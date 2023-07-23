using ASK.Cards;
using ASK.Cards.Clash;
using ASK.Cards.COD;
using BepInEx;
using HarmonyLib;
using RarityLib.Utils;
using System.Collections.Generic;
using UnboundLib.Cards;
using UnityEngine;

namespace ASK
{
    // These are the mods required for our Mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib", BepInDependency.DependencyFlags.HardDependency)]


    // Declares our Mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our Mod Is associated with
    [BepInProcess("Rounds.exe")]
    public class Main : BaseUnityPlugin
    {
        private const string ModId = "tk.scyye.rounds.ask";
        private const string ModName = "Aidan Scyye Keyanlux";
        public const string Version = "2.0.5";

        public const string ModInitials = "ASK";
        public const string CodInitials = "COD";
        public const string ClashInitials = "Clash";

        public static CardInfo.Rarity CodRarity;

        public static Main instance { get; private set; }

        public List<CardInfo> CodCards;

        public void Log(string str)
        {
            UnityEngine.Debug.Log($"[{ModName}] {str}");
        }

        void Awake()
        {
            instance = this;
            Log(ModId);

            var harmony = new Harmony(ModId);
            harmony.PatchAll();

            RarityUtils.AddRarity("Call of Duty", 0.05f, new Color(24, 89, 40), new Color(88, 133, 99));
            CodRarity = RarityUtils.GetRarity("Call of Duty");
        }


        void Start()
        {
            Log("Enabling cards");

            // COD PerkACola:
            // CustomCard.BuildCard<PerkACola>();

            // COD Cards:
            CustomCard.BuildCard<DeadshotDaiquiri>();
            CustomCard.BuildCard<DoubleTapRootBeer>();
            CustomCard.BuildCard<Juggernog>();
            CustomCard.BuildCard<MuleKick>();
            CustomCard.BuildCard<PHDFlopper>();
            // REMOVED QUICKREVIVE UNTIL A GOOD IMPL CAN BE FOUND
            // CustomCard.BuildCard<QuickRevive>();
            CustomCard.BuildCard<SpeedCola>();
            CustomCard.BuildCard<StaminUp>();

            // Clash Cards:
            CustomCard.BuildCard<Archer>();
            CustomCard.BuildCard<DartGoblin>();
            CustomCard.BuildCard<Giant>();
            CustomCard.BuildCard<Knight>();
            CustomCard.BuildCard<Princess>();
            CustomCard.BuildCard<Sparky>();

            // Other Cards:
            CustomCard.BuildCard<Fly>();
            CustomCard.BuildCard<Microcosm>();
            CustomCard.BuildCard<OneForAll>();
            CustomCard.BuildCard<ZeroPoint>();
            CustomCard.BuildCard<Arthritis>();
            CustomCard.BuildCard<FourSeasons>();
        }
    }
}