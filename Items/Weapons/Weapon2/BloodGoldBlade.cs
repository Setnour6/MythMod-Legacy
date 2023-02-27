using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;
namespace MythMod.Items.Weapons.Weapon2
{
    public class BloodGoldBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodGoldBlade");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "暗金屠杀刃");
        }
        public override void SetDefaults()
        {
            item.damage = 72;
            item.melee = true;
            item.width = 40;
            item.height = 46;
            item.useTime = 14;
            item.rare = 6;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 3;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("BloodGoldShader");
            item.shootSpeed = 8f;
        }

        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 pc = player.position + new Vector2(player.width, player.height) / 2;
            Projectile.NewProjectile(pc.X, pc.Y, 0, 0, mod.ProjectileType("BloodGoldShader"), 0, 0, player.whoAmI);
            Projectile.NewProjectile(pc.X, pc.Y, 0, 0, mod.ProjectileType("BloodGoldShader2"), 0, 0, player.whoAmI);
            Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 100f)).RotatedByRandom(MathHelper.TwoPi);
            Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, mod.ProjectileType("BloodGold"), item.damage * 2, item.knockBack, Main.myPlayer, player.direction, 0f);
            return false;
        }
    }
}
