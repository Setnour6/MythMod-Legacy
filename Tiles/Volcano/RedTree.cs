using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using MythMod.MiscImplementation;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;


namespace MythMod.Tiles.Volcano
{
	public class RedTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("MythMod");
			}
		}

		/*public override int CreateDust()
		{
			return 1;
		}*/

		public override int TreeLeaf()
		{
			return mod.GetGoreSlot("Gores/RedTreeFX");
		}

		public override int DropWood()
		{
			return mod.Find<ModItem>("ShoreWood").Type;
		}

        public override Texture2D GetTexture()
		{
			return mod.GetTexture("Tiles/Volcano/RedTree");
		}

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
            frameWidth = 164;
            frameHeight = 164;
            xOffsetLeft = 82;
            //frame = Main.rand.Next(0, 6);
            return mod.GetTexture("Tiles/Volcano/RedTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Tiles/Volcano/RedTree_Branches");
		}
    }
}