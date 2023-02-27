using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
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

            Item.damage = 42;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 104;
            Item.height = 104;
            Item.useTime = 40;
            Item.rare = 2;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 5.0f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 9;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("SkullPShoot").Type;
            Item.shootSpeed = 8f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(Item.width / 2f, Item.height / 2f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Weapons/荣耀之剑SkePGlow"), base.Item.Center - Main.screenPosition, null, new Color(255,255,255,0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 pc = player.position + new Vector2(player.width, player.height) / 2;
            Vector2 v = new Vector2(speedX, speedY);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * 2 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, Mod.Find<ModProjectile>("SkullPShoot").Type, (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * 1 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, Mod.Find<ModProjectile>("SkullPShoot").Type, (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * -2 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, Mod.Find<ModProjectile>("SkullPShoot").Type, (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY).RotatedBy(Math.PI * -1 / 15f * -player.direction);
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, Mod.Find<ModProjectile>("SkullPShoot").Type, (int)(damage * 0.6f), knockBack, player.whoAmI);
            v = new Vector2(speedX, speedY) * 2f;
            Projectile.NewProjectile(pc.X, pc.Y, v.X, v.Y, Mod.Find<ModProjectile>("SkullPBonbShoot").Type, (int)(damage * 1.4f), knockBack, player.whoAmI);
            return false;
        }
    }
}
