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
    public class Redust : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("Redust");
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 40;
            base.Projectile.height = 40;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 4;
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
            int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(8, 8) - base.Projectile.velocity, 0, 0, 183, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.2f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0;i < 30;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(8, 8), 0, 0, 183, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 18; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 3f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(8, 8), 0, 0, 183, v.X, v.Y, 100, default(Color), 1.7f);
                Main.dust[num9].noGravity = true;
            }
            target.AddBuff(Mod.Find<ModBuff>("Break").Type, 300, false);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, base.Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(17, 17), Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
