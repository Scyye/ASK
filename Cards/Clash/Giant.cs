using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.Clash
{
    public class Giant : SimpleCard
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Giant",
            Description = "Slow but durable, only attacks buildings. A real one-man wrecking crew!",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Damage",
                amount = "+50%"
            },
            new CardInfoStat()
            {
                positive=true,
                stat="Health",
                amount="+50%"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-40%",
                stat="Move Speed"
            }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.damage *= 1.5f;
            data.maxHealth *= 1.5f;
            characterStats.movementSpeed *= 0.6f;
        }
    }
}