using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;


namespace MythMod.Items.Weapons
{
	// Token: 0x020003FC RID: 1020
    public class ShinyFireII : ModItem
	{
		// Token: 0x06001381 RID: 4993 RVA: 0x0008E404 File Offset: 0x0008C604
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火树银花II");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "让它在夜空中绽放吧！\n绚烂无比，但是会迅速耗尽你的法力");
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x0008E45C File Offset: 0x0008C65C
		public override void SetDefaults()
		{
			base.item.damage = 12000;
			base.item.magic = true;
			base.item.mana = 300;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 160;
			base.item.useAnimation = 160;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 15f;
			base.item.value = 200000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item14;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("焰火Ex");
			base.item.shootSpeed = 3.2f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = 0.7854f;
			double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)(num / 2f);
			double num3 = (double)(num / 8f);
            for (int i = 0; i < 4; i++)
            {
                double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
            }
            int num5 = 0;
			for (int j = 0; j < 48; j++)
            {
			int num7 = Main.rand.Next(0, 100000);
			int num8 = Main.rand.Next(0, (int)num7) / 10000;
            int num6 = Dust.NewDust(position, 2, 2, 174, speedX * (float)num8, speedY * (float)num8, 0, Color.Orange, 1.6f);
            Main.dust[num6].noGravity = false;
            Main.dust[num6].scale *=  0.8f;
            Main.dust[num6].alpha = 200;
			}
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.3f + num5, speedY * 1.3f + num5, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
        }
	}
}
