using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class StaminUp : CodUpgrade
    {
        // Buffed
        public override CardDetails Details => new CardDetails()
        {
            Title = "Stamin-Up",
            Description = "Stamin-up-Min-Up! (x3) When you need some extra runnin', when you need some extra time-",
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Rarity = CardInfo.Rarity.Common,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Movement Speed",
                    amount = "+50%",
                    simepleAmount=CardInfoStat.SimpleAmount.aLittleBitOf
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            characterStats.movementSpeed *= 1.50f;
        }
    }
}
