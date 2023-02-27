using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items.light
{
	public class Flashlight2 : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("手电筒");
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
            if(mplayer.SD != 17)
            {
                mplayer.SD = 17;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, mod.ProjectileType("Flashlight2"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(8, 3);
			recipe.AddIngredient(704, 15);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}