using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class DoubleTapRootBeer : SimpleCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }
        public override CardDetails Details => new CardDetails()
        {
            Title = "Double Tap Root Beer",
            Description = "Cowboys can't shoot slow or they'll end up below. When they need some help, they reach for the Root beer shelf-",
            Theme = CardThemeColor.CardThemeColorType.ColdBlue,
            Rarity = Main.CodRarity,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Bullets",
                    amount = "+2"
                },
                new CardInfoStat()
                {
                    positive=true,
                    stat = "Fire Rate",
                    amount = "+33%"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            gun.numberOfProjectiles += 2;
            //TODO: make sure this is the proper way of doing it.
            gun.timeBetweenBullets *= .66f;
        }
    }
}

