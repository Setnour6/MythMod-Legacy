using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
	// Token: 0x020005C2 RID: 1474
    public class ThunderFlower : ModItem
	{
		// Token: 0x060019F2 RID: 6642 RVA: 0x00008ED2 File Offset: 0x000070D2
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("雷之花");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "雷之花");
		}

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public override void SetDefaults()
		{
			base.Item.damage = 70;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 15;
			base.Item.width = 58;
			base.Item.height = 68;
			base.Item.useTime = 26;
			base.Item.useAnimation = 26;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 2, 0, 0);
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("ThunderBall").Type;
			base.Item.shootSpeed = 3f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float shootSpeed = base.Item.shootSpeed;
            Projectile.NewProjectile((float)position.X + speedX * 4, (float)position.Y + speedY * 4, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
	}
}
