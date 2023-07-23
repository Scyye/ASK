using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.Clash
{
    public class Princess : SimpleCard
    {
        // Buffed
        public override CardDetails Details => new CardDetails()
        {
            Title = "Princess",
            Description = "This stunning Princess shoots flaming arrows from long range. If you're feeling warm feelings towards her, it's probably because you're on fire.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Damage",
                amount="+25%"
            },
            new CardInfoStat()
            {
                positive=true,
                stat="Bullet Gravity",
                amount="-25%"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-30%",
                stat="Health"
            }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            gun.damage *= 1.25f;
            gun.gravity *= 0.75f;
            characterStats.health *= 0.7f;
        }
    }
}