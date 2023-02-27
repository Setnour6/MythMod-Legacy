using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Potions
{
    public class StarAbyssCell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("星渊刺胞");
            Tooltip.SetDefault("1g足以杀死一万个成年男子");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 40;
            base.item.height = 40;
            base.item.rare = 8;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("星渊刺胞");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.width = 13;
            base.item.height = 10;
            base.item.maxStack = 999;
            base.item.value = 5000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarAbyssCell", 1);
            recipe.AddIngredient(1432, 20);
            recipe.requiredTile[0] = 18;
            recipe.SetResult(mod.ItemType("StarPoisonBullet"), 20);
            recipe.AddRecipe();
        }
    }
}
