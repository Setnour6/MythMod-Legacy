using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.FestivalWeapons
{
	// Token: 0x020005C2 RID: 1474
    public class PtCoinStaff : ModItem
	{
		// Token: 0x060019F2 RID: 6642 RVA: 0x00008ED2 File Offset: 0x000070D2
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("铂金元宝法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铂金元宝法杖");
        }

		// Token: 0x060019F3 RID: 6643 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public override void SetDefaults()
		{
			base.Item.damage = 1666;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 9;
			base.Item.width = 66;
			base.Item.height = 66;
			base.Item.useTime = 16;
			base.Item.useAnimation = 16;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 9, 99, 99);
			base.Item.rare = 6;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("PtYuanbao").Type;
			base.Item.shootSpeed = 14f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY, 0, 9, base.Mod.Find<ModProjectile>("PtYuanbao").Type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        // Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
        public override void AddRecipes()
        {
        }
    }
}
