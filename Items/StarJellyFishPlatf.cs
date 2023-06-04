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
namespace MythMod.Items
{
	// Token: 0x02000212 RID: 530
    public class StarJellyFishPlatf : ModItem
	{
		// Token: 0x060009BA RID: 2490 RVA: 0x00005A27 File Offset: 0x00003C27
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("StarAbyssJellyfish Trophy");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星渊水母纪念章");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 30;
			base.Item.height = 30;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 50000;
			base.Item.rare = 1;
			base.Item.createTile = base.Mod.Find<ModTile>("BossTrophy").Type;
			base.Item.placeStyle = 0;
		}
	}
}
