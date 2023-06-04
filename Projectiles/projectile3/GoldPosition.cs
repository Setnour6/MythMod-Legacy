using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class GoldPosition : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("金相");
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 62;
            base.Projectile.height = 62;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            Projectile.alpha = 255;
            base.Projectile.extraUpdates = 2;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            if(Projectile.alpha > 5)
            {
                Projectile.alpha -= 5;
            }
            int num10 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity + base.Projectile.velocity.RotatedBy(Math.PI / 2d) * 0.2f * Math.Abs(12 - (Projectile.timeLeft % 24)), 4, 4, 64, 0f, 0f, 100, default(Color), 1.7f);
            Main.dust[num10].noGravity = true;
            Main.dust[num10].velocity *= 0.2f;
            int num11 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity + base.Projectile.velocity.RotatedBy(-Math.PI / 2d) * 0.2f * Math.Abs(12 - (Projectile.timeLeft % 24)), 4, 4, 64, 0f, 0f, 100, default(Color), 1.7f);
            Main.dust[num11].noGravity = true;
            Main.dust[num11].velocity *= 0.2f;
            if(Projectile.timeLeft % 12 == 0)
            {
                for (int p = 0; p < 10; p++)
                {
                    int num12 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity, 4, 4, 113, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num12].noGravity = true;
                    Main.dust[num12].velocity *= 0.2f;
                }
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.6f / 255f, (float)(255 - base.Projectile.alpha) * 0.3f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            for (int a = 0; a < 180; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 64, v.X, v.Y, 0, default(Color), Main.rand.NextFloat(1.1f, 2.2f));
                Main.dust[num].velocity = v;
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
            }
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(3, Main.rand.NextFloat(Main.rand.NextFloat(0f, 4.8f), 9f)).RotatedByRandom(Math.PI * 2);
                int k = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("GoldPosiDust").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[k].timeLeft = Main.rand.Next(92, 143);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - Projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 10)
                {
                    Main.npc[i].StrikeNPC((int)(Projectile.damage / 6f), 0, 1);
                }
            }
            target.AddBuff(Mod.Find<ModBuff>("GoldFlame").Type, 600);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, base.Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(31, 31), Projectile.scale, SpriteEffects.None, 0f);
            for(int i =0;i < 4;i++)
            {
                Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY) - Projectile.velocity * i * 3f, null, new Color(1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, 1 - 1 / 4f * (float)i, (1 - 1 / 4f * (float)i) * Projectile.alpha / 255f), Projectile.rotation, new Vector2(31, 31), Projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
