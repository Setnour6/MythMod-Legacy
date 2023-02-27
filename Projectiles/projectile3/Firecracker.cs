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
    public class Firecracker : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸鞭炮");
            Main.projFrames[base.projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 44;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            projectile.extraUpdates = 2;
        }
        public override Color? GetAlpha(Color lightColor)
		{
            if(projectile.timeLeft > 20)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(1 * projectile.timeLeft / 20f, 1 * projectile.timeLeft / 20f, 1 * projectile.timeLeft / 20f, 0));
            }
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            base.projectile.frame = (int)(4 - (projectile.timeLeft / 10));
            if (projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 2f * projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 2f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale * projectile.timeLeft / 120f);
            }
            if (projectile.timeLeft == 40)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/鞭炮"), (int)projectile.Center.X, (int)projectile.Center.Y);
            }
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}