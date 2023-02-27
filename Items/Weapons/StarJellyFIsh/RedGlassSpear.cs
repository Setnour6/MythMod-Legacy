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
            item.glowMask = GetGlowMask;
            base.item.width = 60;
            base.item.height = 60;
			base.item.damage = 120;
			base.item.melee = true;
			base.item.noMelee = true;
			base.item.useTurn = true;
			base.item.noUseGraphic = true;
			base.item.useAnimation = 19;
			base.item.useStyle = 5;
			base.item.useTime = 19;
			base.item.knockBack = 7.5f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.maxStack = 1;
			base.item.value = 200000;
			base.item.rare = 8;
            base.item.shoot = base.mod.ProjectileType("血琉璃长矛");
			base.item.shootSpeed = 12f;
		}
        private int p = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            p += 1;
            if (player.wet)
            {
                if(p % 2 == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX / 1.2f, speedY / 1.2f, mod.ProjectileType("血琉璃长矛3"), damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                if (p % 4 == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX / 1.2f, speedY / 1.2f, mod.ProjectileType("血琉璃长矛4"), damage, knockBack, player.whoAmI);
                }
            }
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            if (player.wet)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("血琉璃长矛2"), damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("血琉璃长矛"), damage, knockBack, player.whoAmI);
            }
            return false;
        }
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.damage = 278;
                base.item.useTime = 19;
                base.item.useAnimation = 19;
            }
            else
            {
                base.item.damage = 194;
                base.item.useTime = 19;
                base.item.useAnimation = 19;
            }
            return base.CanUseItem(player);
        }
        // Token: 0x040001CB RID: 459
        public override void PostUpdate()
        {
            Lighting.AddLight((int)((base.item.position.X + (float)(base.item.width / 5f)) / 16f), (int)((base.item.position.Y + (float)(base.item.height / 1.1f)) / 16f), 0.1f, 0.08f, 0.0f);
        }
	}
}
