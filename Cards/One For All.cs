using ModsPlus;

namespace ASK.Cards
{
    public class OneForAll : SimpleCard
    {
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Rare,
            Title="One For All",
            Description="One for all, all for one.",
            Theme=CardThemeColor.CardThemeColorType.DestructiveRed,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    amount = "+25%",
                    positive=true,
                    stat="All Stats"
                },
                new CardInfoStat()
                {
                    amount="+25%",
                    positive=false,
                    stat = "All Stats"
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
        }

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gunAmmo.maxAmmo += gunAmmo.maxAmmo/4;
            gunAmmo.ammoReg *= 1.25f;
            gun.attackSpeed *= 1.25f;
            gun.bodyRecoil *= 1.25f;
            gun.bursts += gun.bursts / 4;
            gun.damage *= 1.25f;
            gun.gravity *= 1.25f;
            gun.projectileSpeed *= 1.25f;
            gun.recoil *= 1.25f;
            gun.damageAfterDistanceMultiplier *= 1.25f;

            gunAmmo.reloadTimeMultiplier *= 1.25f;

            gravity.gravityForce *= 1.25f;

            block.additionalBlocks += block.additionalBlocks / 4;
            block.cdMultiplier *= 1.25f;
            block.forceToAdd *= 1.25f;
            block.forceToAddUp *= 1.25f;

            data.maxHealth *= 1.25f;
            characterStats.jump *= 1.25f;
            characterStats.numberOfJumps += characterStats.numberOfJumps / 4;
            characterStats.attackSpeedMultiplier *= 1.25f;
            characterStats.sizeMultiplier *= 1.25f;
            characterStats.lifeSteal *= 1.25f;
            characterStats.movementSpeed *= 1.25f;
            characterStats.regen *= 1.25f;
            characterStats.respawns += 1;
            characterStats.sizeMultiplier *= 1.25f;
            characterStats.secondsToTakeDamageOver *= 1.25f;
        }
    }
}
