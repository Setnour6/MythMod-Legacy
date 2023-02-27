using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod/*modÃû*/.Projectiles
{
    public class Phosphorescence : ModProjectile
    {
        // Brought to you with <3 by Gorateron
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Á×¹â");//½éÉÜ
            Main.projFrames[Projectile.type] = 4; /*¡¾Ö¡ÊýÎª6¡¿¶ÔÓ¦µÄÌùÍ¼Ò²Òª»­6Ö¡Å¶*/

        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;//ÓÑºÃ
            Projectile.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;//½üÕ½
            Projectile.ignoreWater = true;//²»±»Ë®Ó°Ïì
            Projectile.tileCollide = false;//ÄÜ´©Ç½£¬·´ÒåÎªfalse
            Projectile.timeLeft = 1800;//´æÔÚÊ±¼ä£¬60ÊÇ1Ãë
            Projectile.scale = 1f;//´óÐ¡
            Projectile.alpha = 140;//´óÐ¡
            Projectile.extraUpdates = (int)3f;

        }
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 4)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 3)
            {
                base.Projectile.frame = 0;
            }
            if (Main.rand.Next(1, 3) == 1)
            {
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 15, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num].velocity *= 0.5f;
                Main.dust[num].noGravity = true;
            }
                int num1 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 172, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
                Main.dust[num1].velocity *= 0f;
                Main.dust[num1].noGravity = true;
            #region
            if (Projectile.timeLeft == 710) { Projectile.tileCollide = true; }//µ±ÄãµÄÌØÐ§´æÔÚ710ìõÊ±£¬²»ÄÜ´©Ç½
            Projectile.light = 0.1f;//·¢¹â//0Îª²»·¢¹â
            Vector2 pc = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2;//ÈÃÄãµÄÌØÐ§Õý³£»¯
            Projectile.light = 0.1f;//·¢¹â
            #endregion
            if (Main.rand.Next(2) == 0)
            {
                base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 2f);
                base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 2f);
            }
            else
            {
                base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 2f);
                base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 2f);
            }
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
            base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
            base.Projectile.width = 160;
            base.Projectile.height = 160;
            base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
            base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
        }
    }
}
