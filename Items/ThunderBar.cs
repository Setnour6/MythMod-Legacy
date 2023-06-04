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
    // Token: 0x02000719 RID: 1817
    public class ThunderBar : ModItem
    {
        // Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("123");
            // base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "云雷锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'带有大量电荷'");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 20;
            base.Item.height = 20;
            base.Item.maxStack = 999;
            base.Item.value = Item.sellPrice(0, 9, 45, 0);
            base.Item.rare = 10;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
            base.Item.placeStyle = 7;
        }
    }
}


