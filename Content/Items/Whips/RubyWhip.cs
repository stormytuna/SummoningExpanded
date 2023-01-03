using SummoningExpanded.Content.Projectiles.Whips;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SummoningExpanded.Content.Items.Whips {
    public class RubyWhip : ModItem {
        public override void SetStaticDefaults() {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("3 summon tag damage\nYour summons will focus tagged enemies");
        }

        public override void SetDefaults() {
            Item.DefaultToWhip(ModContent.ProjectileType<RubyWhipProjectile>(), 12, 1f, 4f);

            Item.rare = ItemRarityID.Blue;
            Item.channel = true;
        }

        public override void AddRecipes() {
            CreateRecipe()
                .AddIngredient(ItemID.Ruby, 15)
                .AddIngredient(ItemID.PlatinumBar, 10)
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Ruby, 15)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool MeleePrefix() => true;
    }
}
