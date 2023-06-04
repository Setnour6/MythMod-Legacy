using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.Shields
{
    public class OceanCrystalShield : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("魔晶甲壳");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 30;
            base.Projectile.height = 30;
            base.Projectile.friendly = false;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 2;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
            base.Projectile.tileCollide = false;
        }
        private int D = 0;
        private int lazarCo = 0;
        private float num4;
        private Vector2 vector3;
        private float Distance;
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Projectile.frame = (int)((24 - Projectile.timeLeft) / 2f);
            Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - p.Center;
            v = v / v.Length();
            Projectile.velocity = v * 15f;
            Projectile.position = p.Center + v - new Vector2(15, 15);
            Projectile.spriteDirection = p.direction;
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y * p.direction, (double)base.Projectile.velocity.X * p.direction) + (float)Math.PI / 4f * Projectile.spriteDirection;
            if(mplayer.SD2 > 0 && mplayer.SD == 5)
            {
                base.Projectile.timeLeft = 2;
            }
            p.ChangeDir(base.Projectile.direction);
            p.heldProj = base.Projectile.whoAmI;
            //p.direction = projectile.spriteDirection;
            for(int i = 0;i < 1000;i++)
            {
                if(Main.projectile[i].hostile)
                {
                    if(Math.Abs(Math.Atan2((Main.projectile[i].Center - p.Center).X, (Main.projectile[i].Center - p.Center).Y) - Math.Atan2((Projectile.Center - p.Center).X, (Projectile.Center - p.Center).Y)) < 0.8)
                    {
                        if ((Main.projectile[i].Center + Main.projectile[i].velocity - p.Center).Length() > 0 && (Main.projectile[i].Center + Main.projectile[i].velocity - p.Center).Length() <= 48)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                }
            }
            Player player = Main.player[Main.myPlayer];
            if(Main.mouseLeft && lazarCo == 0)
            {
                lazarCo = 240;
                int num = Projectile.NewProjectile(player.Center.X + Projectile.velocity.X * 4f, player.Center.Y + Projectile.velocity.Y * 4f, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("OceanRay").Type, 150, 2, player.whoAmI, 0f, 0f);
                Main.projectile[num].hostile = false;
                Main.projectile[num].friendly = true;
            }
            if(lazarCo > 0)
            {
                lazarCo -= 1;
            }
            else
            {
                lazarCo = 0;
            }
        }
        public override void PostDraw(Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/Shields/OceanCrystalShieldGlow"), base.Projectile.Center - Main.screenPosition, null, new Color((240 - lazarCo) / 240f, (240 - lazarCo) / 240f, (240 - lazarCo) / 240f, 0), Projectile.rotation, new Vector2(15f, 15f), 1f, effects, 0f);
        }
    }
}
