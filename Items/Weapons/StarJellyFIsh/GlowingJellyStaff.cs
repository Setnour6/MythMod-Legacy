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
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "荧光果冻杖");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "射出死亡果冻凝胶\n下水增强");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.DamageType = DamageClass.Magic;
			base.Item.damage = 160;
			base.Item.mana = 40;
			base.Item.width = 50;
			base.Item.height = 50;
			base.Item.useTime = 30;
			base.Item.useAnimation = 30;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
            base.Item.scale = 1f;
			base.Item.knockBack = 2.5f;
			base.Item.value = 80000;
			base.Item.rare = 8;
			base.Item.UseSound = SoundID.Item109;
            base.Item.autoReuse = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("胭脂果冻").Type;
			base.Item.shootSpeed = 8f;
            base.Item.reuseDelay = 30;
		}
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(1));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.6f, speedY * 1.6f, Mod.Find<ModProjectile>("SRougeJelly").Type, damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("胭脂果冻").Type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.damage = 250;
                base.Item.useTime = 18;
                base.Item.useAnimation = 18;
                base.Item.reuseDelay = 18;
            }
            else
            {
                base.Item.damage = 160;
                base.Item.useTime = 30;
                base.Item.useAnimation = 30;
                base.Item.reuseDelay = 30;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 2)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 2)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
