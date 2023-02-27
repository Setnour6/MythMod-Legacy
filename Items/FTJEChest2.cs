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


namespace MythMod.Items
{
    public class FTJEChest2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("FTJE宝藏箱2");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
        }
        public override void SetDefaults()
        {
            base.Item.width = 22;
            base.Item.height = 22;
            base.Item.maxStack = 99;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.value = 500;
            base.Item.createTile = base.Mod.Find<ModTile>("FTJE宝藏箱2").Type;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(16f, 15f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/FTJE宝藏箱Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
