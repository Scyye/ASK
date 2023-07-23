using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class DeadshotDaiquiri : SimpleCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }

        public override CardDetails Details => new CardDetails()
        {
            Title = "Deadshot Daiquiri",
            Description = "To err is human, to forgive is divine. Well I'm not forgiving, and the error ain't mine!",
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Rarity = Main.CodRarity,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Spread",
                    amount = "Reset"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            gun.spread = 0;
        }
    }
}
