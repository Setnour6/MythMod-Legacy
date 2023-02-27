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

namespace MythMod.Items.Banners
{
	// Token: 0x0200038F RID: 911
	public class AlarmJellyfishBanner : ModItem
	{
				// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("警报水母Banner");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "警报水母旗");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
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
			base.item.placeStyle = 1;
		}
	}
}
