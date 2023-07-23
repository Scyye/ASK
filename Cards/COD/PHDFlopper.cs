using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class PHDFlopper : SimpleCard
    {
        // Fixed stats
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }
        public override CardDetails Details => new CardDetails()
        {
            Title = "PhD Flopper",
            Description = "PhD, night-time scene. PhD, the streets are mean. PhD, the things I've seen, the good (PhD), and the bad.",
            Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
            Rarity = Main.CodRarity,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Projectile Cunt",
                    amount = "+2"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);

            gun.numberOfProjectiles += 2;
        }
    }
}