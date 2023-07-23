using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;
using UnboundLib.GameModes;

namespace ASK.Cards.Clash
{
    public class Sparky : CustomEffectCard<SparkyEffect>
    {
        // Removed splash damage
        public override CardDetails Details => new CardDetails()
        {
            Title = "Sparky",
            Description = "Sparky slowly charges up, then unloads MASSIVE area damage. Overkill isn't in her vocabulary.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Rare,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Damage",
                amount="x3"
            },
            /*
            new CardInfoStat()
            {
                positive = true,
                stat="Splash Damage",
                amount="+90%"
            },
            */
            new CardInfoStat()
            {
                positive=false,
                stat="Max Bullets",
                amount="1"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-75%",
                stat="ATKSPD"
            }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Added(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            gun.damage *= 3f;
            gun.attackSpeedMultiplier *= 0.25f;
            /*
            gun.explodeNearEnemyRange *= 1.5f;
            gun.explodeNearEnemyDamage *= 1.9f;
            */
            gun.ammo = 1;
        }
    }

    public class SparkyEffect : CardEffect
    {
        Gun gun;

        public override void Initialize(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Initialize(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            this.gun = gun;
        }

        public override IEnumerator OnBattleStart(IGameModeHandler gameModeHandler)
        {
            gun.ammo = 1;

            return base.OnBattleStart(gameModeHandler);
        }
    }
}