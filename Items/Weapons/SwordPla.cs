using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons//制作是mod名字
{
    public class SwordPla : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("荣耀之剑·世纪之花");
            base.Tooltip.SetDefault("你的实力已经碾压了世纪之花，这把属于你的剑里面封印了它的灵魂");
        }
        public override void SetDefaults()
        {
            item.damage = 70;
            item.melee = true;
            item.width = 54;
            item.height = 54;
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
            item.shoot = mod.ProjectileType("GreenThornBalll");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int uit = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GreenThornBalll"), damage, knockBack, Main.myPlayer, 0f, 0f);
            Main.projectile[uit].hostile = false;
            Main.projectile[uit].friendly = true;
            return false;
        }
    }
}
