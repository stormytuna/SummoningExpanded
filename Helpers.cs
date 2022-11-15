using Terraria;
using Terraria.ModLoader;

namespace SummoningExpanded {
    public static class Helpers {
        /// <summary>Returns whether or not the item is a Minion or Sentry weapon, but not a Whip weapon</summary>
        public static bool MinionOrSentryWeapon(this Item item) {
            return item.CountsAsClass(DamageClass.Summon) && !item.CountsAsClass(DamageClass.SummonMeleeSpeed);
        }
    }
}
