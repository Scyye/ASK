using ModsPlus;
using System.Collections;
using UnboundLib;
using UnboundLib.GameModes;
using UnityEngine;

namespace ASK.Cards
{
    public class Arthritis : CustomEffectCard<ArthritisEffect>
    {
        // NERFED
        public override CardDetails Details => new CardDetails
        {
            ModName=Main.ModInitials,
            Rarity=CardInfo.Rarity.Uncommon,
            Title="Arthritis",
            Description= "These old joints got a lot of experience",
            Theme=CardThemeColor.CardThemeColorType.DestructiveRed,
            Stats = new[]
            {
                new CardInfoStat()
                {
                    amount = "+10%",
                    positive=true,
                    stat="Lifesteal"
                },
                new CardInfoStat()
                {
                    amount="+3",
                    positive=true,
                    stat = "Ammo"
                },
                new CardInfoStat()
                {
                    amount="+2",
                    positive=true,
                    stat="Jumps"
                },
                new CardInfoStat()
                {
                    amount = "-15%",
                    positive=false,
                    stat="Movement Speed"
                },
                new CardInfoStat()
                {
                    amount="1% Self Damage",
                    positive=false,
                    stat="On Jump"
                }
            }
        };


        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.movementSpeed *= 0.85f;
            characterStats.lifeSteal *= 1.25f;
            characterStats.numberOfJumps += 1;
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            Main.instance.Log($"Enabling Card: {cardInfo.cardName}");
        }
    }

    public class ArthritisEffect : CardEffect
    {
        HealthHandler Health { get; set;}
        Player Player { get; set; }
        CharacterStatModifiers Modifiers { get; set; }

        public override void Initialize(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            base.Initialize(player, gun, gunAmmo, data, health, gravity, block, characterStats);
            this.Health = health;
            this.Player= player;
            this.Modifiers=characterStats;
        }

        public override void OnJump()
        {
            int d = Mathf.RoundToInt(Modifiers.health / 100);
            if (d == 0) d = 1;
            Vector2 dmg = new Vector2(0, d);
            Health.DoDamage(dmg, Player.transform.position, UnityEngine.Color.cyan);
        }
    }
}
