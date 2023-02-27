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
            DisplayName.SetDefault("魔法石");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.value = 6000000;
            item.rare = 1;
        }
    }
}