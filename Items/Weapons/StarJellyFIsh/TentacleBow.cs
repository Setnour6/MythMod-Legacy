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
            // Tooltip.SetDefault("射出触手箭矢抽打敌人,下水加强");
            DisplayName.AddTranslation(GameCulture.Chinese, "渊灯魔触弓");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 50;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.damage = 168;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.crit = 24;
            Item.value = 80000;
            Item.scale = 1f;
            Item.rare = 8;
            Item.useStyle = 5;
            Item.knockBack = 1;
            Item.useAmmo = 40;
            Item.noMelee = true;
            Item.shoot = Mod.Find<ModProjectile>("PoisonArrow").Type;
            Item.shootSpeed = 0.02f;
            Item.reuseDelay = 14;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                int i = Main.rand.Next(-5, 25);
                    if (i == 15)
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX * 0.24f, speedY * 0.24f, Mod.Find<ModProjectile>("TouchArrow").Type, damage * 3, knockBack, player.whoAmI);
                    }
                    else
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX * 0.2f, speedY * 0.2f, Mod.Find<ModProjectile>("PoisonArrow").Type, damage, knockBack, player.whoAmI);
                    }
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 0.16f, speedY * 0.16f, Mod.Find<ModProjectile>("PoisonArrow").Type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.damage = 274;
                base.Item.useTime = 3;
                base.Item.useAnimation = 3;
            }
            else
            {
                base.Item.damage = 168;
                base.Item.useTime = 11;
                base.Item.useAnimation = 11;
            }
            return base.CanUseItem(player);
        }
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 4)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
    }
}
  