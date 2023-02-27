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
            base.DisplayName.SetDefault("无尽星辰袋");
            base.Tooltip.SetDefault("供应无限量的坠星作为弹药");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.ranged = true;
			base.item.width = 22;
            base.item.damage = -15;
			base.item.height = 36;
			base.item.maxStack = 1;
			base.item.consumable = false;
			base.item.knockBack = 1.5f;
			base.item.value = 50000;
			base.item.rare = 3;
            base.item.shoot = 12;
            base.item.shootSpeed = 0;
            base.item.ammo = AmmoID.FallenStar;
		}
        public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "PureJelly", 3);
                recipe.AddIngredient(null, "BloodCryst", 3);
                recipe.AddIngredient(ItemID.FallenStar, 200);
                recipe.SetResult(this, 1);
                recipe.requiredTile[0] = 220;
                recipe.AddRecipe();
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
