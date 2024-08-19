using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class DeadshotDaiquiri : CodUpgrade
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Deadshot Daiquiri",
            Description = "To err is human, to forgive is divine. Well I'm not forgiving, and the error ain't mine!",
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Spread",
                    amount = "Reset"
                },
                new CardInfoStat()
                {
                    positive=true,
                    stat = "Damage",
                    amount = "+25%"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.spread = 0;
            gun.damage *= 1.25f;
        }
    }
}
