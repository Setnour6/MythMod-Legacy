using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
    public class DiamondBomb : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("钻石钱手雷");
		}
        private float num = 0;
        // Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
        public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 38;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Throwing;
            base.Projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void AI()
        {
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f + num;
            if(Projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if(x)
            {
                num += m;
                if(m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (Projectile.velocity.Y < 15f && !x)
            {
                Projectile.velocity.Y += 0.2f;
            }
            Dust.NewDust(new Vector2((float)Projectile.Center.X, (float)Projectile.Center.Y) + new Vector2(0,-10).RotatedBy(Projectile.rotation), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                if(Projectile.velocity.Length() > 0.5f)
                {
                    if (base.Projectile.velocity.X != oldVelocity.X)
                    {
                        base.Projectile.velocity.X = -oldVelocity.X * 0.6f;
                    }
                    if (base.Projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.Projectile.velocity.Y = -oldVelocity.Y * 0.6f;
                    }
                }
                else
                {
                    base.Projectile.velocity.Y *= 0;
                    base.Projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            for (int j = 0; j < 40; j++)
            {
                Vector2 v = new Vector2(0, 12).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("DiamondCoin").Type, (int)((double)base.Projectile.damage * 0.2f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X + v.X, base.Projectile.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("DiamondFlame").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            for (int i = 0; i <= 48; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 80f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 80f;
                int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("DiamondDust").Type, (int)((double)base.Projectile.damage * 0.1f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(990, 1500) / 1000f * ((600 - timeLeft) / 600f + 0.4f);
            }
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
	}
}
