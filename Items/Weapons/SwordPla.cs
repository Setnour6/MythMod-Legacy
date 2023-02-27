using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 54;
            Item.useTime = 48;
            Item.rare = 2;
            Item.useAnimation = 24;
            Item.useStyle = 1;
            Item.knockBack = 4.0f ;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 9;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shootSpeed = 9;
            Item.shoot = Mod.Find<ModProjectile>("GreenThornBalll").Type;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int uit = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("GreenThornBalll").Type, damage, knockBack, Main.myPlayer, 0f, 0f);
            Main.projectile[uit].hostile = false;
            Main.projectile[uit].friendly = true;
            return false;
        }
    }
}
