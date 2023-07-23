using ModsPlus;

namespace ASK.Cards.COD
{
    internal class PerkACola : SimpleCard
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Perk-A-Cola",
            Description = "Gives you a random COD card from ASK (or any mod that adds more COD cards)",
            Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
            Rarity = CardInfo.Rarity.Rare,
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
            var randomCodCard = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, condition);

            if (randomCodCard == null)
            {
                randomCodCard = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, conditionDupe);
            }

            ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, randomCodCard, false, "", 0, 0);
        }

        public bool condition(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            foreach (var c in Main.instance.CodCards)
            {
                if (!c.Equals(card) || !data.currentCards.Contains(c) || c.rarity == Main.CodRarity) continue;
                return true;
            }
            return false;
        }

        public bool conditionDupe(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            foreach (var c in ModdingUtils.Utils.Cards.all)
            {
                if (!c.Equals(card) || c.rarity == Main.CodRarity) continue;
                return true;
            }
            return false;
        }
    }
}
