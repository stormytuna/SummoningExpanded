using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummoningExpanded.Content.Buffs.Whips {
    public class RopeWhipDebuff : ModBuff {
        public override void SetStaticDefaults() {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex) {

        }
    }

    public class RopeWhipDebuffNPC : GlobalNPC {
        public override bool InstancePerEntity => true;

        public bool MarkedByRopeWhip { private get; set; }

        public override void ResetEffects(NPC npc) {
            MarkedByRopeWhip = false;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            if (MarkedByRopeWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type])) {
                damage += 5;
            }
        }
    }
}
