using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class MuleKick : SimpleCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }
        public override CardDetails Details => new CardDetails()
        {
            Title = "Mule Kick",
            Description = "Legend tells us of a man, a hero in a tortured land, where Señoritas lived in fear.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = Main.CodRarity,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Bullets",
                    amount = "x2"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            gun.numberOfProjectiles *= 2;
        }
    }
}
