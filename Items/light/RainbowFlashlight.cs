using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items.light
{
	public class RainbowFlashlight : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("彩虹手电筒");
        }
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.maxStack = 1;
            item.flame = true;
            item.value = 10000;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 15)
            {
                mplayer.SD = 15;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, mod.ProjectileType("RainbowFlashlight"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3045, 3);
            recipe.AddIngredient(662, 15);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}