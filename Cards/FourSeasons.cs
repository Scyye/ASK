using ModsPlus;
using System;
using UnityEngine;

namespace ASK.Cards
{
    public class FourSeasons : CustomEffectCard<FourSeasonsEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            ModName = Main.ModInitials,
            Rarity = CardInfo.Rarity.Uncommon,
            Title = "Four Seasons",
            Description = "Give different stats based on your position",
            Theme = CardThemeColor.CardThemeColorType.TechWhite
        };
    }

    public class FourSeasonsEffect : CardEffect
    {
        private static Vector2 center = new Vector2(960, 540);

        enum VectorComparison
        {
            TopRight,
            BottomRight,
            TopLeft,
            BottomLeft,
            TheSame
        }

        private VectorComparison Compare(Vector3 var1, Vector2 var2)
        {
            Vector2 vector2 = new Vector2(var1.x, var1.y);
            if (vector2.Equals(var2))
            {
                return VectorComparison.TheSame;
            }

            int xComparison = Math.Sign(vector2.x - var2.x);
            int yComparison = Math.Sign(vector2.y - var2.y);

            return (VectorComparison)(2 + yComparison - xComparison * 2);
        }

        void Update()
        {
            Vector3 pos = player.transform.position;
            VectorComparison comparison = Compare(pos, center);
            if (comparison == VectorComparison.TopRight)
            {
                health.Heal(2);
            } else if (comparison == VectorComparison.BottomRight)
            {
                gun.damage *= 2;
            } else if (comparison == VectorComparison.TopLeft)
            {
                block.cdMultiplier = 3;
            } else if (comparison == VectorComparison.BottomLeft)
            {
                characterStats.gravity -= 2;
            }

            Main.instance.Log(Compare(pos, center).ToString());
        }
    }
}
