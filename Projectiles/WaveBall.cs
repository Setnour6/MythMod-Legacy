using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
    public class WaveBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("0†20„50†80‡90‡5¨°");
            Main.projFrames[Projectile.type] = 4;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 900;
            Projectile.scale = 1f;

        }
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 4 && Projectile.timeLeft % 3 == 0)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 3)
            {
                base.Projectile.frame = 0;
            }
            #region
            if (Projectile.timeLeft == 710) { Projectile.tileCollide = true; }
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            Projectile.light = 0.1f;
            #endregion
            if (Projectile.timeLeft % 2 == 0 && Projectile.timeLeft < 895)
            {
                int dustID = Dust.NewDust(Projectile.position, (int)(Projectile.width / 2f), (int)(Projectile.height / 2f), Mod.Find<ModDust>("Wave").Type, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 201, Color.White, 1.5f);/*¡¤0‰40…60†60ˆ4¡ì0†10‹40…50†30ˆ70‡10†10‰5*/
                int dustID2 = Dust.NewDust(Projectile.position, (int)(Projectile.width / 2f), (int)(Projectile.height / 2f), 56, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 201, Color.White, 1f);/*¡¤0‰40…60†60ˆ4¡ì0†10‹40…50†30ˆ70‡10†10‰5*/
                int dustID3 = Dust.NewDust(Projectile.position, (int)(Projectile.width / 2f), (int)(Projectile.height / 2f), Mod.Find<ModDust>("Wave").Type, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 201, Color.White, 1f);/*¡¤0‰40…60†60ˆ4¡ì0†10‹40…50†30ˆ70‡10†10‰5*/
                Main.dust[dustID].noGravity = true;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.36f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
            base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
            base.Projectile.width = 40;
            base.Projectile.height = 40;
            base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
            base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
            for (int j = 0; j < 90; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave").Type, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num2].velocity.X = (float)(4f * Math.Sin(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.99f,1.01f);
                Main.dust[num2].velocity.Y = (float)(4f * Math.Cos(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(0.99f, 1.01f);
            }
            for (int j = 0; j < 90; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave2").Type, 0f, 0f, 100, default(Color), 6f);
                Main.dust[num2].velocity.X = (float)(4f * Math.Sin(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(1f, 1.1f);
                Main.dust[num2].velocity.Y = (float)(4f * Math.Cos(Math.PI * (float)(j) / 45f)) * Main.rand.NextFloat(1f, 1.1f);
            }
            for (int j = 0; j < 60; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave").Type, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num2].velocity.X = (float)(2.4f * Math.Sin(Math.PI * (float)(j) / 30f)) * Main.rand.NextFloat(0.99f, 1.01f);
                Main.dust[num2].velocity.Y = (float)(2.4f * Math.Cos(Math.PI * (float)(j) / 30f)) * Main.rand.NextFloat(0.99f, 1.01f);
            }
            for (int j = 0; j < 60; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave2").Type, 0f, 0f, 100, default(Color), 3f);
                Main.dust[num2].velocity.X = (float)(2.4f * Math.Sin(Math.PI * (float)(j) / 30f)) * Main.rand.NextFloat(1f, 1.1f);
                Main.dust[num2].velocity.Y = (float)(2.4f * Math.Cos(Math.PI * (float)(j) / 30f)) * Main.rand.NextFloat(1f, 1.1f);
            }
            for (int j = 0; j < 30; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave").Type, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num2].velocity.X = (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)) * Main.rand.NextFloat(0.99f, 1.01f);
                Main.dust[num2].velocity.Y = (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)) * Main.rand.NextFloat(0.99f, 1.01f);
            }
            for (int j = 0; j < 30; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), 0, 0, Mod.Find<ModDust>("Wave2").Type, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num2].velocity.X = (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)) * Main.rand.NextFloat(1f, 1.1f);
                Main.dust[num2].velocity.Y = (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)) * Main.rand.NextFloat(1f, 1.1f);
            }
            for (int j = 0; j < 200; j++)
            {
                if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - Projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                {
                    Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - Projectile.Center).Length(), (int)((Main.npc[j].Center.X - Projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - Projectile.Center.X)));
                }
            }
        }
    }
}
