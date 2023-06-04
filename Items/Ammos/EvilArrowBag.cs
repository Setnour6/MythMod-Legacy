﻿using Terraria.ModLoader.IO;
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
    public class EvilArrowBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("无尽邪箭袋");
            // base.Tooltip.SetDefault("供应无限量的邪箭作为弹药");
		}
		public override void SetDefaults()
		{
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 32;
            base.Item.damage = 14;
            base.Item.crit = 4;
            base.Item.height = 32;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.knockBack = 1.5f;
			base.Item.value = 50000;
			base.Item.rare = 2;
            base.Item.shoot = 4;
            base.Item.shootSpeed = 4;
            base.Item.ammo = AmmoID.Arrow;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(47, 3996);
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
