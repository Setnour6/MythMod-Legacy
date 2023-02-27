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
    public class LuChest2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Lu宝藏箱2");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
        }
        public override void SetDefaults()
        {
            base.item.width = 22;
            base.item.height = 22;
            base.item.maxStack = 99;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.value = 500;
            base.item.createTile = base.mod.TileType("Lu宝藏箱2");
        }
    }
}
