using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Ammos
{
    public class FiringArrowBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("无尽烈焰箭袋");
            base.Tooltip.SetDefault("供应无限量的烈焰箭作为弹药");
		}
		public override void SetDefaults()
		{
			base.item.ranged = true;
			base.item.width = 32;
            base.item.damage = 8;
            base.item.crit = 4;
            base.item.height = 32;
			base.item.maxStack = 1;
			base.item.consumable = false;
			base.item.knockBack = 1.5f;
			base.item.value = 50000;
			base.item.rare = 2;
            base.item.shoot = 2;
            base.item.shootSpeed = 4;
            base.item.ammo = AmmoID.Arrow;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(41, 3996);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 125;
            recipe.AddRecipe();
        }
        public override void UpdateInventory(Player player)
        {
            if(Main.mouseLeft)
            {
                //for(int y = 0;y < 1000;y++)
                //{
                    //if(Main.projectile[y].type == 2)
                    //{
                        //Main.projectile[y].noDropItem = true;
                    //}
                //}
            }
            base.UpdateInventory(player);
        }
    }
}
