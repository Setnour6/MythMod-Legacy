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
	public class SoulLanternBanner : ModItem
	{
				// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灯笼幽灵Banner");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯笼幽灵旗");
		}
		// Token: 0x06000FC6 RID: 4038 RVA: 0x00088C14 File Offset: 0x00086E14
		public override void SetDefaults()
		{
			base.item.width = 10;
			base.item.height = 24;
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
			base.item.placeStyle = 11;
		}
	}
}
