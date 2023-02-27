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
    public class VineRlif2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.light = 0.1f;
            Projectile.timeLeft = 90;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 10;
            Projectile.penetrate = -1;
        }
        public override void AI()
        {
        }
        public override void Kill(int timeLeft)
        {
            NPC.NewNPC((int)Projectile.Center.X,(int)Projectile.Center.Y + 60,Mod.Find<ModNPC>("WildWine3").Type);
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(2.3f, Main.rand.NextFloat(2.9f, 4.2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num5].velocity = v;
            }
        }
        private float x = 0;
    }
}
