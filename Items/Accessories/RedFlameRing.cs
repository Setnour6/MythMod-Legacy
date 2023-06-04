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
namespace MythMod.Items.Accessories
{
	// Token: 0x02000156 RID: 342
	public class RedFlameRing : ModItem
	{
		// Token: 0x060005CF RID: 1487 RVA: 0x0004F58C File Offset: 0x0004D78C
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("赤炼魔戒");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "赤炼魔戒");
            // Tooltip.SetDefault("免疫火山熔岩造成的秒杀");//教程是物品介绍
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0004F5E4 File Offset: 0x0004D7E4
		public override void SetDefaults()
		{
			base.Item.width = 42;
			base.Item.height = 32;
            base.Item.rare = 11;
            base.Item.value = 100000;
			base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.lavaI = 2;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Accessories/赤炼魔戒Glow"), base.Item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
