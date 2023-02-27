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
	// Token: 0x020003B0 RID: 944
    public class RedGlassSpear : ModItem
	{
		// Token: 0x06001224 RID: 4644 RVA: 0x00084DFC File Offset: 0x00082FFC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "血琉璃长矛");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "让血晶石琉璃刺穿邪恶\n下水增强");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 60;
            base.Item.height = 60;
			base.Item.damage = 120;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.noMelee = true;
			base.Item.useTurn = true;
			base.Item.noUseGraphic = true;
			base.Item.useAnimation = 19;
			base.Item.useStyle = 5;
			base.Item.useTime = 19;
			base.Item.knockBack = 7.5f;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
			base.Item.maxStack = 1;
			base.Item.value = 200000;
			base.Item.rare = 8;
            base.Item.shoot = base.Mod.Find<ModProjectile>("血琉璃长矛").Type;
			base.Item.shootSpeed = 12f;
		}
        private int p = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            p += 1;
            if (player.wet)
            {
                if(p % 2 == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX / 1.2f, speedY / 1.2f, Mod.Find<ModProjectile>("血琉璃长矛3").Type, damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                if (p % 4 == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX / 1.2f, speedY / 1.2f, Mod.Find<ModProjectile>("血琉璃长矛4").Type, damage, knockBack, player.whoAmI);
                }
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("血琉璃长矛2").Type, damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("血琉璃长矛").Type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.damage = 278;
                base.Item.useTime = 19;
                base.Item.useAnimation = 19;
            }
            else
            {
                base.Item.damage = 194;
                base.Item.useTime = 19;
                base.Item.useAnimation = 19;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.Item.position.X + (float)(base.Item.width / 5f)) / 16f), (int)((base.Item.position.Y + (float)(base.Item.height / 1.1f)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
