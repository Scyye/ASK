using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.Clash
{
    public class Knight : SimpleCard
    {
        // NERFED
        public override CardDetails Details => new CardDetails()
        {
            Title = "Knight",
            Description = "A tough melee fighter. The Barbarian's handsome, cultured cousin. Rumor has it that he was knighted based on the sheer awesomeness of his mustache alone.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat="Health",
                    amount = "+45%"
                },
                new CardInfoStat()
                {
                    positive= true,
                    stat = "ATKSPD",
                    amount = "+25%"
                },
                new CardInfoStat()
                {
                    positive=false,
                    stat="Damage",
                    amount="-15%"
                }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            characterStats.health *= 1.5f;
            gun.attackSpeedMultiplier *= 0.75f;
            gun.damage *= 0.85f;
        }
    }
}
