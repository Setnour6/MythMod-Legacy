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
    public class NanoBulletBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("无尽纳米弹袋");
            base.Tooltip.SetDefault("供应无限量的纳米弹作为弹药");
		}
		public override void SetDefaults()
		{
			base.item.ranged = true;
			base.item.width = 26;
            base.item.damage = 19;
			base.item.height = 34;
			base.item.maxStack = 1;
			base.item.consumable = false;
			base.item.knockBack = 1.5f;
			base.item.value = 50000;
			base.item.rare = 2;
            base.item.shoot = 285;
            base.item.shootSpeed = 0;
            base.item.ammo = AmmoID.Bullet;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1350, 3996);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 125;
            recipe.AddRecipe();
        }
	}
}
