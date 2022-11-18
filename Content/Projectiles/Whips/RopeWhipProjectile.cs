using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SummoningExpanded.Content.Buffs.Whips;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummoningExpanded.Content.Projectiles.Whips {
    public class RopeWhipProjectile : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rope Whip");
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults() {
            Projectile.DefaultToWhip();

            Projectile.WhipSettings.Segments = 10;
            Projectile.WhipSettings.RangeMultiplier = 0.5f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            target.AddBuff(ModContent.BuffType<RopeWhipDebuff>(), 4 * 60);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        private void DrawLine(List<Vector2> points) {
            Texture2D texture = TextureAssets.FishingLine.Value;
            Rectangle frame = texture.Frame();
            Vector2 origin = new Vector2(frame.Width / 2, 2);

            Vector2 pos = points[0];
            for (int i = 0; i < points.Count - 1; i++) {
                Vector2 element = points[i];
                Vector2 diff = points[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.Brown);
                Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

                pos += diff;
            }
        }

        public override bool PreDraw(ref Color lightColor) {
            List<Vector2> points = new();
            Projectile.FillWhipControlPoints(Projectile, points);

            DrawLine(points);

            Main.DrawWhip_WhipBland(Projectile, points);

            return false;
        }
    }
}
