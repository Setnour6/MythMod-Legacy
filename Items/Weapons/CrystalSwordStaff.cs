using System;
using Terraria;
using Terraria.DataStructures;
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
			base.Item.damage = 300;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 50;
			base.Item.width = 54;
			base.Item.height = 54;
			base.Item.useTime = 36;
			base.Item.useAnimation = 36;
			base.Item.useStyle = 5;
			Item.staff[base.Item.type] = true;
			base.Item.noMelee = true;
			base.Item.knockBack = 5f;
			base.Item.value = Item.sellPrice(0, 9, 0, 0);
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("CrystalSwordStaff").Type;
			base.Item.shootSpeed = 0;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CrysSwo += 1;
            float shootSpeed = base.Item.shootSpeed;
            Projectile.NewProjectile((float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY, 0, 0, (int)type, (int)damage, (float)knockBack, player.whoAmI, (float)Main.screenPosition.X + Main.mouseX, (float)Main.screenPosition.Y + Main.mouseY);
            return false;
        }
	}
}
