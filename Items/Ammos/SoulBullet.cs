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
    public class SoulBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("幽魂弹");
            base.Tooltip.SetDefault("强追踪性,有概率吸血");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.ranged = true;
			base.item.width = 12;
            base.item.damage = 28;
			base.item.height = 12;
			base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.knockBack = 1.5f;
			base.item.value = 30;
			base.item.rare = 2;
            base.item.shoot = mod.ProjectileType("SoulBullet");
            base.item.shootSpeed = 0;
            base.item.ammo = AmmoID.Bullet;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(97, 7);
            recipe.AddIngredient(1508, 1);
            recipe.SetResult(this, 7);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
    }
}
