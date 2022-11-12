using SummoningExpanded.Common.Configs;
using Terraria;
using Terraria.ModLoader;

namespace SummoningExpanded.Common.GlobalProjectiles {
    public class LongSentries : GlobalProjectile {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.sentry && ServerConfig.Instance.SentriesLastForever;

        public override void AI(Projectile projectile) {
            // Make sentries last forever 
            projectile.timeLeft = 2;

            // Make them die if their owner is too far away
            var owner = Main.player[projectile.owner];
            float maxDist = 500f * 16f * (float)ServerConfig.Instance.SentriesDespawnDistanceMultiplier;
            if (projectile.Center.DistanceSQ(owner.Center) > maxDist * maxDist) {
                projectile.Kill();
            }
        }
    }
}
