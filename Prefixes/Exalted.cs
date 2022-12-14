using SummoningExpanded.Common.GlobalItems;
using Terraria;
using Terraria.ModLoader;

namespace SummoningExpanded.Prefixes {
    public class Exalted : ModPrefix {
        public override PrefixCategory Category => PrefixCategory.Custom;

        public override bool CanRoll(Item item) {
            return item.MinionOrSentryWeapon();
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
            damageMult = 1.1f;
            critBonus = 3;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult = 1.63f;
        }

        public override void Apply(Item item) {
            item.GetGlobalItem<PrefixGlobalItem>().SummonTagDamageMult = 1.25f;
        }
    }
}
