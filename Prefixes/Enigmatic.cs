using SummoningExpanded.Common.GlobalItems;
using Terraria;
using Terraria.ModLoader;

namespace SummoningExpanded.Prefixes {
    public class Enigmatic : ModPrefix {
        public override PrefixCategory Category => PrefixCategory.Custom;

        public override bool CanRoll(Item item) {
            return item.MinionOrSentryWeapon();
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
            damageMult = 1.05f;
            useTimeMult = 0.9f;
            critBonus = 2;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult = 1.34f;
        }

        public override void Apply(Item item) {
            item.GetGlobalItem<PrefixGlobalItem>().SummonTagDamageMult = 1f;
        }
    }
}
