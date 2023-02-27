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
    public class StarPoisonArrowBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("无尽星渊毒素箭袋");
            base.Tooltip.SetDefault("供应无限量的渊毒素箭作为弹药");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.ranged = true;
			base.item.width = 32;
            base.item.damage = 19;
            base.item.crit = 4;
            base.item.height = 32;
			base.item.maxStack = 1;
			base.item.consumable = false;
			base.item.knockBack = 1.5f;
			base.item.value = 50000;
			base.item.rare = 7;
            base.item.shoot = mod.ProjectileType("StarPoisonArrow");
            base.item.shootSpeed = 2;
            base.item.ammo = AmmoID.Arrow;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("StarPoisonArrow"), 3996);
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
