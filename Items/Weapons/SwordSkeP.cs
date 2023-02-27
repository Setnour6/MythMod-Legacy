using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class SwordSkeP : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·机械骷髅王");
            base.Tooltip.SetDefault("你的实力已经碾压了机械骷髅王，这把属于你的剑里面封印了它的灵魂");
        }
        public override void SetDefaults()
        {

            item.damage = 42;
            item.melee = true;
            item.width = 104;
            item.height = 104;
            item.useTime = 40;
            item.rare = 2;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 5.0f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 9;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("SkullPShoot");
            item.shootSpeed = 8f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/荣耀之剑SkePGlow"), base.item.Center - Main.screenPosition, null, new Color(255,255,255,0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pc = player.position + new Vector2(player.width, player.height) / 2;
            Vector2 v = new Vector2(speedX, speedY);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * 2 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, mod.ProjectileType("SkullPShoot"), (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * 1 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, mod.ProjectileType("SkullPShoot"), (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * -2 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, mod.ProjectileType("SkullPShoot"), (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * -1 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, mod.ProjectileType("SkullPShoot"), (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY) * 2f;
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, mod.ProjectileType("SkullPBonbShoot"), (int)(damage * 1.4f), knockBack, player.whoAmI);
            return false;
        }
    }
}
