using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	// Token: 0x0200052F RID: 1327
    public class AmbiguousNight : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("幻夜弹弓");
            base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
			base.item.damage = 55;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 40;
			base.item.height = 40;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = true;
			base.item.value = Item.sellPrice(0, 0, 10, 0);
			base.item.rare = 4;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = 51;
			base.item.shootSpeed = 15f;
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00003B08 File Offset: 0x00001D08
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {//合成表1
        }
	}
}
