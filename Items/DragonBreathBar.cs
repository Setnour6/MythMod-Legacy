using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;

namespace MythMod.Items
{
    // Token: 0x0200034A RID: 842
    public class DragonBreathBar : ModItem
    {
        // Token: 0x06000D75 RID: 3445 RVA: 0x0006A410 File Offset: 0x00068610
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Abyss Bar");
            base.Tooltip.SetDefault("'Ocean deep……'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "龙息锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'摸起来有一种远古的震颤……'");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 30;
            base.item.height = 24;
            base.item.maxStack = 999;
            base.item.value = Item.sellPrice(0, 4, 80, 00);
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