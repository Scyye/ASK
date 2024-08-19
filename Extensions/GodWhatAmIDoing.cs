using System;
using System.Runtime.CompilerServices;
using HarmonyLib;

namespace ASK.Extensions {
    // ADD FIELDS TO GUN
    [Serializable]
    public class CharacterStatModifiersAdditionalData {
        public float poisonResistance;

        public CharacterStatModifiersAdditionalData()
        {
            poisonResistance = 1f;
        }
    }
    public static class CharacterStatModifiersExtension {
        public static readonly ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData> data =
            new ConditionalWeakTable<CharacterStatModifiers, CharacterStatModifiersAdditionalData>();

        public static CharacterStatModifiersAdditionalData GetAdditionalData(CharacterStatModifiers statModifiers)
        {
            return data.GetOrCreateValue(statModifiers);
        }

        public static void AddData(this CharacterStatModifiers statModifiers, CharacterStatModifiersAdditionalData value)
        {
            try
            {
                data.Add(statModifiers, value);
            }
            catch (Exception) { }
        }
    }

    [HarmonyPatch(typeof(CharacterStatModifiers), "ResetStats")]
    class CharacterStatModifiersPatchResetStats {
        private static void Prefix(CharacterStatModifiers __instance)
        {
            CharacterStatModifiersExtension.GetAdditionalData(__instance).poisonResistance = 1f;
        }
    }
}