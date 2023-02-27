using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.Weapons.StarJellyFIsh
{
    public class TentacleBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("射出触手箭矢抽打敌人,下水加强");
            DisplayName.AddTranslation(GameCulture.Chinese, "渊灯魔触弓");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.ranged = true;
            item.width = 32;
            item.height = 50;
            item.useTime = 11;
            item.useAnimation = 11;
            item.damage = 168;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.crit = 24;
            item.value = 80000;
            item.scale = 1f;
            item.rare = 8;
            item.useStyle = 5;
            item.knockBack = 1;
            item.useAmmo = 40;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("PoisonArrow");
            item.shootSpeed = 0.02f;
            item.reuseDelay = 14;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                int i = Main.rand.Next(-5, 25);
                    if (i == 15)
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX * 0.24f, speedY * 0.24f, mod.ProjectileType("TouchArrow"), damage * 3, knockBack, player.whoAmI);
                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX * 0.2f, speedY * 0.2f, mod.ProjectileType("PoisonArrow"), damage, knockBack, player.whoAmI);
                    }
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 0.16f, speedY * 0.16f, mod.ProjectileType("PoisonArrow"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.damage = 274;
                base.item.useTime = 3;
                base.item.useAnimation = 3;
            }
            else
            {
                base.item.damage = 168;
                base.item.useTime = 11;
                base.item.useAnimation = 11;
            }
            return base.CanUseItem(player);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 4)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
    }
}
  