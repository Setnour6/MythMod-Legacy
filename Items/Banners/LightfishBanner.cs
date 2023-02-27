using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Banners
{
	// Token: 0x0200038F RID: 911
	public class LightfishBanner : ModItem
	{
				// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灯笼鱼Banner");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯笼鱼旗");
		}
		// Token: 0x06000FC6 RID: 4038 RVA: 0x00088C14 File Offset: 0x00086E14
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 28;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.rare = 1;
			base.item.value = Item.buyPrice(0, 0, 10, 0);
			base.item.createTile = base.mod.TileType("MonsterBanner");
			base.item.placeStyle = 5;
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(6f, 14f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Banners/灯笼鱼BannerGLOW"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
