using SummoningExpanded.Content.Projectiles.Whips;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummoningExpanded.Content.Items.Whips {
    public class RopeWhip : ModItem {
        public override void SetStaticDefaults() {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("2 summon tag damage\nYour summons will focus tagged enemies");
        }

        public override void SetDefaults() {
            Item.DefaultToWhip(ModContent.ProjectileType<RopeWhipProjectile>(), 10, 1f, 6f, 35);

            Item.shootSpeed = 4;
            Item.rare = ItemRarityID.Blue;
            Item.channel = true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.Rope, 30)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool MeleePrefix() => true;
    }
}
