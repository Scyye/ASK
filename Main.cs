using ASK.Cards;
using ASK.Cards.Clash;
using ASK.Cards.COD;
using BepInEx;
using HarmonyLib;
using ModdingUtils.Extensions;
using UnboundLib.Cards;
using UnityEngine;
using ASK.Extensions;
using System.Net.Http;
using Sirenix.Serialization;
using UnboundLib;

namespace ASK {
    // These are the mods required for our Mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.willis.rounds.modsplus", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our Mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our Mod Is associated with
    [BepInProcess("Rounds.exe")]
    public class Main : BaseUnityPlugin
    {
        private const string ModId = "dev.scyye.rounds.cards";
        private const string ModName = "Scyye Cards";
        public const string Version = "1.0.0";

        public const string ModInitials = "ScyyeCards";
        public const string CodInitials = "Call of Duty";
        public const string ClashInitials = "Clash";

        public static Main instance { get; private set; }

        public void Log(string str) {
            UnityEngine.Debug.Log($"[{ModName}] {str}");
        }

        void Awake()
        {
            instance = this;
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }


        void Start()
        {
            Log("Enabling cards");

            // COD PerkACola:
            CustomCard.BuildCard<PerkACola>();

            // COD Cards:
            CustomCard.BuildCard<DeadshotDaiquiri>();
            CustomCard.BuildCard<DoubleTapRootBeer>();
            CustomCard.BuildCard<Juggernog>();
            CustomCard.BuildCard<MuleKick>();
            CustomCard.BuildCard<PHDFlopper>();
            CustomCard.BuildCard<QuickRevive>();
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

            Log("Enabled cards");
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(DamageOverTime.TakeDamageOverTime))]
        static void DoTDamageReduction(DamageOverTime __instance, ref Vector2 damage, Vector2 position, float time, float interval, Player damagingPlayer, CharacterData ___data)
        {
            var player = ___data.player;

            if (Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).poisonResistance != 1f)
            {
                float damageMag = damage.magnitude;
                damageMag *= Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).poisonResistance;
                Vector2 damageDir = damage.normalized;

                damage = damageDir * damageMag;
            }
        }
    }
}