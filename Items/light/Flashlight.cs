using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items.light
{
	public class Flashlight : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("手电筒");
        }
        public override void SetDefaults()
		{
            Item.width = 42;
            Item.height = 42;
            Item.maxStack = 1;
            Item.flame = true;
            Item.value = 10000;
        }

		public override void HoldItem(Player player)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.SD != 1)
            {
                mplayer.SD = 1;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0f, Mod.Find<ModProjectile>("Flashlight").Type, 0, 0f, Main.myPlayer, 0f, 0f);
            }
            mplayer.SD2 = 2;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(8, 3);
			recipe.AddIngredient(22, 15);
			recipe.Register();
		}
	}
}