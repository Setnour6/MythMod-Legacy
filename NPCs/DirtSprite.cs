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
            base.DisplayName.SetDefault("泥潭怪");
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "泥潭怪");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
        public override void SetDefaults()
		{
			base.npc.aiStyle = 3;
			base.npc.damage = 20;
			base.npc.width = 88;
			base.npc.height = 96;
			base.npc.defense = 5;
			base.npc.lifeMax = 3300;
			base.npc.knockBackResist = 0f;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            npc.boss = true;
            base.npc.value = 2000;
            npc.behindTiles = true;
            npc.friendly = true;
        }
        private int y = 0;
        private Vector2 vp = new Vector2(0, 0);
        public override void AI()
		{
            Player player = Main.player[base.npc.target];
            npc.TargetClosest(true);
            player = Main.player[npc.target];
            npc.netUpdate = true;
            y += 1;
            npc.frame.Y = ((int)(y / 15f) % 3) * 96; 
            if (npc.life < npc.lifeMax * 0.5f)
            {
                npc.aiStyle = 3;
            }
            npc.spriteDirection = npc.velocity.X > 0 ? 1 : -1;
            if (npc.localAI[0] % 1000 == 0)
            {
                vp = npc.Center + new Vector2(-npc.width / 2f, npc.height / 2f - 3);
                npc.dontTakeDamage = true;
                npc.friendly = true; 
            }
            if (npc.localAI[0] % 1000 <= 60)
            {
                npc.noTileCollide = true;
                npc.noGravity = true;
                int i = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i].noGravity = true;
                int i2 = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i2].noGravity = true;
                int i3 = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                Main.dust[i3].noGravity = true;
                npc.velocity.X *= 0;
                npc.noTileCollide = true;
                npc.velocity.Y = 1;
                if(npc.alpha < 255)
                {
                    npc.alpha += 5;
                }
            }
            if (npc.localAI[0] % 1000 > 60 && npc.localAI[0] % 1000 <= 240)
            {
                if (npc.localAI[0] % 1000 == 62)
                {
                    npc.alpha = 255;
                    npc.position = player.position + new Vector2(Main.rand.Next(-400,400),-1000);
                    npc.noTileCollide = false;
                    npc.noGravity = false;
                    npc.velocity.Y = 10;
                }
                if (npc.collideY)
                {
                    if(npc.alpha > 249)
                    {
                        vp = npc.Center + new Vector2(-npc.width / 2f, npc.height / 2f - 3);
                    }
                    if (npc.alpha < 150)
                    {
                        npc.dontTakeDamage = false;
                        npc.friendly = false; 
                    }
                    int i = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i].noGravity = true;
                    int i2 = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i2].noGravity = true;
                    int i3 = Dust.NewDust(vp, npc.width, 6, 28, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[i3].noGravity = true;
                    if (npc.alpha > 0)
                    {
                        npc.alpha -= 5;
                    }
                    npc.velocity.X *= 0;
                    npc.velocity.Y = 0;
                }
            }
            if(MythWorld.Myth)
            {
                if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 60 == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1600) * npc.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("DirtBall"), npc.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (npc.life < npc.lifeMax / 2)
                {

                    if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, mod.ProjectileType("DirtSp"), npc.damage / 3, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!MythWorld.Myth && Main.expertMode)
            {
                if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 80 == 0)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1500) * npc.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("DirtBall"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (npc.life < npc.lifeMax / 2)
                {
                    if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, mod.ProjectileType("DirtSp"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!Main.expertMode)
            {
                if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 100 == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(200, 1400) * npc.spriteDirection, Main.rand.Next(-1300, -200)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("DirtBall"), npc.damage / 2, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (npc.life < npc.lifeMax / 2)
                {
                    if (npc.localAI[0] % 1000 > 240 && npc.localAI[0] % 200 == 0)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Vector2 v = player.position + new Vector2(Main.rand.Next(-400, 400), -400);
                            Projectile.NewProjectile(v.X, v.Y, 0, 0, mod.ProjectileType("DirtSp"), npc.damage, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
            }
            if (!player.active || player.dead)
            {
                canDespawn = true;
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.alpha += 5;
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    if (base.npc.alpha >= 254)
                    {
                        base.npc.velocity = new Vector2(0f, 1000f);
                        npc.noTileCollide = true;
                        npc.active = false;
                    }
                    return;
                }
            }
            else
            {
                canDespawn = false;
            }
            npc.localAI[0] += 1;
        }
        private bool canDespawn;
        public override bool PreNPCLoot()
		{
			return true;
		}
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int j = 0; j < 20; j++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 28, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (npc.life <= 0)
            {
                for (int j = 0; j < 40; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 28, (float)hitDirection, -1f, 0, default(Color), 2f);
                }
            }
        }
        public override void NPCLoot()
        {
            bool expertMode = Main.expertMode;
            if (expertMode)
            {
                Item.NewItem((int)base.npc.position.X + 40, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("DirtSpriteTreasureBag"), 1, false, 0, false, false);
            }
            else
            {
                int type = 0;
                switch (Main.rand.Next(1, 7))
                {
                    case 1:
                        type = base.mod.ItemType("Vine");
                        break;
                    case 2:
                        type = base.mod.ItemType("GrassGun");
                        break;
                    case 3:
                        type = base.mod.ItemType("RootStaff");
                        break;
                    case 4:
                        type = base.mod.ItemType("MossRay");
                        break;
                    case 5:
                        type = base.mod.ItemType("MudBlade");
                        break;
                    case 6:
                        type = base.mod.ItemType("VineSlingshot");
                        break;
                }
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 1)
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("DirtSpritePlatfo"), 1, false, 0, false, false);
            }
            if (!MythWorld.downedQDEG)
            {
                MythWorld.downedQDEG = true;
            }
        }
    }
}
