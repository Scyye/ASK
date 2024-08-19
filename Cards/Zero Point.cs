using ModsPlus;
using UnboundLib;

namespace ASK.Cards
{
    public class ZeroPoint : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Uncommon,
            Title="Zero Point",
            Description="Don't like your deck? Replace all your cards with a random card.",
            Theme=CardThemeColor.CardThemeColorType.DestructiveRed,
        };


        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            int num = ModdingUtils.Utils.Cards.instance.RemoveAllCardsFromPlayer(player, true).Length;
            CardInfo randomCard = ModdingUtils.Utils.Cards.instance.GetRandomCardWithCondition
                (player, gun, gunAmmo, data, health, gravity, block, characterStats,
                (ci, p, g, ga, d, h, gr, b, c) => { return true; });
            for (int i = 0; i < num; i++)
            {
                ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, randomCard, false, "", 0, 0);
            }
        }
    }
}
