using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;

namespace SummoningExpanded.Common.Configs {
    public class ServerConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static ServerConfig Instance;

        /* ================== */
        /*         QOL        */
        /* ================== */

        [Header("Quality of Life changes")]

        [Label("Summon weapons can crit")]
        [DefaultValue(true)]
        public bool SummonCrit { get; set; }

        [Label("Sentries last forever but despawn when you get too far away")]
        [Tooltip("This distance is 500 tiles as base")]
        [DefaultValue(true)]
        public bool SentriesLastForever { get; set; }

        [Label("Sentry max distance multiplier")]
        [Tooltip("This controls how far away you have to get before a sentry will despawn\nSetting this to 0.5 will set that distance to 250 tiles\nSetting this to 2 will set that distance to 1000 tiles")]
        [CustomModConfigItem(typeof(CustomFloatElement))]
        [Range(0f, 2f)]
        [Increment(0.05f)]
        [DefaultValue(1f)]
        public float SentriesDespawnDistanceMultiplier { get; set; }
    }

    public class CustomFloatElement : FloatElement {
        public CustomFloatElement() {
            ColorMethod = new Utils.ColorLerpMethod((percent) => new Color(255, 172, 28));
        }
    }
}
