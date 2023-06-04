using System;
using Terraria.Audio;
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
            // base.DisplayName.SetDefault("诅咒颌骨");
			// base.Tooltip.SetDefault("在你附近召唤鲜血獠牙，要求血腥环境");
		}
		private bool initialization = true;
        private float X;
        public override void SetDefaults()
        {
            base.Item.width = 58;
            base.Item.height = 26;
            base.Item.useAnimation = 45;
            base.Item.useTime = 60;
            base.Item.useStyle = 4;
            base.Item.maxStack = 999;
            base.Item.consumable = true;
        }
		public override void ModifyTooltips(List<TooltipLine> list)
		{
		}
		public override void Update(ref float gravity, ref float maxFallSpeed)
        {
        }
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if(NPC.CountNPCS(Mod.Find<ModNPC>("BloodTusk").Type) < 1 && player.ZoneCrimson)
			{
		    	NPC.NewNPC((int)player.position.X, (int)player.position.Y - 50, Mod.Find<ModNPC>("BloodTusk").Type, 0, 0f, 0f, 0f, 0f, 255);
	    	    SoundEngine.PlaySound(SoundID.Roar, player.position);
				return true;
			}
			return false;
		}
		public override void AddRecipes()
        {
            {
                Recipe recipe = CreateRecipe(1);
                recipe.AddIngredient(ItemID.TissueSample, 40);
				recipe.AddIngredient(ItemID.Vertebrae, 12);
                recipe.requiredTile[0] = 26;
                recipe.Register();
            }
        }
	}
}
