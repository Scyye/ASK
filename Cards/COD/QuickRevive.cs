using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class QuickRevive : CodUpgrade
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Quick Revive",
            Description = "When everything's, been draggin' you down, grabbed you by the hair and pulled you to the ground-",
            Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Health Regen",
                    amount = "+6"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            health.regeneration += 6;
        }
    }
}
