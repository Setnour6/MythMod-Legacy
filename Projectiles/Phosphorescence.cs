using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod/*mod�0�10�6�01�0�10�6�84*/.Projectiles
{
    public class Phosphorescence : ModProjectile
    {
        // Brought to you with <3 by Gorateron
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("�0�10�6�99�0�3�0�9�0�10�6�91�0�10��9");//�0�10�6�95���0�7�0�10�6�07�0�10��5
            Main.projFrames[Projectile.type] = 4; /*�0�10�6�73�0�10�6�96�0�10��0�0�10�6�73�0�10�6�08�0�10�6�85�0�10�0�32�0�10�6�796�0�10�6�73�0�10�6�97�0�10��9�0�10�0�38�0�10�0�37�0�10�6�77�0�10��8�0�10�6�02�0�10�0�30���0�7�0�10�0�31�0�10�6�94�0�10�0�36�0�10��5�0�10�0�36�0�10�6�79�0�10�6�93�0�10��26�0�10��0�0�10�6�73�0�10�6�03�0�10��9*/

        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;//�0�10�0�37�0�10�0�35�0�10�6�92�0�10�6�01
            Projectile.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;//�0�10�6�95���0�1�0�10�0�39�0�10�6�95
            Projectile.ignoreWater = true;//�0�10��5�0�10�6�93�0�3�0�8�0�10�6�93�0�10�6�09�0�10��3�0�10�0�37�0�3�0�0�0�10�0�33���0�1
            Projectile.tileCollide = false;//�0�10�6�02�0�10��5�0�10��7�0�10�6�78�0�10�6�05�0�10�6�95�0�10�6�75�0�10��1�0�3��0�10��7�0�10�0�36�0�10�0�72�0�10�0�32�0�10�6�79false
            Projectile.timeLeft = 1800;//�0�10��7�0�10�0�73�0�10�0�38�0�10��3�0�10�6�08�0�3�0�8�0�10�6�94�0�10�0�71�0�10�6�75�0�10��160�0�10�6�08�0�10�6�051�0�10�6�01�0�10�0�75
            Projectile.scale = 1f;//�0�10��7���0�3�0�10�0�34�0�10�6�73
            Projectile.alpha = 140;//�0�10��7���0�3�0�10�0�34�0�10�6�73
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
            if (Projectile.timeLeft == 710) { Projectile.tileCollide = true; }//�0�10��8�0�3�0�8�0�10�6�02�0�10�0�70�0�10��8�0�10�6�02�0�10�0�30�0�10��1�0�10�0�34�0�3���0�10��7�0�10�0�73�0�10�0�38�0�10��3710���0�1�0�10�6�81�0�10�6�08�0�3�0�8�0�10�6�75�0�10��1�0�10��5�0�10�6�93�0�10�6�02�0�10��5�0�10��7�0�10�6�78�0�10�6�05�0�10�6�95
            Projectile.light = 0.1f;//�0�3��0�10�6�74�0�10�6�91�0�10��9//0�0�10�0�32�0�10�6�79�0�10��5�0�10�6�93�0�3��0�10�6�74�0�10�6�91�0�10��9
            Vector2 pc = Projectile.position + new Vector2(Projectile.width, Projectile.height) / 2;//�0�10�6�06�0�10�6�01�0�10�6�02�0�10�0�70�0�10��8�0�10�6�02�0�10�0�30�0�10��1�0�10�0�34�0�3���0�10�0�39�0�10�6�85�0�10��6�0�10�6�75�0�10�6�93�0�10��4
            Projectile.light = 0.1f;//�0�3��0�10�6�74�0�10�6�91�0�10��9
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
