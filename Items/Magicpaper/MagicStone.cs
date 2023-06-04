using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class MagicStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("魔法石");
        }
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 40;
            Item.maxStack = 999;
            Item.value = 6000000;
            Item.rare = 1;
        }
    }
}