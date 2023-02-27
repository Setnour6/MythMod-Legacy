using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class CurseflameScale : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "咒火鳞");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 26;
			base.item.height = 22;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 2, 50, 0);
			base.item.rare = 6;
		}
    }
}


