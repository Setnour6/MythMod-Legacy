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
    public class BloodMixCrystalBulletBag : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("无尽灵液混杂水晶弹袋");
            // base.Tooltip.SetDefault("供应无限量的灵液弹混杂水晶弹作为弹药");
		}
		public override void SetDefaults()
		{
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 26;
            base.Item.damage = 19;
			base.Item.height = 34;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.knockBack = 1.5f;
			base.Item.value = 50000;
			base.Item.rare = 2;
            base.Item.shoot = 89;
            base.Item.shootSpeed = 0;
            base.Item.ammo = AmmoID.Bullet;
		}
        public override void UpdateInventory(Player player)
        {
            if (Main.rand.Next(100) >= 50)
            {
                Item.shoot = 279;
                Item.damage = 25;
            }
            else
            {
                Item.shoot = 89;
                Item.damage = 19;
            }
            base.UpdateInventory(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(1335, 1998);
            recipe.AddIngredient(515, 1998);
            recipe.requiredTile[0] = 125;
            recipe.Register();
        }
	}
}
