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
            // base.DisplayName.SetDefault("荧光虾酱");
			// base.Tooltip.SetDefault("打开盖子,把它丢到海里\n它会吸引一些有趣的东西过来");
		}
		private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
			base.Item.width = 20;
			base.Item.height = 28;
			base.Item.useAnimation = 45;
			base.Item.useTime = 60;
			base.Item.useStyle = 4;
            base.Item.maxStack = 999;
			base.Item.consumable = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("荧光虾酱").Type;
			Item.noUseGraphic = true;
			base.Item.shootSpeed = 4.8f;
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
        {
        }
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			return false;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Vector2 origin = new Vector2(10f, 14f);
			spriteBatch.Draw(base.Mod.GetTexture("Items/荧光虾酱Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
		}
	}
}
