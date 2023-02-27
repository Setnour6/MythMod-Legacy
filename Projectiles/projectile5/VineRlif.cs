using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMod2.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile5
{
    public class VineRlif : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.light = 0.1f;
            projectile.timeLeft = 90;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 10;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
        }
        public override void Kill(int timeLeft)
        {
            NPC.NewNPC((int)projectile.Center.X,(int)projectile.Center.Y + 60,mod.NPCType("WildWine"));
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(2.3f, Main.rand.NextFloat(2.9f, 4.2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Poison"), 0f, 0f, 100, Color.White, 2f);
                Main.dust[num5].velocity = v;
            }
        }
        private float x = 0;
    }
}
