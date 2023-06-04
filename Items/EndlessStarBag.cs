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

namespace MythMod.Items
{
	// Token: 0x02000255 RID: 597
    public class EndlessStarBag : ModItem
	{
		// Token: 0x06000B03 RID: 2819 RVA: 0x000573AC File Offset: 0x000555AC
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("无尽星辰袋");
            // base.Tooltip.SetDefault("供应无限量的坠星作为弹药");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 22;
            base.Item.damage = -15;
			base.Item.height = 36;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.knockBack = 1.5f;
			base.Item.value = 50000;
			base.Item.rare = 3;
            base.Item.shoot = 12;
            base.Item.shootSpeed = 0;
            base.Item.ammo = AmmoID.FallenStar;
		}
        public override void AddRecipes()
        {
            {
                Recipe recipe = CreateRecipe(1);
                recipe.AddIngredient(null, "PureJelly", 3);
                recipe.AddIngredient(null, "BloodCryst", 3);
                recipe.AddIngredient(ItemID.FallenStar, 200);
                recipe.requiredTile[0] = 220;
                recipe.Register();
            }
        }
	}
    public class 改变 : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
        }	
    }
}
