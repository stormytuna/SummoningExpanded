using SummoningExpanded.Common.Configs;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
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

        public override void SetDefaults(Item item) {
            #region crit
            // Just gives tonnes of vanilla items crit chance
            // Minions tend to be low, whips tend to be middling, sentries tend to be high
            switch (item.type) {
                // Sentries
                case ItemID.DD2LightningAuraT2Popper:
                    item.crit = 4;
                    break;
                case ItemID.DD2FlameburstTowerT2Popper:
                    item.crit = 4;
                    break;
                case ItemID.DD2ExplosiveTrapT2Popper:
                    item.crit = 4;
                    break;
                case ItemID.DD2BallistraTowerT2Popper:
                    item.crit = 4;
                    break;
                case ItemID.StaffoftheFrostHydra:
                    item.crit = 6;
                    break;
                case ItemID.DD2LightningAuraT3Popper:
                    item.crit = 8;
                    break;
                case ItemID.DD2FlameburstTowerT3Popper:
                    item.crit = 8;
                    break;
                case ItemID.DD2ExplosiveTrapT3Popper:
                    item.crit = 8;
                    break;
                case ItemID.DD2BallistraTowerT3Popper:
                    item.crit = 8;
                    break;
                case ItemID.MoonlordTurretStaff:
                    item.crit = 10;
                    break;
                case ItemID.RainbowCrystalStaff:
                    item.crit = 10;
                    break;
                // Minions
                case ItemID.DeadlySphereStaff:
                    item.crit = 2;
                    break;
                case ItemID.PygmyStaff:
                    item.crit = 2;
                    break;
                case ItemID.RavenStaff:
                    item.crit = 2;
                    break;
                case ItemID.TempestStaff:
                    item.crit = 4;
                    break;
                case ItemID.XenoStaff:
                    item.crit = 2;
                    break;
                case ItemID.StardustCellStaff:
                    item.crit = 6;
                    break;
                // Whips
                case ItemID.SwordWhip:
                    item.crit = 2;
                    break;
                case ItemID.ScytheWhip:
                    item.crit = 4;
                    break;
                case ItemID.MaceWhip:
                    item.crit = 6;
                    break;
                case ItemID.RainbowWhip:
                    item.crit = 8;
                    break;
            }
            #endregion
        }
    }
}