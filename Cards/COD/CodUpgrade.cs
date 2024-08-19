using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModsPlus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASK.Cards.COD {
    public abstract class CodUpgrade : SimpleCard {
        internal static CardCategory category = CustomCardCategories.instance.CardCategory("CallOfDuty");

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers) {
            cardInfo.allowMultiple = false;
            cardInfo.categories = new CardCategory[] { category };
        }
    }
}
