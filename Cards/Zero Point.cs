using ModsPlus;
using UnboundLib;

namespace ASK.Cards
{
    public class ZeroPoint : SimpleCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Common,
            Title="Zero Point",
            Description="Don't like your stats?",
            Theme=CardThemeColor.CardThemeColorType.DestructiveRed,
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
            ModdingUtils.Utils.Cards.instance.RemoveAllCardsFromPlayer(player, true);
        }
    }
}
