using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Sky
{
    public class WindFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.AddTranslation(GameCulture.Chinese, "风之碎片");
		}
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 24;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 2, 50, 0);
			base.item.rare = 11;
		}
    }
}


