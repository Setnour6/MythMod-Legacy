using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.FinalEye
{
        [AutoloadBossHead]
    public class FinalEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("终天灭世眼");
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "终天灭世眼");
		}
		public override void SetDefaults()
		{
			base.NPC.damage = 6000;
            base.NPC.lifeMax = 2500000;
			base.NPC.npcSlots = 14f;
			base.NPC.width = 150;
			base.NPC.height = 150;
			base.NPC.defense = 200;
			this.AnimationType = 125;
			base.NPC.value = 0f;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.knockBackResist = 0f;
			base.NPC.boss = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
			this.Music = 12;
		}
        private bool canDespawn;
        private int BOSSLIFE;
        private bool A2 = true;
		public override void BossHeadRotation(ref float rotation)
		{
			rotation = base.NPC.rotation;
		}
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[base.NPC.target];

            bool flag2 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.4;
            bool flag3 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.37;
            bool flag4 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.35;
            bool flag5 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.2;
            bool flag6 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.1;
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            base.NPC.TargetClosest(true);
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            int num4 = (base.NPC.ai[0] == 2f) ? 2 : 1;
            int num5 = (base.NPC.ai[0] == 2f) ? 50 : 35;
            float num6 = expertMode ? 5f : 4.5f;
            if (num3 == 1500)
            {
                player.position.X = vector.X + player.Center.X;
                player.position.Y = vector.Y + player.Center.Y;
            }
            if (!player.active || player.dead)
            {
                canDespawn = true;
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.velocity = new Vector2(0f, -50f);
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    return;
                }
            }
            else
            {
                canDespawn = false;
            }
            if ((double)base.NPC.life > (double)base.NPC.lifeMax * 0.4)
            { 
                if (Main.netMode != 1)
                {
                    base.NPC.chaseable = false;
                    base.NPC.dontTakeDamage = true;
                    base.NPC.TargetClosest(true);
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                    this.dustTimer--;
                }
                if (base.NPC.ai[0] == 0f)
                {
                    
                    base.NPC.dontTakeDamage = false;
                    base.NPC.chaseable = false;
                    if (Main.netMode != 1)
                    {
                        base.NPC.localAI[0] += 2;
                        if (base.NPC.localAI[0] == 2f && NPC.CountNPCS(Mod.Find<ModNPC>("Monitor").Type) < 1)
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("终天灭世眼HiaHiaHiaHia").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            if (MythWorld.Myth)
                            {
                                for (int k = 0; k < 30; k++)
                                {
                                    Vector2 vector4 = NPC.Center + new Vector2((float)Math.Sin((float)k / 15 * Math.PI) * 1500, (float)(Math.Cos((float)k / 15 * Math.PI) * 1500) + 100);
                                    NPC.NewNPC((int)vector4.X, (int)vector4.Y, Mod.Find<ModNPC>("Monitor").Type, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else if(expertMode)
                            {
                                for (int k = 0; k < 45; k++)
                                {
                                    Vector2 vector4 = NPC.Center + new Vector2((float)Math.Sin((float)k / 22.5 * Math.PI) * 2250, (float)(Math.Cos((float)k / 22.5 * Math.PI) * 2250) + 100);
                                    NPC.NewNPC((int)vector4.X, (int)vector4.Y, Mod.Find<ModNPC>("Monitor").Type, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                            else
                            {
                                for (int k = 0; k < 60; k++)
                                {
                                    Vector2 vector4 = NPC.Center + new Vector2((float)Math.Sin((float)k / 30 * Math.PI) * 3000, (float)(Math.Cos((float)k / 30 * Math.PI) * 3000) + 100);
                                    NPC.NewNPC((int)vector4.X, (int)vector4.Y, Mod.Find<ModNPC>("Monitor").Type, 0, 0f, 0f, 0f, 0f, 255);
                                }
                            }
                        }
                        if (base.NPC.localAI[0] % 3 == 1f)
                        {
                            BOSSLIFE = NPC.life;
                        }
                        if (base.NPC.life <= base.NPC.lifeMax - 500)
                        {
                            base.NPC.life += 47;
                        }
                        if (base.NPC.localAI[0] == 150f)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("晶刺").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            for (int j = 0; j < 12; j++)
                            {
                                num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                                num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                                num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                                num31 = num27 / num31;
                                num28 += (float)Main.rand.Next(-150, 151);
                                num30 += (float)Main.rand.Next(-150, 151);
                                num28 *= num31;
                                num30 *= num31;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28 * 0.25f, num30 * 0.25f, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 240;
                                Main.projectile[num34].tileCollide = false;
                            }
                            float num35 = 0.783f;
                            double num36 = Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y) - (double)(num35 / 2f);
                            double num37 = (double)(num35 / 8f);
                            int num38 = expertMode ? 22 : 30;
                            for (int k = 0; k < 80; k++)
                            {
                                int timeLeft = Main.rand.Next(400, 700);
                                double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                                double num45 = Math.Cos((float)num44);
                                double num46 = Math.Sin((float)num44);
                                float num47 = (float)Main.rand.Next(0, 10000) / 500;
                                int num40 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                int num42 = Main.rand.Next(4);
                                if (num42 == 1)
                                {
                                    {
                                        int num41 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 2.0) * 0.4f, (float)(-(float)Math.Cos(num39) * 2.0) * 0.4f,  base.Mod.Find<ModProjectile>("空间粒子流").Type, 776, 0f, Main.myPlayer, 0f, 0f);
                                        Main.projectile[num41].timeLeft = 7530;
                                    }
                                }
                                else
                                {
                                    int num43 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 2.0), (float)(-(float)Math.Cos(num39) * 2.0), base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                    Main.projectile[num43].timeLeft = 240;
                                }
                                Main.projectile[num40].timeLeft = 240;
                            }
                        }
                        if (base.NPC.localAI[0] >= 180f && base.NPC.localAI[0] <= 1260f && (float)base.NPC.localAI[0] % 4 == 0)
                        {
                            int num33 = base.Mod.Find<ModProjectile>("晶刺").Type;
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num60 = (float)Math.Sin(((float)base.NPC.localAI[0] - 180) / 72 * 3.14159265359f) * 2;
                            float num61 = (float)Math.Cos(((float)base.NPC.localAI[0] - 180) / 72 * 3.14159265359f) * 2;
                            float num62 = (float)Math.Sin(((float)base.NPC.localAI[0] - 420) / 72 * 3.14159265359f) * 2;
                            float num63 = (float)Math.Cos(((float)base.NPC.localAI[0] - 420) / 72 * 3.14159265359f) * 2;
                            float num64 = (float)Math.Sin(((float)base.NPC.localAI[0] + 60) / 72 * 3.14159265359f) * 2;
                            float num65 = (float)Math.Cos(((float)base.NPC.localAI[0] + 60) / 72 * 3.14159265359f) * 2;
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num60, num61, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 240;
                            Main.projectile[num34].tileCollide = false;
                            int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, num62, num63, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num35].timeLeft = 240;
                            Main.projectile[num35].tileCollide = false;
                            int num36 = Projectile.NewProjectile(vector5.X, vector5.Y, num64, num65, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num36].timeLeft = 240;
                            Main.projectile[num36].tileCollide = false;
                        }
                        if (base.NPC.localAI[0] >= 1300f && base.NPC.localAI[0] <= 2300f && (float)base.NPC.localAI[0] % 25 == 2)
                        {
                            float num44 = (float)Main.rand.Next(-5, 5);
                            float num45 = (float)Main.rand.Next(-5, 5);
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            for (int j = 0; j < 1; j++)
                            {
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num44, 1, base.Mod.Find<ModProjectile>("金绿烈焰团").Type, 1000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 250;
                                Main.projectile[num34].tileCollide = false;
                            }
                        }
                        if (NPC.localAI[0] >= 3000 && NPC.localAI[0] <= 4000 && NPC.localAI[0] % 50 == 0)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 1100 : 1200;
                            int num33 = base.Mod.Find<ModProjectile>("星空毁灭焰").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                            num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 240;
                            Main.projectile[num34].tileCollide = false;
                            int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num35].timeLeft = 240;
                            Main.projectile[num35].tileCollide = false;
                            Main.projectile[num35].velocity = Main.projectile[num35].velocity.RotatedBy(Math.PI / 5 * 2);
                            int num36 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num36].timeLeft = 240;
                            Main.projectile[num36].tileCollide = false;
                            Main.projectile[num36].velocity = Main.projectile[num36].velocity.RotatedBy(Math.PI / 5 * 4);
                            int num37 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num37].timeLeft = 240;
                            Main.projectile[num37].tileCollide = false;
                            Main.projectile[num37].velocity = Main.projectile[num37].velocity.RotatedBy(Math.PI / 5 * 6);
                            int num38 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num38].timeLeft = 240;
                            Main.projectile[num38].tileCollide = false;
                            Main.projectile[num38].velocity = Main.projectile[num38].velocity.RotatedBy(Math.PI / 5 * 8);
                        }
                        if (base.NPC.localAI[0] == 4000)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("晶刺").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            for (int j = 0; j < 26; j++)
                            {
                                num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                                num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                                num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                                num31 = num27 / num31;
                                num28 += (float)Main.rand.Next(-150, 151);
                                num30 += (float)Main.rand.Next(-150, 151);
                                num28 *= num31;
                                num30 *= num31;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 240;
                                Main.projectile[num34].tileCollide = false;
                            }
                            float num35 = 0.783f;
                            double num36 = Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y) - (double)(num35 / 2f);
                            double num37 = (double)(num35 / 8f);
                            int num38 = expertMode ? 22 : 30;
                            for (int k = 0; k < 90; k++)
                            {
                                int timeLeft = Main.rand.Next(400, 700);
                                double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                                double num45 = Math.Cos((float)num44);
                                double num46 = Math.Sin((float)num44);
                                float num47 = (float)Main.rand.Next(0, 10000) / 500;
                                int num40 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                int num42 = Main.rand.Next(4);
                                if (num42 == 1)
                                {
                                    {
                                        int num41 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 2.0) * 0.4f, (float)(-(float)Math.Cos(num39) * 2.0) * 0.4f,  base.Mod.Find<ModProjectile>("空间粒子流").Type, 776, 0f, Main.myPlayer, 0f, 0f);
                                        Main.projectile[num41].timeLeft = 7530;
                                    }
                                }
                                else
                                {
                                    int num43 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                    Main.projectile[num43].timeLeft = 240;
                                }
                                Main.projectile[num40].timeLeft = 240;
                            }
                        }
                        if (base.NPC.localAI[0] == 4150)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("晶刺").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            for (int j = 0; j < 26; j++)
                            {
                                num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                                num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                                num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                                num31 = num27 / num31;
                                num28 += (float)Main.rand.Next(-150, 151);
                                num30 += (float)Main.rand.Next(-150, 151);
                                num28 *= num31;
                                num30 *= num31;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 240;
                                Main.projectile[num34].tileCollide = false;
                            }
                            float num35 = 0.783f;
                            double num36 = Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y) - (double)(num35 / 2f);
                            double num37 = (double)(num35 / 8f);
                            int num38 = expertMode ? 22 : 30;
                            for (int k = 0; k < 90; k++)
                            {
                                int timeLeft = Main.rand.Next(400, 700);
                                double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                                double num45 = Math.Cos((float)num44);
                                double num46 = Math.Sin((float)num44);
                                float num47 = (float)Main.rand.Next(0, 10000) / 500;
                                int num40 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                int num42 = Main.rand.Next(4);
                                if (num42 == 1)
                                {
                                    {
                                        int num41 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 2.0) * 0.4f, (float)(-(float)Math.Cos(num39) * 2.0) * 0.4f,  base.Mod.Find<ModProjectile>("空间粒子流").Type, 776, 0f, Main.myPlayer, 0f, 0f);
                                        Main.projectile[num41].timeLeft = 7530;
                                    }
                                }
                                else
                                {
                                    int num43 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                    Main.projectile[num43].timeLeft = 240;
                                }
                                Main.projectile[num40].timeLeft = 240;
                            }
                        }
                        if (base.NPC.localAI[0] == 4300)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("晶刺").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            for (int j = 0; j < 26; j++)
                            {
                                num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                                num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                                num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                                num31 = num27 / num31;
                                num28 += (float)Main.rand.Next(-150, 151);
                                num30 += (float)Main.rand.Next(-150, 151);
                                num28 *= num31;
                                num30 *= num31;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 240;
                                Main.projectile[num34].tileCollide = false;
                            }
                            float num35 = 0.783f;
                            double num36 = Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y) - (double)(num35 / 2f);
                            double num37 = (double)(num35 / 8f);
                            int num38 = expertMode ? 22 : 30;
                            for (int k = 0; k < 100; k++)
                            {
                                int timeLeft = Main.rand.Next(400, 700);
                                double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                                float num44 = (float)Main.rand.Next(0, 3600) / 1800 * 3.14159265359f;
                                double num45 = Math.Cos((float)num44);
                                double num46 = Math.Sin((float)num44);
                                float num47 = (float)Main.rand.Next(0, 10000) / 500;
                                int num40 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)num45 * (float)num47, (float)num46 * (float)num47, base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                int num42 = Main.rand.Next(4);
                                if (num42 == 1)
                                {
                                    {
                                        int num41 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 2.0) * 0.4f, (float)(-(float)Math.Cos(num39) * 2.0) * 0.4f,  base.Mod.Find<ModProjectile>("空间粒子流").Type, 776, 0f, Main.myPlayer, 0f, 0f);
                                        Main.projectile[num41].timeLeft = 1600;
                                    }
                                }
                                else
                                {
                                    int num43 = Projectile.NewProjectile(vector5.X, vector5.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                                    Main.projectile[num43].timeLeft = 240;
                                }
                                Main.projectile[num40].timeLeft = 240;
                            }
                        }
                        if (base.NPC.localAI[0] >= 4349f && base.NPC.localAI[0] <= 5550f && (float)base.NPC.localAI[0] % 300 == 2)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("混乱团").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                            num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            num31 = num27 / num31;
                            num28 += (float)Main.rand.Next(-150, 151);
                            num30 += (float)Main.rand.Next(-150, 151);
                            num28 *= num31;
                            num30 *= num31;
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 240;
                            Main.projectile[num34].tileCollide = false;
                        }
                        if (base.NPC.localAI[0] >= 6300f && base.NPC.localAI[0] <= 7500f && (float)base.NPC.localAI[0] % 150 == 2)
                        {
                            base.NPC.TargetClosest(true);
                            float num27 = 8f;
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            float num29 = Math.Abs(num28) * 0.1f;
                            float num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y - num29;
                            float num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            base.NPC.netUpdate = true;
                            num31 = num27 / num31;
                            num28 *= num31;
                            num30 *= num31;
                            int num32 = expertMode ? 650 : 1000;
                            int num33 = base.Mod.Find<ModProjectile>("炼狱幽火").Type;
                            vector5.X += num28;
                            vector5.Y += num30;
                            num28 = player.position.X + (float)player.width * 0.5f - vector5.X;
                            num30 = player.position.Y + (float)player.height * 0.5f - vector5.Y;
                            num31 = (float)Math.Sqrt((double)(num28 * num28 + num30 * num30));
                            num31 = num27 / num31;
                            num28 += (float)Main.rand.Next(-150, 151);
                            num30 += (float)Main.rand.Next(-150, 151);
                            num28 *= num31;
                            num30 *= num31;
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num28, num30, num33, num32, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 80;
                            Main.projectile[num34].tileCollide = false;
                        }
                        if (base.NPC.localAI[0] >= 7650f && base.NPC.localAI[0] <= 9150f && (float)base.NPC.localAI[0] % 9 == 1)
                        {
                            int num33 = base.Mod.Find<ModProjectile>("灭世火光团").Type;
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            float num60 = (float)Math.Sin(((float)base.NPC.localAI[0] - 180) / 72 * 3.14159265359f) * 2;
                            float num61 = (float)Math.Cos(((float)base.NPC.localAI[0] - 180) / 72 * 3.14159265359f) * 2;
                            float num62 = (float)Math.Sin(((float)base.NPC.localAI[0] - 420) / 72 * 3.14159265359f) * 2;
                            float num63 = (float)Math.Cos(((float)base.NPC.localAI[0] - 420) / 72 * 3.14159265359f) * 2;
                            float num64 = (float)Math.Sin(((float)base.NPC.localAI[0] + 60) / 72 * 3.14159265359f) * 2;
                            float num65 = (float)Math.Cos(((float)base.NPC.localAI[0] + 60) / 72 * 3.14159265359f) * 2;
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num60, num61, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 480;
                            Main.projectile[num34].tileCollide = false;
                            Main.projectile[num34].velocity *= 1.03f;
                            int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, num62, num63, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num35].timeLeft = 480;
                            Main.projectile[num35].tileCollide = false;
                            Main.projectile[num35].velocity *= 1.03f;
                            int num36 = Projectile.NewProjectile(vector5.X, vector5.Y, num64, num65, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num36].timeLeft = 480;
                            Main.projectile[num36].tileCollide = false;
                            Main.projectile[num36].velocity *= 1.03f;
                            int num37 = Projectile.NewProjectile(vector5.X, vector5.Y, num61, num60, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num37].timeLeft = 480;
                            Main.projectile[num37].tileCollide = false;
                            Main.projectile[num37].velocity *= 1.03f;
                            int num38 = Projectile.NewProjectile(vector5.X, vector5.Y, num63, num62, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num38].timeLeft = 480;
                            Main.projectile[num38].tileCollide = false;
                            Main.projectile[num38].velocity *= 1.03f;
                            int num39 = Projectile.NewProjectile(vector5.X, vector5.Y, num65, num64, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num39].timeLeft = 480;
                            Main.projectile[num39].tileCollide = false;
                            Main.projectile[num39].velocity *= 1.03f;
                        }
                        if (base.NPC.localAI[0] >= 9200f && base.NPC.localAI[0] <= 10700f && (float)base.NPC.localAI[0] % 150 == 2)
                        {
                            int num48 = Main.rand.Next(6,9);
                            int num33 = base.Mod.Find<ModProjectile>("圣明光环").Type;
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            for ( int m = 0; m < num48 * 2 ; m++)
                            {
                                float num60 = (float)Math.Sin(((float)m) / num48 * 3.14159265359f) * 2;
                                float num61 = (float)Math.Cos(((float)m) / num48 * 3.14159265359f) * 2;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num60, num61, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 240;
                                Main.projectile[num34].tileCollide = false;
                            }
                        }
                        if (base.NPC.localAI[0] >= 9200f && base.NPC.localAI[0] <= 10700f && (float)base.NPC.localAI[0] % 150 == 76)
                        {
                            int num48 = Main.rand.Next(6,9);
                            int num33 = base.Mod.Find<ModProjectile>("灭世火光团").Type;
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            for ( int m = 0; m < num48 * 2 ; m++)
                            {
                                float num60 = (float)Math.Sin(((float)m) / num48 * 3.14159265359f) * 2.7f;
                                float num61 = (float)Math.Cos(((float)m) / num48 * 3.14159265359f) * 2.7f;
                                int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num60, num61, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num34].timeLeft = 720;
                                Main.projectile[num34].tileCollide = false;
                            }
                        }
                        if (base.NPC.localAI[0] >= 10848f && base.NPC.localAI[0] <= 14400f && (float)base.NPC.localAI[0] % 300 == 50)
                        {
                            int num33 = base.Mod.Find<ModProjectile>("散裂之星").Type;
                            base.NPC.TargetClosest(true);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, 4, 0, num33, 1500, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 750;
                            Main.projectile[num34].tileCollide = false;
                            Main.projectile[num34].velocity *= 1.04f;
                            int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, -4, 0, num33, 1500, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num35].timeLeft = 750;
                            Main.projectile[num35].tileCollide = false;
                            Main.projectile[num35].velocity *= 1.04f;
                        }
                        if (base.NPC.localAI[0] >= 15000f && base.NPC.localAI[0] <= 16900f && (float)base.NPC.localAI[0] % 7 == 1)
                        {
                            int num33 = 83;
                            base.NPC.TargetClosest(true);
                            Vector2 vector6 = new Vector2((base.NPC.position.X - player.Center.X) / num3 * 5, (base.NPC.position.Y - player.Center.Y) / num3 * 5);
                            Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                            int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, -vector6.X, -vector6.Y, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num34].timeLeft = 450;
                            Main.projectile[num34].tileCollide = false;
                            Main.projectile[num34].velocity *= 1.1f;
                            Vector2 vector7 = vector6.RotatedBy(Math.PI / 10);
                            int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, -vector7.X, -vector7.Y, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num35].timeLeft = 450;
                            Main.projectile[num35].tileCollide = false;
                            Main.projectile[num35].velocity *= 1.1f;
                            vector7 = vector6.RotatedBy( -(Math.PI / 10));
                            int num36 = Projectile.NewProjectile(vector5.X, vector5.Y, -vector7.X, -vector7.Y, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num36].timeLeft = 450;
                            Main.projectile[num36].tileCollide = false;
                            Main.projectile[num36].velocity *= 1.1f;
                            vector7 = vector6.RotatedBy( -(Math.PI / 5));
                            int num37 = Projectile.NewProjectile(vector5.X, vector5.Y, -vector7.X, -vector7.Y, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num37].timeLeft = 450;
                            Main.projectile[num37].tileCollide = false;
                            Main.projectile[num37].velocity *= 1.1f;
                            vector7 = vector6.RotatedBy(Math.PI / 5);
                            int num38 = Projectile.NewProjectile(vector5.X, vector5.Y, -vector7.X, -vector7.Y, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num38].timeLeft = 450;
                            Main.projectile[num38].tileCollide = false;
                            Main.projectile[num38].velocity *= 1.1f;
                        }
                        if (base.NPC.localAI[0] >= 16900)
                        {
                            base.NPC.localAI[0] = 0;
                            if(!flag2)
                            {
                                mplayer.ZTMSY = true;
                            }
                        }
                    }
                }
            }
            if (flag2 == true)
            {
                if (NPC.life < 1000000 && base.NPC.localAI[0] == 10)
                {
                    mplayer.ZTMSY = false;
                    for (int m = 0; m < 1000; m += 1)
                    {
                        Projectile projectile = Main.projectile[m];
                        if (projectile.active)
                        {
                            projectile.Kill();
                            projectile.active = false;
                        }
                    }
                }
                if (base.NPC.life <= base.NPC.lifeMax - 500)
                {
                    base.NPC.life += 73;
                }
                if (A2 == true)
                {
                    base.NPC.localAI[0] = 0;
                    A2 = false;
                }
                base.NPC.localAI[0] += 1f;
                Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                if(Math.Sqrt(base.NPC.velocity.X * base.NPC.velocity.X + base.NPC.velocity.Y * base.NPC.velocity.Y) < 50f)
                {
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                else
                {
                    base.NPC.rotation = (float) - (Math.Atan2((double)base.NPC.velocity.X, (double)base.NPC.velocity.Y));
                }
                if (base.NPC.localAI[0] == 100)
                {
                    int num48 = Main.rand.Next(6,9);
                    int num33 = base.Mod.Find<ModProjectile>("灭世火光团").Type;
                    base.NPC.TargetClosest(true);
                    Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                    for ( int m = 0; m < num48 * 2 ; m++)
                    {
                        float num60 = (float)Math.Sin(((float)m) / num48 * 3.14159265359f) * 2.7f;
                        float num61 = (float)Math.Cos(((float)m) / num48 * 3.14159265359f) * 2.7f;
                        int num34 = Projectile.NewProjectile(vector5.X, vector5.Y, num60, num61, num33, 1000, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num34].timeLeft = 720;
                        Main.projectile[num34].tileCollide = false;
                    }               
                }
                if (base.NPC.localAI[0] >= 100 && base.NPC.localAI[0] <= 600 && base.NPC.localAI[0] % 100 == 0)
                {
                    Vector2 Speed =  new Vector2(base.NPC.Center.X - player.Center.X, base.NPC.Center.Y - player.Center.Y) / num3 * (70 + num3 / 50);
                    base.NPC.velocity = -Speed + player.velocity;                
                }
                if (base.NPC.localAI[0] >= 100 && base.NPC.localAI[0] <= 600)
                {
                    base.NPC.velocity *= 0.98f;
                    Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                    Projectile.NewProjectile(vector5.X, vector5.Y, (float)Main.rand.Next(-8, 8), (float)Main.rand.Next(-8, 8), base.Mod.Find<ModProjectile>("灭世火光团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                }
                if (base.NPC.localAI[0] >= 600 && base.NPC.localAI[0] <= 2400)
                {
                    float num8 = (float)Math.Sin((base.NPC.localAI[0] - 600) / 60f * Math.PI) * 1500;
                    float num9 = (float)Math.Cos((base.NPC.localAI[0] - 600) / 60f * Math.PI) * 900;
                    Vector2 vector3 =  new Vector2(base.NPC.Center.X - player.Center.X + (float)num8, base.NPC.Center.Y - player.Center.Y - 50 + (float)num9);
                    int num7 = (int)Math.Sqrt(vector3.X * vector3.X + vector3.Y * vector3.Y);
                    Vector2 Speed2 =  new Vector2(base.NPC.Center.X - player.Center.X + (float)num8, base.NPC.Center.Y - player.Center.Y - 50 + (float)num9);
                    if(num7 >= 1.2f)
                    {
                        Speed2 =  new Vector2(base.NPC.Center.X - player.Center.X + (float)num8, base.NPC.Center.Y - player.Center.Y - 50 + (float)num9) / num7 * (7 + num7 / 50);
                    }
                    base.NPC.velocity = -Speed2;
                }
                if (base.NPC.localAI[0] >= 600 && base.NPC.localAI[0] <= 2400 && base.NPC.localAI[0] % 30 == 0)
                {
                    Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
				    Vector2 Speed4 =  new Vector2(vector5.X - player.Center.X, vector5.Y - player.Center.Y) / num3 * 16;
                    Vector2 Speed3 = -Speed4 + player.velocity;
                    int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, Speed3.X, Speed3.Y, base.Mod.Find<ModProjectile>("星空毁灭焰").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].velocity *= 1.25f;
                }
                if (base.NPC.localAI[0] >= 2410 && base.NPC.localAI[0] <= 3600)
                {
                    Vector2 vector3 =  new Vector2(base.NPC.Center.X - player.Center.X + 500, base.NPC.Center.Y - player.Center.Y - 50);
                    int num7 = (int)Math.Sqrt(vector3.X * vector3.X + vector3.Y * vector3.Y);
                    Vector2 Speed2 =  new Vector2(base.NPC.Center.X - player.Center.X + 500, base.NPC.Center.Y - player.Center.Y - 50);
                    if(num7 >= 1.2f)
                    {
                        Speed2 =  new Vector2(base.NPC.Center.X - player.Center.X + 500, base.NPC.Center.Y - player.Center.Y - 50) / num7 * (7 + num7 / 50);
                    }
                    base.NPC.velocity = -Speed2;
                }
                if (base.NPC.localAI[0] >= 2410 && base.NPC.localAI[0] <= 3600 && base.NPC.localAI[0] % 60 == 0)
                {
                    Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
				    Vector2 Speed4 =  new Vector2(vector5.X - player.Center.X, vector5.Y - player.Center.Y) / num3 * 16;
                    Vector2 Speed3 = -Speed4 + player.velocity;
                    int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, Speed3.X, Speed3.Y, base.Mod.Find<ModProjectile>("金绿烈焰团").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].velocity *= 1.25f;
                }
                if (base.NPC.localAI[0] >= 3600 && base.NPC.localAI[0] <= 4800 && base.NPC.localAI[0] % 50 == 0)
                {
                    Vector2 Speed =  new Vector2(base.NPC.Center.X - player.Center.X, base.NPC.Center.Y - player.Center.Y) / num3 * (70 + num3 / 50);
                    base.NPC.velocity = -Speed + player.velocity;
                    for ( int m = 0; m < 8 ; m++)
                    {
                        Vector2 vector5 = new Vector2(base.NPC.position.X - (float)(Math.Cos(base.NPC.rotation - 1.5708f) * base.NPC.width * 0.5f - 84f), base.NPC.position.Y - (float)(Math.Sin(base.NPC.rotation - 1.5708f) * base.NPC.height * 0.5f + 16f));
                        Vector2 Speed4 =  new Vector2(vector5.X - player.Center.X, vector5.Y - player.Center.Y) / num3 * 16;
                        Vector2 Speed3 = -Speed4 + player.velocity;
                        Vector2 Speed5 = Speed3.RotatedBy(Math.PI / 100 * Main.rand.Next(-30, 30)) * 0.3f;
                        int num35 = Projectile.NewProjectile(vector5.X, vector5.Y, Speed5.X, Speed5.Y, base.Mod.Find<ModProjectile>("晶刺").Type, 1080, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num35].velocity *= 1.1f;  
                    }
                    if (MythWorld.Myth)
                    {
                        Vector2 Speed4 =  new Vector2(NPC.Center.X - player.Center.X, NPC.Center.Y - player.Center.Y) / num3 * 16;
                        int num36 = Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -Speed4.X, -Speed4.Y, base.Mod.Find<ModProjectile>("终天灭世眼映射").Type, 1440, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num36].rotation = base.NPC.rotation;
                    }              
                }
                if (base.NPC.localAI[0] >= 3600 && base.NPC.localAI[0] <= 4800)
                {
                    base.NPC.velocity *= 0.92f;
                }
                if (base.NPC.localAI[0] >= 4805)
                {
                    base.NPC.localAI[0] = 0;
                }
            }
        }
        // Token: 0x02000413 RID: 1043
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			base.NPC.lifeMax = (int)((float)base.NPC.lifeMax * 0.8f * bossLifeScale);
			base.NPC.damage = (int)((float)base.NPC.damage * 0.8f);
		}
        // Token: 0x02000413 RID: 1043
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 204, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.NPC.life <= 0)
            {
                for (int j = 0; j < 20; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 204, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                float scaleFactor = (float)(Main.rand.Next(-800, 800) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/终天灭世眼1"), 1f);
            }
        }
        // Token: 0x02000413 RID: 1043
        public override bool CheckActive()
		{
			return this.canDespawn;
		}
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            player.lastDeathPostion = player.Center;
            player.lastDeathTime = DateTime.Now;
            player.showLastDeath = true;
            if (Main.myPlayer == player.whoAmI)
            {
                player.lostCoinString = Main.ValueToCoins(player.lostCoins);
            }
            SoundEngine.PlaySound(SoundID.PlayerKilled, player.position);
            player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
            if (player.stoned)
            {
                player.headPosition = Vector2.Zero;
                player.bodyPosition = Vector2.Zero;
                player.legPosition = Vector2.Zero;
            }
            for (int j = 0; j < 100; j++)
            {
                Dust.NewDust(player.position, player.width, player.height, 235, 0f, -2f, 0, default(Color), 1f);
            }
            player.statLife = 0;
            player.dead = true;
            player.respawnTimer = 600;
            player.head = -1;
            player.body = -1;
            player.legs = -1;
            player.handon = -1;
            player.handoff = -1;
            player.back = -1;
            player.front = -1;
            player.shoe = -1;
            player.waist = -1;
            player.shield = -1;
            player.neck = -1;
            player.face = -1;
            player.balloon = -1;
            player.mount.Dismount(player);
            if (Main.expertMode)
            {
                player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
            }
            player.immuneAlpha = 0;
            player.palladiumRegen = false;
            player.iceBarrier = false;
            player.crystalLeaf = false;
            PlayerDeathReason playerDeathReason = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
            NetworkText deathText = playerDeathReason.GetDeathText(player.name);
            if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
            {
                player.DropCoins();
            }
            else if (player.difficulty == 1)
            {
                player.DropItems();
            }
            else if (player.difficulty == 2)
            {
                player.DropItems();
                player.KillMeForGood();
            }
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 2.4f;
			return null;
		}
        public override void OnKill()
        {
            if (!MythWorld.downedZTMSY)
            {
                MythWorld.downedZTMSY = true;
            }
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("ShinyFireII").Type, 1, false, 0, false, false);
        }
        // Token: 0x02000413 RID: 1043
        public int dustTimer = 60;
		// Token: 0x06001646 RID: 5702 RVA: 0x000E4084 File Offset: 0x000E2284
	}
}
