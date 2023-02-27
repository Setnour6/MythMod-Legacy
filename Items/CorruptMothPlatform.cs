using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;
namespace MythMod.Items
{
	// Token: 0x02000212 RID: 530
    public class CorruptMothPlatform : ModItem
	{
		// Token: 0x060009BA RID: 2490 RVA: 0x00005A27 File Offset: 0x00003C27
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("StarAbyssJellyfish Trophy");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "腐檀巨蛾纪念章");
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x000500EC File Offset: 0x0004E2EC
		public override void SetDefaults()
		{
			base.item.width = 32;
            base.item.height = 32;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 50000;
			base.item.rare = 1;
			base.item.createTile = base.mod.TileType("BossTrophy");
			base.item.placeStyle = 1;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(16f, 16f);
            spriteBatch.Draw(base.mod.GetTexture("Items/腐檀巨蛾纪念章发光"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
