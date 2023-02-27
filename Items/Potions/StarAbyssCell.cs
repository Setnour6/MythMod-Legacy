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
            Item.glowMask = GetGlowMask;
            base.Item.width = 40;
            base.Item.height = 40;
            base.Item.rare = 8;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("星渊刺胞").Type;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.width = 13;
            base.Item.height = 10;
            base.Item.maxStack = 999;
            base.Item.value = 5000;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("StarPoisonBullet").Type, 20);
            recipe.AddIngredient(null, "StarAbyssCell", 1);
            recipe.AddIngredient(1432, 20);
            recipe.requiredTile[0] = 18;
            recipe.Register();
        }
    }
}
