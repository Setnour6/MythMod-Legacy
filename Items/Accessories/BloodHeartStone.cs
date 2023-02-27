using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
	public class BloodHeartStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "血泵石");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "移动速度越快提升回血速度越多,伤害也越高\n神话");
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
            player.lifeRegen += (int)player.velocity.Length();
            player.magicDamage += player.velocity.Length() / 90f;
            player.meleeDamage += player.velocity.Length() / 90f;
            player.rangedDamage += player.velocity.Length() / 90f;
            player.minionDamage += player.velocity.Length() / 90f;
            player.thrownDamage += player.velocity.Length() / 90f;
        }
	}
}
