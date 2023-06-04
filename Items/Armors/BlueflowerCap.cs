using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Armors
{
	[AutoloadEquip(new EquipType[]
	{
        0
	})]
	public class BlueflowerCap : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "阔边蓝花帽子");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "时装物品");
		}
        public override void SetDefaults()
        {
            base.Item.width = 18;
            base.Item.height = 18;
            base.Item.value = Item.buyPrice(0, 1, 0, 0);
            base.Item.rare = 11;
        }
        public override void ArmorSetShadows(Player player)
        {
            //player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)/* tModPorter Note: Removed. In SetStaticDefaults, use ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true if you had drawHair set to true, and ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true if you had drawAltHair set to true */
        {
            base.DrawHair(ref drawHair, ref drawAltHair);
            drawHair = true;
        }
    }
}
