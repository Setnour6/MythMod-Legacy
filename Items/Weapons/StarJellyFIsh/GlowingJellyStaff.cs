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
namespace MythMod.Items.Weapons.StarJellyFIsh
{
	// Token: 0x02000254 RID: 596
    public class GlowingJellyStaff : ModItem
	{
		// Token: 0x06000AFF RID: 2815 RVA: 0x00057200 File Offset: 0x00055400
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "荧光果冻杖");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "射出死亡果冻凝胶\n下水增强");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.magic = true;
			base.item.damage = 160;
			base.item.mana = 40;
			base.item.width = 50;
			base.item.height = 50;
			base.item.useTime = 30;
			base.item.useAnimation = 30;
			base.item.useStyle = 5;
			base.item.noMelee = true;
            base.item.scale = 1f;
			base.item.knockBack = 2.5f;
			base.item.value = 80000;
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item109;
            base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("胭脂果冻");
			base.item.shootSpeed = 8f;
            base.item.reuseDelay = 30;
		}
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, mod.ProjectileType("SRougeJelly"), damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("胭脂果冻"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.damage = 250;
                base.item.useTime = 18;
                base.item.useAnimation = 18;
                base.item.reuseDelay = 18;
            }
            else
            {
                base.item.damage = 160;
                base.item.useTime = 30;
                base.item.useAnimation = 30;
                base.item.reuseDelay = 30;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 2)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
