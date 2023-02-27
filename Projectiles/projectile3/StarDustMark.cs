using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class StarDustMark : ModProjectile
	{
		private float num4;
		private bool num5 = true;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星尘光标");
		}
		public override void SetDefaults()
		{
            base.projectile.width = 50;
            base.projectile.height = 50;
            base.projectile.netImportant = true;
            base.projectile.friendly = true;
            base.projectile.minionSlots = 1f;
            //base.projectile.aiStyle = 54;
            base.projectile.timeLeft = 18000;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft *= 5;
            base.projectile.minion = true;
            //this.aiType = 317;
            base.projectile.tileCollide = false;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig, lig, lig, 0));
        }
        private int zo = 300;
        private bool off = false;
        private float lig = 0;
        private Vector2 vb = new Vector2(0, 0);
        public override void AI()
        {
            if (base.projectile.localAI[0] == 0f)
            {
                int num = 36;
                base.projectile.localAI[0] += 1f;
            }
            base.projectile.localAI[0] += 1f;
            bool flag = base.projectile.type == base.mod.ProjectileType("星尘光标");
            Player player = Main.player[base.projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("StarDustLight")) && projectile.localAI[0] > 3)
            {
                //projectile.Kill();
                off = true;
            }
            if(!off)
            {
                player.AddBuff(base.mod.BuffType("StarDustLight"), 3600, true);
            }
            if (flag)
            {
                if (player.dead)
                {
                    modPlayer.StarDustLight = false;
                }
                if (modPlayer.StarDustLight)
                {
                    base.projectile.timeLeft = 2;
                }
            }
            if(!player.HasBuff(mod.BuffType("StarDustLight")))
            {
                //projectile.Kill();
                off = true;
            }
            if(!off && Main.rand.Next(10) == 1 && lig >= 1)
            {
                off = true;
                vb = player.Center + new Vector2(0, Main.rand.Next(200)).RotateRandom(Math.PI * 2);
                base.projectile.minionSlots = 0;
                base.projectile.netImportant = false;
                int zi = Projectile.NewProjectile(vb.X, vb.Y - 2, 0, 0, mod.ProjectileType("StarDustMark"),projectile.damage, projectile.knockBack, player.whoAmI, 0f, Main.rand.Next(6));
            }
            if(!off)
            {
                if(lig < 1)
                {
                    lig += 0.01f;
                }
                else
                {
                    lig = 1;
                }
            }
            if(off)
            {
                zo -= 1;
                if(zo < 0)
                {
                    lig -= 0.01f;
                    if (lig <= 0)
                    {
                        projectile.Kill();
                    }
                }
                for(int i = 0;i < 200;i++)
                {
                    if(!Main.npc[i].friendly && !Main.npc[i].dontTakeDamage && Main.npc[i].active)
                    {
                        float a = (vb - projectile.Center).Length();
                        if(a < 2000)
                        {
                            float b = (vb - Main.npc[i].Center).Length();
                            float c = (projectile.Center - Main.npc[i].Center).Length();
                            float x = (c * c + a * a - b * b) / (2 * a);
                            if (c * c - x * x < Math.Sqrt(Main.npc[i].width * Main.npc[i].width + Main.npc[i].height * Main.npc[i].height) && (b * b + c * c - a * a) <= 0)
                            {
                                Main.npc[i].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.8f, 1.2f)) / 3 * 2, 0, (int)(Main.npc[i].velocity.X / Math.Abs(Main.npc[i].velocity.X)), false, false, false);
                            }
                        }
                    }
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (off)
            {
                float a = (vb - projectile.Center).Length();
                if (a < 2000)
                {
                    Vector2 vector24 = new Vector2(projectile.Center.X, projectile.Center.Y);
                    Vector2 vector25 = new Vector2(vb.X, vb.Y);
                    float num80 = (vector25 - vector24).Length();
                    Vector2 unit = vector25 - vector24;
                    unit.Normalize();
                    float r = unit.ToRotation() - (float)Math.PI / 2f;
                    for (float i = 0; i < num80; i += 2)
                    {
                        if (zo < 200)
                        {
                            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/星尘光标连线"), vector24 + unit * i - Main.screenPosition, null, new Color(lig, lig, lig, 0), r, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            float lig2 = (300 - zo) / 100f * (300 - zo) / 100f;
                            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/星尘光标连线"), vector24 + unit * i - Main.screenPosition, null, new Color(lig2, lig2, lig2, 0), r, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            return base.PreDraw(spriteBatch, lightColor);
        }
    }
}
