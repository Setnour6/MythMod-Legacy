using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;


namespace MythMod.Items
{
    public class CursedJawbone : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("诅咒颌骨");
			base.Tooltip.SetDefault("在你附近召唤鲜血獠牙，要求血腥环境");
		}
		private bool initialization = true;
        private float X;
        public override void SetDefaults()
        {
            base.item.width = 58;
            base.item.height = 26;
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
			if(NPC.CountNPCS(mod.NPCType("BloodTusk")) < 1 && player.ZoneCrimson)
			{
		    	NPC.NewNPC((int)player.position.X, (int)player.position.Y - 50, mod.NPCType("BloodTusk"), 0, 0f, 0f, 0f, 0f, 255);
	    	    Main.PlaySound(15, player.position, 0);
				return true;
			}
			return false;
		}
		public override void AddRecipes()
        {
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.TissueSample, 40);
				recipe.AddIngredient(ItemID.Vertebrae, 12);
                recipe.SetResult(this, 1);
                recipe.requiredTile[0] = 26;
                recipe.AddRecipe();
            }
        }
	}
}
