using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod/*mod0‡10‹4*/.Projectiles
{
    public class Phosphorescence : ModProjectile
    {
        // Brought to you with <3 by Gorateron
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("0†9¡Á0†10‰9");//0†5¨¦0‡70‰5
            Main.projFrames[Projectile.type] = 4; /*0„30†60‰00„30‡80‹50ˆ20„960„30†70…90ˆ80ˆ70„70…80‡20ˆ0¨´0ˆ10†40ˆ60…50ˆ60„90†30…260‰00„30‡30…9*/

        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;//0ˆ70ˆ50†20‡1
            Projectile.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;//0†5¨¹0ˆ90†5
            Projectile.ignoreWater = true;//0…50†3¡À0†30‡90…30ˆ7¡ã0ˆ3¨¬
            Projectile.tileCollide = false;//0‡20‰50…70„80‡50†50„50…1¡¤0…70ˆ60Š20ˆ20„9false
            Projectile.timeLeft = 1800;//0…70Š30ˆ80‰30‡8¡À0†40Š10„50…1600‡80‡510‡10Š5
            Projectile.scale = 1f;//0…7¨®0ˆ40„3
            Projectile.alpha = 140;//0…7¨®0ˆ40„3
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
            if (Projectile.timeLeft == 710) { Projectile.tileCollide = true; }//0…8¡À0‡20Š00…80‡20ˆ00‰10ˆ4¡ì0…70Š30ˆ80‰3710¨¬0‹10‡8¡À0„50…10…50†30‡20‰50…70„80‡50†5
            Projectile.light = 0.1f;//¡¤0„40†10‰9//00ˆ20„90…50†3¡¤0„40†10‰9
            Vector2 pc = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2;//0‡60‡10‡20Š00…80‡20ˆ00‰10ˆ4¡ì0ˆ90‹50…60„50†30…4
            Projectile.light = 0.1f;//¡¤0„40†10‰9
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
