using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.Audio;
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
    public class Firecracker : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸鞭炮");
            Main.projFrames[base.Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 44;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            Projectile.extraUpdates = 2;
        }
        public override Color? GetAlpha(Color lightColor)
		{
            if(Projectile.timeLeft > 20)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(1 * Projectile.timeLeft / 20f, 1 * Projectile.timeLeft / 20f, 1 * Projectile.timeLeft / 20f, 0));
            }
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            base.Projectile.frame = (int)(4 - (Projectile.timeLeft / 10));
            if (Projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 2f * Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 2f / 255f * Projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 2f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 2f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            }
            if (Projectile.timeLeft == 40)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/鞭炮"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            }
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}