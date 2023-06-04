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
    public class PearlBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("珍珠弹");
            // base.Tooltip.SetDefault("随机分裂");
		}
		public override void SetDefaults()
		{
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 12;
            base.Item.damage = 20;
			base.Item.height = 12;
			base.Item.maxStack = 999;
			base.Item.consumable = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 30;
			base.Item.rare = 2;
            base.Item.shoot = Mod.Find<ModProjectile>("珍珠弹").Type;
            base.Item.shootSpeed = 0;
            base.Item.ammo = AmmoID.Bullet;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(33);
            recipe.AddIngredient(97, 33);
            recipe.AddIngredient(Mod.Find<ModItem>("Pearl").Type, 1);
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
