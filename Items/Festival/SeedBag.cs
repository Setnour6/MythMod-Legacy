using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

// Token: 0x020001E9 RID: 489
namespace MythMod.Items.Festival
{
	// Token: 0x020001E9 RID: 489
    public class SeedBag : ModItem
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0004B530 File Offset: 0x00049730
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Treasure Bag");
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "种子秘宝袋");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0004C6BC File Offset: 0x0004A8BC
		public override void SetDefaults()
		{
            base.Item.maxStack = 999;
            base.Item.consumable = true;
            base.Item.width = 38;
            base.Item.height = 50;
            base.Item.rare = 4;
            //this.bossBagNPC = mod.NPCType("千年桔树妖");
        }

		// Token: 0x06000911 RID: 2321 RVA: 0x00004588 File Offset: 0x00002788
		public override bool CanRightClick()
		{
			return true;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x0004C730 File Offset: 0x0004A930
		public override void OpenBossBag(Player player)
		{
            int type = 0;
			switch (Main.rand.Next(1 , 5))
			{
			case 1:
                type = base.Mod.Find<ModItem>("PineappleBud").Type;
			    break;
			case 2:
                type = base.Mod.Find<ModItem>("WatermelonSeed").Type;
			    break;
			case 3:
                type = base.Mod.Find<ModItem>("StrawberrySeed").Type;
			    break;
            case 4:
                type = base.Mod.Find<ModItem>("GrapeSeed").Type;
			    break;
			}
            player.QuickSpawnItem(type, Main.rand.Next(1, 7));
		}
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(19f, 25f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Festival/种子秘宝袋Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
