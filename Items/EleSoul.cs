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
            DisplayName.SetDefault("电雷之魂");
            Tooltip.SetDefault("闪电，雷暴，台风，骤雨……");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(15, 5));
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            ItemID.Sets.ItemIconPulse[item.type] = true; 
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 25000;
            item.rare = 11;
        }
    }
}