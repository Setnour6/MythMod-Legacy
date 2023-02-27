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
			base.item.damage = 0;
			base.item.mana = 0;
			base.item.width = 32;
			base.item.height = 32;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 1;
			base.item.noMelee = true;
			base.item.knockBack = 2.25f;
			base.item.value = 55000;
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item44;
			base.item.autoReuse = false;
			base.item.summon = true;
		}
		// Token: 0x06001304 RID: 4868 RVA: 0x0008B534 File Offset: 0x00089734
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return false;
		}
	}
}
