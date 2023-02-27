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
    public class PearlBulletBag : ModItem
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("无尽珍珠弹袋");
            base.Tooltip.SetDefault("供应无限量的珍珠弹作为弹药");
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
            base.Item.shoot = Mod.Find<ModProjectile>("珍珠弹").Type;
            base.Item.shootSpeed = 0;
            base.Item.ammo = AmmoID.Bullet;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("PearlBullet").Type, 3996);
            recipe.requiredTile[0] = 125;
            recipe.Register();
        }
	}
}
