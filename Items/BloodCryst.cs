using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class BloodCryst : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("血晶状体");
            Tooltip.SetDefault("只有撕裂巨型眼球时喷涌出的血液才能造就这种稀世珍品\n神话");
            ItemID.Sets.AnimatesAsSoul[Item.type] = false;
            ItemID.Sets.ItemIconPulse[Item.type] = false;
            ItemID.Sets.ItemNoGravity[Item.type] = false;
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            Item.width = refItem.width;
            Item.height = refItem.height;
            Item.maxStack = 999;
            Item.value = 12000;
            Item.rare = 3;
        }
    }
}