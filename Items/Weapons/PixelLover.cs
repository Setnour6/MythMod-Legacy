using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
            Item.glowMask = GetGlowMask;
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 25;
            Item.rare = 2;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 5.0f ;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = base.Mod.Find<ModProjectile>("PixelLover").Type;
            Item.shootSpeed = 12f;
            Item.crit = 4;
            Item.value = 27000;
            Item.scale = 1f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage * 10, knockBack, Main.myPlayer, 0f, 0f);
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 1)
            {
                int num = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("Pixel").Type, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num].noGravity = true;
                Main.dust[num].velocity *= 0;
            }
            if (Main.rand.Next(2) == 1)
            {
                int num2 = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("Pixel2").Type, 0f, 0f, 0, default(Color), 1.6f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0;
            }
            Lighting.AddLight(new Vector2((float) hitbox.X, (float) hitbox.Y), 100 / 255f, 100 / 255f, 255 / 255f);
        }
    }
}
