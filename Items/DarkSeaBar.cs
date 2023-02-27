using Terraria.ID;
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
namespace MythMod.Items
{
    public class DarkSeaBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Abyss Bar");
            base.Tooltip.SetDefault("'Ocean deep……'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "渊海锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'深海之下……'");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 20;
            base.item.height = 20;
            base.item.maxStack = 999;
            base.item.value = Item.sellPrice(0, 3, 20, 00);
            base.item.rare = 11;
            base.item.autoReuse = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.createTile = base.mod.TileType("Bars");
            base.item.placeStyle = 1;
        }
    }
}