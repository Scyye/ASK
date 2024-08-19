using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class DoubleTapRootBeer : CodUpgrade
    {
        public override CardDetails Details => new CardDetails()
        {
            Title = "Double Tap Root Beer",
            Description = "Cowboys can't shoot slow or they'll end up below. When they need some help, they reach for the Root beer shelf-",
            Theme = CardThemeColor.CardThemeColorType.ColdBlue,
            Rarity = CardInfo.Rarity.Rare,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Bullets",
                    amount = "+1"
                },
                new CardInfoStat()
                {
                    positive=true,
                    stat = "ATKSPD",
                    amount = "+33%"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.numberOfProjectiles += 1;
            //TODO: make sure this is the proper way of doing it.
            gun.attackSpeed *= .66f;
        }
    }
}

