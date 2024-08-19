using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ModsPlus;

namespace ASK.Cards.Clash
{
    public class DartGoblin : SimpleCard
    {
        // FIXED
        public override CardDetails Details => new CardDetails()
        {
            Title = "Dart Goblin",
            Description = "Runs fast, shoots far and chews gum. How does he blow darts with a mouthful of Double Trouble Gum? Years of didgeridoo lessons.",
            Theme = CardThemeColor.CardThemeColorType.PoisonGreen,
            Rarity = CardInfo.Rarity.Rare,
            Stats = new CardInfoStat[]
            {
            new CardInfoStat()
            {
                positive= true,
                stat = "Speed",
                amount="+55%"
            },
            new CardInfoStat()
            {
                positive=true,
                stat="ATKSPD",
                amount="x4"
            },
            new CardInfoStat()
            {
                positive = true,
                amount="+15",
                stat="Ammo"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-50%",
                stat="Damage"
            },
            new CardInfoStat()
            {
                positive=false,
                amount="-30%",
                stat="Health"
            }
            },
            ModName = Main.ClashInitials
        };

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.movementSpeed *= 1.55f;
            gun.attackSpeed *= 0.25f;
            gun.damage *= 0.5f;
            gunAmmo.maxAmmo += 15;
            data.maxHealth *= 0.7f;
        }
    }
}