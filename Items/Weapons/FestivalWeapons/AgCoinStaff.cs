using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class AgCoinStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("银元宝法杖");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "银元宝法杖");
        }
		public override void SetDefaults()
		{
			base.Item.damage = 116;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 9;
			base.Item.width = 66;
			base.Item.height = 66;
			base.Item.useTime = 20;
			base.Item.useAnimation = 20;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 0, 99, 99);
			base.Item.rare = 4;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("AgYuanbao").Type;
			base.Item.shootSpeed = 13f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)position.Y - 1000f, 0, 4, base.Mod.Find<ModProjectile>("AgYuanbao").Type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        // Token: 0x060019F4 RID: 6644 RVA: 0x000A89D8 File Offset: 0x000A6BD8
        public override void AddRecipes()
        {
        }
    }
}
