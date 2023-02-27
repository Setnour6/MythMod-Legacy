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
			base.Item.width = 18;
			base.Item.height = 18;
			base.Item.value = 0;
			base.Item.accessory = true;
            base.Item.rare = 7;
        }
        private int WetIndex = 0;
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.lifeRegen += (int)player.velocity.Length();
            player.GetDamage(DamageClass.Magic) += player.velocity.Length() / 90f;
            player.GetDamage(DamageClass.Melee) += player.velocity.Length() / 90f;
            player.GetDamage(DamageClass.Ranged) += player.velocity.Length() / 90f;
            player.GetDamage(DamageClass.Summon) += player.velocity.Length() / 90f;
            player.GetDamage(DamageClass.Throwing) += player.velocity.Length() / 90f;
        }
	}
}
