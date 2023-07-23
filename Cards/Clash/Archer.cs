using ModsPlus;

namespace ASK.Cards.Clash
{
    public class Archer : SimpleCard
    {
        // FIXED
        public override CardDetails Details => new CardDetails()
        {
            Title = "Archer",
            Description = "A pair of lightly armored ranged attackers. They'll help you take down ground and air units, but you're on your own with hair coloring advice.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Range",
                amount = "+50%"
            },
            new CardInfoStat()
            {
                positive=true,
                stat="Bullet Growth",
                amount="+15%"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-20%",
                stat="Damage"
            }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            gun.destroyBulletAfter *= 1.5f;
            gun.damageAfterDistanceMultiplier *= 1.15f;
            gun.damage *= 0.8f;
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            base.SetupCard(cardInfo, gun, cardStats, statModifiers);

        }
    }
}