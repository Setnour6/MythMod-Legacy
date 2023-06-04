using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
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
namespace MythMod.Items.Weapons.StarJellyFIsh
{
	// Token: 0x02000254 RID: 596
    public class LightOfFrozenSea : ModItem
	{
        private int num = 0;
		// Token: 0x06000AFF RID: 2815 RVA: 0x00057200 File Offset: 0x00055400
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星烛冰海光");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "射出死亡冰冻光球\n下水增强\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.DamageType = DamageClass.Magic;
			base.Item.damage = 240;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 34;
			base.Item.width = 28;
			base.Item.height = 30;
			base.Item.useTime = 24;
			base.Item.useAnimation = 24;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
            base.Item.scale = 1f;
			base.Item.knockBack = 2.5f;
			base.Item.value = 80000;
			base.Item.rare = 8;
			base.Item.UseSound = SoundID.Item109;
            base.Item.autoReuse = true;
			base.Item.shootSpeed = 8f;
            base.Item.shoot = base.Mod.Find<ModProjectile>("星烛冰海光").Type;
		}
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.Item.damage = 250;
                base.Item.useTime = 20;
                base.Item.useAnimation = 20;
            }
            else
            {
                base.Item.damage = 160;
                base.Item.useTime = 24;
                base.Item.useAnimation = 24;
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
