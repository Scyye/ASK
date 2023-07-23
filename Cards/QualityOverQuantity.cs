using ModsPlus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.GameModes;

namespace ASK.Cards
{
    internal class QualityOverQuantity : CustomEffectCard<QualityOverQuantityEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            ModName = Main.ModInitials,
            Rarity = CardInfo.Rarity.Common,
            Title = "Quality Over Quantity",
            Description = "The less bullets you have, the more damage you do!",
            Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    amount = "RESET",
                    positive=true,
                    stat="ALL STATS"
                },
                new CardInfoStat()
                {
                    amount="RESET",
                    positive=false,
                    stat = "ALL STATS"
                }
            }
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

        }
    }

    internal class QualityOverQuantityEffect : CardEffect
    {
        Gun gun {get;set;}
        

        public override void Initialize(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Initialize(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            this.gun=gun;
        }

        public override IEnumerator OnBattleStart(IGameModeHandler gameModeHandler)
        {

            return base.OnBattleStart(gameModeHandler);
        }
    }
}
