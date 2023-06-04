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
    public class FrozenBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("冰霜弹");
            // base.Tooltip.SetDefault("有概率冻结敌人");
		}
		public override void SetDefaults()
		{
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 12;
            base.Item.damage = 42;
			base.Item.height = 12;
			base.Item.maxStack = 999;
			base.Item.consumable = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 30;
			base.Item.rare = 2;
            base.Item.shoot = Mod.Find<ModProjectile>("FrozenBullet").Type;
            base.Item.shootSpeed = 0;
            base.Item.ammo = AmmoID.Bullet;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(33);
            recipe.AddIngredient(97, 33);
            recipe.AddIngredient(Mod.Find<ModItem>("SoulOfFrozen").Type, 1);
            recipe.requiredTile[0] = 125;
            recipe.Register();
        }
    }
}
