using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items.light
{
	public class BloodFlashlight : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灵液手电筒");
        }
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 12;
            item.maxStack = 99;
            item.flame = true;
            item.value = 50;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.SD != 12)
            {
                mplayer.SD = 12;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, mod.ProjectileType("BloodFlashlight"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1333, 3);
            recipe.AddIngredient(763, 15);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}