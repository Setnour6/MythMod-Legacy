﻿using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items//制作是mod名字
{
    public class ThunderOre : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File OfIfset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("风暴猛烈对流喷发出的晶石");//教程是物品介绍
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.width = 40;//宽
            item.height = 40;//高
            item.rare = 24;//品质
            item.scale = 1f;//大小
            item.value = 10800;
            item.maxStack = 999;
            item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    ModRecipe recipe = new ModRecipe(mod);
                    recipe.AddIngredient(null, "ThunderOre", 4); //需要一个材料
                    recipe.requiredTile[0] = 412;
                    recipe.SetResult(mod.ItemType("ThunderBar"), 1); //制作一个武器
                    recipe.AddRecipe();
        }
    }
}
