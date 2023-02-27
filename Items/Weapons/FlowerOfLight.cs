using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Weapons
{
    public class FlowerOfLight : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("光之花");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "光之花");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 42;
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
			base.Item.rare = 4;
			base.Item.UseSound = SoundID.Item43;
			base.Item.autoReuse = true;
            base.Item.shoot = base.Mod.Find<ModProjectile>("LightBubble").Type;
			base.Item.shootSpeed = 3f;
		}
        //public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        //{
            //float shootSpeed = base.item.shootSpeed;
            //Projectile.NewProjectile((float)position.X + speedX * 4, (float)position.Y + speedY * 4, (float)speedX, (float)speedY, (int)type, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            //return false;
        //}
	}
}
