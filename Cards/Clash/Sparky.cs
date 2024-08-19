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
            Rarity = CardInfo.Rarity.Common,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Damage",
                amount="x3"
            },
            new CardInfoStat()
            {
                positive=false,
                stat="Max Ammo <color=##bf1206>(PERMENANT!)</color>",
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
            gun.attackSpeed *= 1.75f;
            gunAmmo.maxAmmo = 1;
        }
    }

    public class SparkyEffect : CardEffect
    {
        public override IEnumerator OnBattleStart(IGameModeHandler gameModeHandler) {
            gunAmmo.maxAmmo = 1;
            return base.OnBattleStart(gameModeHandler);
        }
    }
}