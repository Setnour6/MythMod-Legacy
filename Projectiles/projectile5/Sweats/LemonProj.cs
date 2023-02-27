using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile5.Sweats
{
    public class LemonProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("柠檬糖");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = 200;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 995)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 191, 50f, 50f, 0, default(Color), (float)projectile.scale * 1.2f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
            if(projectile.velocity.Y < 15)
            {
                projectile.velocity.Y += 0.01f;
            }
            Lighting.AddLight(projectile.Center, -1, -1, -1);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            if(projectile.ai[0] == 1)
            {
                Vector2 v = projectile.velocity;
                for(int i = 0;i < 8;i++)
                {
                    Vector2 v2 = v.RotatedBy(Math.PI / 4d * (double)i);
                    int y = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v2.X, v2.Y, base.mod.ProjectileType("LemonStaff"), (int)(projectile.damage * 0.8f), 0, player.whoAmI, -1, 0f);
                }
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 150));
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.penetrate--;
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                base.projectile.ai[0] += 0.1f;
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = -oldVelocity.X * 0.25f;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y * 0.25f;
                }
            }
            return false;
        }
    }
}