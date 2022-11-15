using SummoningExpanded.Common.Configs;
using SummoningExpanded.Common.GlobalItems;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SummoningExpanded.Common.GlobalProjectiles {
    public class BonusTagDamage : GlobalProjectile {
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.CountsAsClass(DamageClass.Summon) && ServerConfig.Instance.SummonCrit;

        private float summonTagDamageMult = 1f;

        public override void OnSpawn(Projectile projectile, IEntitySource source) {
            if (source is EntitySource_ItemUse itemUse) {
                if (itemUse.Item.TryGetGlobalItem<PrefixGlobalItem>(out var globalItem)) {
                    summonTagDamageMult = globalItem.SummonTagDamageMult;
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            var owner = Main.player[projectile.owner];
            if (summonTagDamageMult != 1f && owner.HasMinionAttackTargetNPC) {
                var heldItem = Main.player[projectile.owner].HeldItem;
                if (heldItem.CountsAsClass(DamageClass.SummonMeleeSpeed) && target.whoAmI == owner.MinionAttackTargetNPC) {
                    // Weird solution but it works
                    // Iterate over our held whips tooltips 
                    for (int i = 0; i < heldItem.ToolTip.Lines; i++) {
                        string line = heldItem.ToolTip.GetLine(i);
                        // If we find a "X summon tag damage" tooltip
                        if (line.Contains("summon tag damage")) {
                            string[] words = line.Split(" ");
                            // Parse that tooltip to get the amount of tag damage it provides
                            if (int.TryParse(words[0], out int tagDamage)) {
                                int bonusDamage = 0;
                                // If we have a positive multiplier we want the ceiling so it seems to actually do something
                                if (summonTagDamageMult < 1f) {
                                    bonusDamage = (int)MathF.Floor((float)tagDamage * summonTagDamageMult) - tagDamage;
                                }
                                else {
                                    bonusDamage = (int)MathF.Ceiling((float)tagDamage * summonTagDamageMult) - tagDamage;
                                }
                                damage += bonusDamage;
                            }
                        }
                    }
                }
            }
        }
    }
}
