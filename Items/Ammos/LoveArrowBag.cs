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
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;

namespace MythMod.Items.Ammos
{
    public class LoveArrowBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("无尽爱心箭袋");
            // base.Tooltip.SetDefault("供应无限量的爱心箭作为弹药");
		}
		public override void SetDefaults()
		{
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 32;
            base.Item.damage = 13;
            base.Item.crit = 4;
            base.Item.height = 32;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.knockBack = 1.5f;
			base.Item.value = 50000;
			base.Item.rare = 2;
            base.Item.shoot = base.Mod.Find<ModProjectile>("HeartArrow").Type;
            base.Item.shootSpeed = 4;
            base.Item.ammo = AmmoID.Arrow;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("LoveArrow").Type, 3996);
            recipe.requiredTile[0] = 125;
            recipe.Register();
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
