using SummoningExpanded.Common.Configs;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace SummoningExpanded.Common.GlobalProjectiles {
    public class CriticalStrikeChance : GlobalProjectile {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.CountsAsClass(DamageClass.Summon) && ServerConfig.Instance.SummonCrit;

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            if (Main.rand.Next(100) < projectile.CritChance) {
                crit = true;
            }
        }
    }
}

namespace SummoningExpanded.Common.GlobalItems {
    public class CriticalStrikeChance : GlobalItem {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.CountsAsClass(DamageClass.Summon) && ServerConfig.Instance.SummonCrit;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            int index = tooltips.FindIndex(tip => tip.Name == "Damage") + 1;
            tooltips.Insert(index, new(Mod, "CritChance", $"{item.crit + 4}% critical strike chance"));
        }
    }
}