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
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星烛冰海光");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "射出死亡冰冻光球\n下水增强\n神话");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.magic = true;
			base.item.damage = 240;
			base.item.magic = true;
			base.item.mana = 34;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 24;
			base.item.useAnimation = 24;
			base.item.useStyle = 5;
			base.item.noMelee = true;
            base.item.scale = 1f;
			base.item.knockBack = 2.5f;
			base.item.value = 80000;
			base.item.rare = 8;
			base.item.UseSound = SoundID.Item109;
            base.item.autoReuse = true;
			base.item.shootSpeed = 8f;
            base.item.shoot = base.mod.ProjectileType("星烛冰海光");
		}
        // Token: 0x06000B00 RID: 2816 RVA: 0x0005726C File Offset: 0x0005546C
        public override bool CanUseItem(Player player)
        {
            if (player.wet)
            {
                base.item.damage = 250;
                base.item.useTime = 20;
                base.item.useAnimation = 20;
            }
            else
            {
                base.item.damage = 160;
                base.item.useTime = 24;
                base.item.useAnimation = 24;
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
