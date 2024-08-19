using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModsPlus;
using System.Linq;

namespace ASK.Cards.COD
{
    internal class PerkACola : CodUpgrade
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Perk-A-Cola",
            Description = "Gives you a random COD card from ASK (or any mod that adds more COD cards)",
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "COD Card",
                    amount = "+1 Random"
                }
           },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            var randomCodCard = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, Condition);

            if (randomCodCard == null)
            {
                randomCodCard = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, ConditionDupe);
            }

            ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, randomCodCard, false, "", 0, 0);
        }

        public bool Condition(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            foreach (var c in CustomCardCategories.instance.GetActiveCardsFromCategory(category))
            {
                if (!c.Equals(card) || !data.currentCards.Contains(c)) continue;
                return true;
            }
            return false;
        }

        public bool ConditionDupe(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            foreach (var c in CustomCardCategories.instance.GetActiveCardsFromCategory(category))
            {
                if (!c.Equals(card)) continue;
                return true;
            }
            return false;
        }
    }
}
