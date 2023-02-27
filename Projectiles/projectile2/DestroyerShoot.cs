﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile2
{
    // Token: 0x02000618 RID: 1560
    public class DestroyerShoot : ModProjectile
    {
        // Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("毁灭者剑气");

        }

        // Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
        public override void SetDefaults()
        {
            base.projectile.width = 20;
            base.projectile.height = 20;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
        }

        // Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
        public override void AI()
        {
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 11; k++)
            {
                float num4 = base.projectile.position.X + (float)Main.rand.Next(-1000, 1000);
                float num5 = base.projectile.position.Y - (float)Main.rand.Next(500, 800);
                Vector2 vector = new Vector2(num4, num5);
                float num6 = base.projectile.position.X + (float)(base.projectile.width / 2) - vector.X;
                float num7 = base.projectile.position.Y + (float)(base.projectile.height / 2) - vector.Y;
                num6 += (float)Main.rand.Next(-100, 101);
                int num8 = 25;
                float num9 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
                num9 = (float)num8 / num9;
                num6 *= num9;
                num7 *= num9;
                if (base.projectile.owner == Main.myPlayer)
                {
                    int num11 = Main.rand.Next(1, 5);
                    if (num11 == 1)
                    {
                        int num10 = Projectile.NewProjectile(num4, num5, num6, num7, 100, base.projectile.damage, 5f, base.projectile.owner, 0f, 0f);
                        Main.projectile[num10].hostile = false;
                        Main.projectile[num10].friendly = true;
                    }
                    if (num11 == 2)
                    {
                        int num10 = Projectile.NewProjectile(num4, num5, num6, num7, 100, base.projectile.damage, 5f, base.projectile.owner, 0f, 0f);
                        Main.projectile[num10].hostile = false;
                        Main.projectile[num10].friendly = true;
                    }
                    if (num11 == 3)
                    {
                        int num10 = Projectile.NewProjectile(num4, num5, num6, num7, 100, base.projectile.damage, 5f, base.projectile.owner, 0f, 0f);
                        Main.projectile[num10].hostile = false;
                        Main.projectile[num10].friendly = true;
                    }
                    if (num11 == 5)
                    {
                        int num10 = Projectile.NewProjectile(num4, num5, num6, num7, 100, base.projectile.damage, 5f, base.projectile.owner, 0f, 0f);
                        Main.projectile[num10].hostile = false;
                        Main.projectile[num10].friendly = true;
                    }
                    if (num11 == 4)
                    {
                        int num10 = Projectile.NewProjectile(num4, num5, num6, num7, 100, base.projectile.damage, 5f, base.projectile.owner, 0f, 0f);
                        Main.projectile[num10].hostile = false;
                        Main.projectile[num10].friendly = true;
                    }
                }
            }
        }
    }
}
