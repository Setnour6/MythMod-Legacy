using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
namespace MythMod.Items.Weapons.FestivalWeapons
{ 
    public class OrangeBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.SetDefault("桔之锋");
        }
        public override void SetDefaults()
        {
            item.damage = 420;
            item.melee = true;
            item.width = 62;
            item.height = 76;
            item.useTime = 60;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 8;
            item.value = 100000;
            item.rare = 11;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("TangerineBlade");
            item.shootSpeed = 4f;

        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if(Main.rand.Next(15) == 1)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(hitbox.X + Main.rand.NextFloat(hitbox.Width), hitbox.Y + Main.rand.NextFloat(hitbox.Height), v.X, v.Y, mod.ProjectileType("Tangerine2"), (int)(item.damage), base.item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
            if (Main.rand.Next(5) == 1)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(hitbox.X + Main.rand.NextFloat(hitbox.Width), hitbox.Y + Main.rand.NextFloat(hitbox.Height), v.X, v.Y, mod.ProjectileType("TangerineLeaf"), (int)(item.damage), base.item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
    }
}
