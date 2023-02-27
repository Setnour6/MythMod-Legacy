using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Dusts.FireWork
{
    public class Greenfire : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 1f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.alpha = 0;
        }
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        private float po = 0;
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += 0.1f;
            dust.scale *= 0.96f;
            dust.velocity *= 0.95f;
            dust.velocity.Y += 0.1f;
            float scale = dust.scale;
            if (dust.fadeIn > 0.1f)
            {
                dust.fadeIn -= 0.01f;
                dust.scale *= 1.06f;
            }
            dust.fadeIn -= 0.01f;
            Lighting.AddLight(dust.position, 0.15f * dust.scale * dust.scale, 0.7f, 0f);
            if (dust.scale < 0.15f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
