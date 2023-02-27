using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class BoneKiller : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "化骨水");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "让怪物和自己同时失去防御\n神话");
		}
		public override void SetDefaults()
		{
			base.item.width = 18;
			base.item.height = 18;
			base.item.value = 0;
			base.item.accessory = true;
            base.item.rare = 7;
        }
        private int WetIndex = 0;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.KiBo = 2;
            player.statDefense *= 0;
        }
	}
}
