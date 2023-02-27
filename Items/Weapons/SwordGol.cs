using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordGol : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·石巨人");
            base.Tooltip.SetDefault("你的实力已经碾压了石巨人，这把属于你的剑里面封印了它的灵魂");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 77;
            item.melee = true;
            item.width = 52;
            item.height = 52;
            item.useTime = 48;
            item.rare = 2;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 4.0f ;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 9;
            item.value = 10000;
            item.scale = 1f;
            item.shootSpeed = 9;
            item.shoot = 259;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int sag = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 259, damage, knockBack, Main.myPlayer, 0f, 0f);
            Main.projectile[sag].hostile = false;
            Main.projectile[sag].friendly = true;
            return false;
        }
    }
}
