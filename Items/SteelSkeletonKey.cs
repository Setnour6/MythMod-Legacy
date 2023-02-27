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

namespace MythMod.Items
{
	// Token: 0x020003E0 RID: 992
    public class SteelSkeletonKey : ModItem
	{
		// Token: 0x06001301 RID: 4865 RVA: 0x0008B390 File Offset: 0x00089590
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("机械骷髅钥匙");
			base.Tooltip.SetDefault("别再问了……");
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x0008B3E8 File Offset: 0x000895E8
		public override void SetDefaults()
		{
			base.Item.damage = 0;
			base.Item.mana = 0;
			base.Item.width = 32;
			base.Item.height = 32;
			base.Item.useTime = 36;
			base.Item.useAnimation = 36;
			base.Item.useStyle = 1;
			base.Item.noMelee = true;
			base.Item.knockBack = 2.25f;
			base.Item.value = 55000;
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item44;
			base.Item.autoReuse = false;
			base.Item.DamageType = DamageClass.Summon;
		}
		// Token: 0x06001304 RID: 4868 RVA: 0x0008B534 File Offset: 0x00089734
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return false;
		}
	}
}
