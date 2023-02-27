using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
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
	// Token: 0x0200067A RID: 1658
    public class XYSMChest2 : ModItem
	{
		// Token: 0x06001CC8 RID: 7368 RVA: 0x00009CA8 File Offset: 0x00007EA8
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("XYSM宝藏箱2");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x000B6510 File Offset: 0x000B4710
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
            base.Item.createTile = base.Mod.Find<ModTile>("XYSM宝藏箱2").Type;
		}

		// Token: 0x06001CCA RID: 7370 RVA: 0x000B65BC File Offset: 0x000B47BC
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(16f, 15f);
			spriteBatch.Draw(base.Mod.GetTexture("Items/XYSM宝藏箱Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
	}
}
