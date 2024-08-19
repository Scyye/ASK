using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class SpeedCola : CodUpgrade
    {
        // FIXED
        public override CardDetails Details => new CardDetails()
        {
            Title = "Speed Cola",
            Description = "Your hands are slow, your movement's sluggish, your lack of speed, just brings you anguish.",
            Theme = CardThemeColor.CardThemeColorType.TechWhite,
            Rarity = CardInfo.Rarity.Rare,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Block Cooldown",
                    amount = "-25%"
                },
                new CardInfoStat()
                {
                    positive=true,
                    stat = "Reload Speed",
                    amount = "+50%"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.reloadTime *= 0.5f;
            block.cdMultiplier *= 0.75f;
        }
    }
}
