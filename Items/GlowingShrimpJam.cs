using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class GlowingShrimpJam : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("荧光虾酱");
			base.Tooltip.SetDefault("打开盖子,把它丢到海里\n它会吸引一些有趣的东西过来");
		}
		private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
			base.item.width = 20;
			base.item.height = 28;
			base.item.useAnimation = 45;
			base.item.useTime = 60;
			base.item.useStyle = 4;
            base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.shoot = base.mod.ProjectileType("荧光虾酱");
			item.noUseGraphic = true;
			base.item.shootSpeed = 4.8f;
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
        {
        }
		public override bool UseItem(Player player)
		{
			return false;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(10f, 14f);
			spriteBatch.Draw(base.mod.GetTexture("Items/荧光虾酱Glow"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
	}
}
