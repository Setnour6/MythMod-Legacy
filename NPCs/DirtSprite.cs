using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    [AutoloadBossHead]
    public class DirtSprite : ModNPC
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("泥潭怪");
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "泥潭怪");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
        public override void SetDefaults()
		{
			base.NPC.aiStyle = 3;
			base.NPC.damage = 20;
			base.NPC.width = 88;
			base.NPC.height = 96;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 3300;
			base.NPC.knockBackResist = 0f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
            NPC.boss = true;
            base.NPC.value = 2000;
            NPC.behindTiles = true;
            NPC.friendly = true;
        }
        private int y = 0;
        private Vector2 vp = new Vector2(0, 0);
        public override void AI()
		{
            Player player = Main.player[base.NPC.target];
            NPC.TargetClosest(true);
            player = Main.player[NPC.target];
            NPC.netUpdate = true;
            y += 1;
            NPC.frame.Y = ((int)(y / 15f) % 3) * 96; 
            if (NPC.life < NPC.lifeMax * 0.5f)
            {
                NPC.aiStyle = 3;
            }
            NPC.spriteDirection = NPC.velocity.X > 0 ? 1 : -1;
            if (NPC.localAI[0] % 1000 == 0)
            {
                vp = NPC.Center + new Vector2(-NPC.width / 2f, NPC.height / 2f - 3);
                NPC.dontTakeDamage = true;
                NPC.friendly = true; 
            }
            if (NPC.localAI[0] % 1000 <= 60)
            {
                NPC.noTileCollide = true;
                NPC.noGravity = true;
                int i = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i].noGravity = true;
                int i2 = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i2].noGravity = true;
                int i3 = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i3].noGravity = true;
                NPC.velocity.X *= 0;
                NPC.noTileCollide = true;
                NPC.velocity.Y = 1;
                if(NPC.alpha < 255)
                {
                    NPC.alpha += 5;
                }
            }
            if (NPC.localAI[0] % 1000 > 60 && NPC.localAI[0] % 1000 <= 240)
            {
                if (NPC.localAI[0] % 1000 == 62)
                {
                    NPC.alpha = 255;
                    NPC.position = player.position + new Vector2(Main.rand.Next(-400,400),-1000);
                    NPC.noTileCollide = false;
                    NPC.noGravity = false;
                    NPC.velocity.Y = 10;
                }
                if (NPC.collideY)
                {
                    if(NPC.alpha > 249)
                    {
                        vp = NPC.Center + new Vector2(-NPC.width / 2f, NPC.height / 2f - 3);
                    }
                    if (NPC.alpha < 150)
                    {
                        NPC.dontTakeDamage = false;
                        NPC.friendly = false; 
                    }
                    int i = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i].noGravity = true;
                    int i2 = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i2].noGravity = true;
                    int i3 = Dust.NewDust(vp, NPC.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i3].noGravity = true;
                    if (NPC.alpha > 0)
                    {
                        NPC.alpha -= 5;
                    }
                    NPC.velocity.X *= 0;
                    NPC.velocity.Y = 0;
                }
            }
            if(MythWorld.Myth)
            {
                if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 60 == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1600) * NPC.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("DirtBall").Type, NPC.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.life < NPC.lifeMax / 2)
                {

                    if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, Mod.Find<ModProjectile>("DirtSp").Type, NPC.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!MythWorld.Myth && Main.expertMode)
            {
                if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 80 == 0)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1500) * NPC.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("DirtBall").Type, NPC.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.life < NPC.lifeMax / 2)
                {
                    if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, Mod.Find<ModProjectile>("DirtSp").Type, NPC.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!Main.expertMode)
            {
                if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 100 == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1400) * NPC.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("DirtBall").Type, NPC.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.life < NPC.lifeMax / 2)
                {
                    if (NPC.localAI[0] % 1000 > 240 && NPC.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, Mod.Find<ModProjectile>("DirtSp").Type, NPC.damage, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!player.active || player.dead)
            {
                canDespawn = true;
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.alpha += 5;
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    if (base.NPC.alpha >= 254)
                    {
                        base.NPC.velocity = new Vector2(0f, 1000f);
                        NPC.noTileCollide = true;
                        NPC.active = false;
                    }
                    return;
                }
            }
            else
            {
                canDespawn = false;
            }
            NPC.localAI[0] += 1;
        }
        private bool canDespawn;
        public override bool PreKill()
		{
			return true;
		}
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int j = 0; j < 20; j++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 28, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (NPC.life <= 0)
            {
                for (int j = 0; j < 40; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 28, (float)hitDirection, -1f, 0, default(Color), 2f);
                }
            }
        }
        public override void OnKill()
        {
            bool expertMode = Main.expertMode;
            if (expertMode)
            {
                Item.NewItem((int)base.NPC.position.X + 40, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("DirtSpriteTreasureBag").Type, 1, false, 0, false, false);
            }
            else
            {
                int type = 0;
                switch (Main.rand.Next(1, 7))
                {
                    case 1:
                        type = base.Mod.Find<ModItem>("Vine").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("GrassGun").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("RootStaff").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("MossRay").Type;
                        break;
                    case 5:
                        type = base.Mod.Find<ModItem>("MudBlade").Type;
                        break;
                    case 6:
                        type = base.Mod.Find<ModItem>("VineSlingshot").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 1)
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("DirtSpritePlatfo").Type, 1, false, 0, false, false);
            }
            if (!MythWorld.downedQDEG)
            {
                MythWorld.downedQDEG = true;
            }
        }
    }
}
