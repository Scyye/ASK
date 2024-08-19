using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class Juggernog : CodUpgrade {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Juggernog",
            Description = "When you need some help to get by, something to make you feel strong.",
            Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Health",
                    amount = "+150",
                    simepleAmount=CardInfoStat.SimpleAmount.aLotOf
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            data.maxHealth += 150;
        }
    }
}
