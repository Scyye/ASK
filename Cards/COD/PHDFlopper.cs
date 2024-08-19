using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.COD
{
    public class PHDFlopper : CodUpgrade
    {
        // Fixed stats
        public override CardDetails Details => new CardDetails()
        {
            Title = "PhD Flopper",
            Description = "PhD, night-time scene. PhD, the streets are mean. PhD, the things I've seen, the good (PhD), and the bad.",
            Theme = CardThemeColor.CardThemeColorType.DefensiveBlue,
            Rarity = CardInfo.Rarity.Uncommon,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive= true,
                    stat = "Poison Resistance",
                    amount = "+50%"
                }
            },
            ModName = Main.CodInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            ASK.Extensions.CharacterStatModifiersExtension.GetAdditionalData(characterStats).poisonResistance *= 0.50f;
        }
    }
}