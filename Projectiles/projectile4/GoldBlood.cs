﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile4
{
    public class GoldBlood : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("赤血金鳞");
            Main.projFrames[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 60;
            base.Projectile.height = 60;
            base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.extraUpdates = 24;
            base.Projectile.timeLeft = 602;
            base.Projectile.usesLocalNPCImmunity = false;
            /*base.projectile.localNPCHitCooldown = 400;*/
            base.Projectile.tileCollide = false;
        }
        private float lig = 0;
        private double Rot = 0;
        private float Squ = 0;
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(lig, lig, lig, 0));
        }
        public override void AI()
        {
            Player p = Main.player[Main.myPlayer];
            if (Projectile.timeLeft == 601)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Knife"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                Projectile.position = p.Center + new Vector2(-20, -20).RotatedBy(Projectile.timeLeft / 400d);
                Projectile.scale = 0;
                Rot = Main.rand.NextFloat(-0.5f, 0.5f);
                Squ = Main.rand.NextFloat(0.42f, 1);
            }
            if (Projectile.timeLeft < 601)
            {
                lig = 1f;
                Vector2 v0 = new Vector2(-90 * p.direction, -90).RotatedBy((600 - Projectile.timeLeft) / 400d * Math.PI * p.direction);
                Projectile.position = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                Projectile.scale = (float)Math.Sin(Projectile.timeLeft / 600d * Math.PI) * 6;
                Projectile.rotation = (float)(Math.Atan2((p.Center - Projectile.Center).Y, (p.Center - Projectile.Center).X) + Math.PI / 2d);
                if (Main.rand.Next(200) == 1)
                {
                    Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("RedLightingbolt").Type, 0, 0f, Main.myPlayer, Main.rand.Next(6, 48), 0f);
                }
            }
            /*int num22 = Dust.NewDust(projectile.position - new Vector2(4, 4), projectile.width, projectile.height, mod.DustType("DarkF2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;*/
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Player p = Main.player[Main.myPlayer];
                //spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition, null, new Color(lig, lig, lig, 0), projectile.rotation, new Vector2(1, 10), projectile.scale, SpriteEffects.None, 0f);
                Texture2D texture = Mod.GetTexture("NPCs/Yasitaya/YasitayaBlade");
                int Times = (int)((Math.Sin((500 - Projectile.timeLeft) / 1200d * Math.PI) + 0.15f) * 400f / Math.Log(Projectile.timeLeft + 4));
                for (int y = 0; y < Times; y++)
                {
                    Vector2 v0 = new Vector2(-90 * p.direction, -90).RotatedBy((600 - Projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                    Vector2 v1 = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                    float Rot2 = (float)(Math.Atan2((p.Center - (v1 + new Vector2(15, 15))).Y, (p.Center - (v1 + new Vector2(15, 15))).X) + Math.PI / 2d);
                    float Sca = (float)Math.Sin((Projectile.timeLeft - y * 2f) / 600d * Math.PI) * 6;
                    spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2, 30), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f), Rot2, new Vector2(1, 15), Projectile.scale, SpriteEffects.None, 0f);
                    spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, v1 + new Vector2(15, 15) - Main.screenPosition, new Rectangle(0, 10 - (int)(y / (float)Times * 10), 2, 30), new Color(lig * (Times - y) / 150f, lig * (Times - y) / 150f, lig * (Times - y) / 150f, 0), Rot2, new Vector2(1, 15), Projectile.scale, SpriteEffects.None, 0f);
                    v0 = new Vector2(-72 * p.direction, -72).RotatedBy((600 - Projectile.timeLeft - y * 2f) / 400d * Math.PI * p.direction);
                    v1 = p.Center + new Vector2(v0.X, v0.Y * Squ).RotatedBy(Rot) + new Vector2(-10, 0);
                    Color color2 = Lighting.GetColor((int)(p.Center.X / 16d), (int)(p.Center.Y / 16d));
                    if (y == 0 && p.direction == 1)
                    {
                        spriteBatch.Draw(Mod.GetTexture("NPCs/Yasitaya/YasitayaWeapon"), v1 + new Vector2(15, 15) - Main.screenPosition, null, color2, Rot2 + (float)(Math.PI / 4d * 3 * p.direction), new Vector2(55, 61), 1, SpriteEffects.None, 0f);
                    }
                    if (y == 0 && p.direction == -1)
                    {
                        spriteBatch.Draw(Mod.GetTexture("NPCs/Yasitaya/YasitayaWeapon"), v1 + new Vector2(15, 15) - Main.screenPosition, null, color2, Rot2 + (float)(Math.PI / 4d * 3 * p.direction), new Vector2(55, 61), 1, SpriteEffects.FlipHorizontally, 0f);
                    }
                }
            if (!Main.gamePaused)
            {
                for (int i = 0; i < 200; i++)
                {
                    float K = (Main.npc[i].Center - Projectile.Center).Length();
                    if (Main.npc[i].active && !Main.npc[i].friendly && K < 100 && !Main.npc[i].dontTakeDamage)
                    {
                        bool C = false;
                        if (Main.rand.Next(100) < 35)
                        {
                            C = true;
                        }
                        Main.npc[i].StrikeNPC((int)(200 * Main.rand.NextFloat(0.855f, 1.15f)), 0, 0, C);
                    }
                }
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player p = Main.player[Main.myPlayer];
            target.velocity += (Projectile.Center - p.Center) / (Projectile.Center - p.Center).Length() * 10f;
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}