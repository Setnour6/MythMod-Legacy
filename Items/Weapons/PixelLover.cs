using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class PixelLover : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("像素之恋");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 25;
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.useTime = 25;
            item.rare = 2;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 5.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = base.mod.ProjectileType("PixelLover");
            item.shootSpeed = 12f;
            item.crit = 4;
            item.value = 27000;
            item.scale = 1f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 10, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 1)
            {
                int num = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Pixel"), 0f, 0f, 0, default(Color), 1f);
                Main.dust[num].noGravity = true;
                Main.dust[num].velocity *= 0;
            }
            if (Main.rand.Next(2) == 1)
            {
                int num2 = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Pixel2"), 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0;
            }
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 100 / 255f, 100 / 255f, 255 / 255f);
        }
    }
}
