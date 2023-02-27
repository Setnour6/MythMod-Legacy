using MythMod.NPCs;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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

namespace MythMod.Items
{
    public class EvilCocoon : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("魔茧");
			base.Tooltip.SetDefault("在你附近召唤腐檀巨蛾，要求腐化环境");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 20;
			base.item.height = 32;
			base.item.useAnimation = 45;
			base.item.useTime = 60;
			base.item.useStyle = 4;
            base.item.maxStack = 999;
			base.item.consumable = true;
		}
		public override void ModifyTooltips(List<TooltipLine> list)
		{
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
        {
        }
		public override bool UseItem(Player player)
		{
			if(NPC.CountNPCS(mod.NPCType("CorruptMoth")) < 1 && player.ZoneCorrupt)
			{
				if(Main.rand.Next(100000) > 50000)
				{
					NPC.NewNPC((int)player.position.X - 500, (int)player.position.Y + 800, mod.NPCType("CorruptMoth"), 0, 0f, 0f, 0f, 0f, 255);
	    	        Main.PlaySound(15, player.position, 0);
			    	return true;
				}
				else
				{
					NPC.NewNPC((int)player.position.X + 500, (int)player.position.Y + 800, mod.NPCType("CorruptMoth"), 0, 0f, 0f, 0f, 0f, 255);
	    	        Main.PlaySound(15, player.position, 0);
			    	return true;
				}
			}
			return false;
		}
		public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.ShadowScale, 40);
				recipe.AddIngredient(ItemID.WormTooth, 5);
				recipe.AddIngredient(ItemID.VilePowder, 30);
                recipe.SetResult(this, 1);
                recipe.requiredTile[0] = 26;
                recipe.AddRecipe();
            }
        }
	}
}
