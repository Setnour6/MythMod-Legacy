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
namespace MythMod.Projectiles.projectile3
{
    public class CrystalSwordStaff : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("冰晶石剑影");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 3000;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 0.5f;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b = 0;
        public override void AI()
        {
            b += 1;
            Vector2 vg = new Vector2(projectile.ai[0], projectile.ai[1]);
            Vector2 v2g = new Vector2(0, 220).RotatedBy(b / 15d);
            Vector2 v4g = new Vector2(0, 220).RotatedBy(b / 15d + Math.PI * 2d / 3d);
            Vector2 v5g = new Vector2(0, 220).RotatedBy(b / 15d + Math.PI * 4d / 3d);
            Vector2 v3g = vg + new Vector2(v2g.X, v2g.Y / 4f);
            if (projectile.timeLeft > 120)
            {
                int numl = Dust.NewDust(vg + new Vector2(v2g.X, v2g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f);
                Main.dust[numl].velocity *= 0;
                Main.dust[numl].noGravity = true;
                int numl2 = Dust.NewDust(vg + new Vector2(v4g.X, v4g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f);
                Main.dust[numl2].velocity *= 0;
                Main.dust[numl2].noGravity = true;
                int numl3 = Dust.NewDust(vg + new Vector2(v5g.X, v5g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f);
                Main.dust[numl3].velocity *= 0;
                Main.dust[numl3].noGravity = true;
            }
            else
            {
                float pg = projectile.timeLeft / 120f;
                int numl = Dust.NewDust(vg + new Vector2(v2g.X, v2g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f * pg);
                Main.dust[numl].velocity *= 0;
                Main.dust[numl].noGravity = true;
                int numl2 = Dust.NewDust(vg + new Vector2(v4g.X, v4g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f * pg);
                Main.dust[numl2].velocity *= 0;
                Main.dust[numl2].noGravity = true;
                int numl3 = Dust.NewDust(vg + new Vector2(v5g.X, v5g.Y / 4f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f * pg);
                Main.dust[numl3].velocity *= 0;
                Main.dust[numl3].noGravity = true;
            }
            if (projectile.timeLeft % 10 == 0)
            {
                float o = Main.rand.NextFloat(0, 1f);
                Projectile.NewProjectile((vg + v2g * o).X, (vg + v2g * o).Y, 0, 0.01f, base.mod.ProjectileType("CrystalSword11"), projectile.damage, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
            }
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.CrysSwo > 2)
            {
                int Tl = 3000;
                int k = 0;
                for (int y = 0;y < 1000;y++)
                {
                    if(Main.projectile[y].type == mod.ProjectileType("CrystalSwordStaff"))
                    {
                        if(Main.projectile[y].timeLeft < Tl)
                        {
                            Tl = Main.projectile[y].timeLeft;
                            k = y;
                        }
                    }
                }
                Main.projectile[k].Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CrysSwo -= 1;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            return false;
        }
    }
}