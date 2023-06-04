using MythMod.NPCs;
using Terraria.Audio;
using Terraria.GameContent.Generation;
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
using Terraria.WorldBuilding;

namespace MythMod.Items
{
    public class EvilCocoon : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("魔茧");
			// base.Tooltip.SetDefault("在你附近召唤腐檀巨蛾，要求腐化环境");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 20;
			base.Item.height = 32;
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
			if(NPC.CountNPCS(Mod.Find<ModNPC>("CorruptMoth").Type) < 1 && player.ZoneCorrupt)
			{
				if(Main.rand.Next(100000) > 50000)
				{
					NPC.NewNPC((int)player.position.X - 500, (int)player.position.Y + 800, Mod.Find<ModNPC>("CorruptMoth").Type, 0, 0f, 0f, 0f, 0f, 255);
	    	        SoundEngine.PlaySound(SoundID.Roar, player.position);
			    	return true;
				}
				else
				{
					NPC.NewNPC((int)player.position.X + 500, (int)player.position.Y + 800, Mod.Find<ModNPC>("CorruptMoth").Type, 0, 0f, 0f, 0f, 0f, 255);
	    	        SoundEngine.PlaySound(SoundID.Roar, player.position);
			    	return true;
				}
			}
			return false;
		}
		public override void AddRecipes()
        {
            {
                Recipe recipe = CreateRecipe(1);
                recipe.AddIngredient(ItemID.ShadowScale, 40);
				recipe.AddIngredient(ItemID.WormTooth, 5);
				recipe.AddIngredient(ItemID.VilePowder, 30);
                recipe.requiredTile[0] = 26;
                recipe.Register();
            }
        }
	}
}
