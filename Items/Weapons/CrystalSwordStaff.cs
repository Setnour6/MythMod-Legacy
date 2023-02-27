using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class CrystalSwordStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰晶剑雨");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰晶剑雨");
        }
		public override void SetDefaults()
		{
			base.item.damage = 300;
			base.item.magic = true;
			base.item.mana = 50;
			base.item.width = 54;
			base.item.height = 54;
			base.item.useTime = 36;
			base.item.useAnimation = 36;
			base.item.useStyle = 5;
			Item.staff[base.item.type] = true;
			base.item.noMelee = true;
			base.item.knockBack = 5f;
			base.item.value = Item.sellPrice(0, 9, 0, 0);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item43;
			base.item.autoReuse = true;
            base.item.shoot = base.mod.ProjectileType("CrystalSwordStaff");
			base.item.shootSpeed = 0;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CrysSwo += 1;
            float shootSpeed = base.item.shootSpeed;
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY, 0, 0, (int)type, (int)damage, (float)knockBack, player.whoAmI, (float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY);
            return false;
        }
	}
}
