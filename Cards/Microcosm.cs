using ModsPlus;

namespace ASK.Cards
{
    public class Microcosm : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Uncommon,
            Title="Microcosm",
            Description="Compact your damage into a tiny bullet!",
            Theme=CardThemeColor.CardThemeColorType.TechWhite,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    amount = "+50%",
                    positive=true,
                    stat="Damage"
                },
                new CardInfoStat()
                {
                    amount="-75%",
                    positive=false,
                    stat = "Bullet Size"
                },
                new CardInfoStat()
                {
                    amount="-10%",
                    positive=false,
                    stat="Health"
                }
            }
        };


        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.projectileSize -= 0.75f;
            gun.damage *= 1.5f;
            data.maxHealth *= 0.9f;
        }
    }
}
