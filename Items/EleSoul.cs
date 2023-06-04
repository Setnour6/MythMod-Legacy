using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class EleSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("电雷之魂");
            // Tooltip.SetDefault("闪电，雷暴，台风，骤雨……");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(15, 5));
            ItemID.Sets.AnimatesAsSoul[Item.type] = false;
            ItemID.Sets.ItemIconPulse[Item.type] = true; 
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 999;
            Item.value = 25000;
            Item.rare = 11;
        }
    }
}