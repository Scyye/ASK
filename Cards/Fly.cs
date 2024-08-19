using ModsPlus;

namespace ASK.Cards
{
    public class Fly : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Uncommon,
            Title="Fly",
            Description="Allows you to jump multiple times, 3 to be excat!",
            Theme=CardThemeColor.CardThemeColorType.DefensiveBlue,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    amount = "+3",
                    positive=true,
                    stat="Jumps"
                },
                new CardInfoStat()
                {
                    amount="-15%",
                    positive=false,
                    stat = "Movement Speed"
                }
            }
        };


        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.movementSpeed *= 0.85f;
            data.jumps += 3;
        }
    }
}
