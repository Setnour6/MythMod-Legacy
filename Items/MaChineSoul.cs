using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items
{
    public class MaChineSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("机械之魂");
            Tooltip.SetDefault("");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true; 
        }
        public override void SetDefaults()
        {
            Item refItem = new Item();
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 3333;
            item.rare = 9;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            maxFallSpeed *= 0f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(11f, 24f);
            spriteBatch.Draw(base.mod.GetTexture("Items/机械之魂Glow"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}