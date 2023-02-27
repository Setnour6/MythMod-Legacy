using System;
using Terraria;
using Terraria.DataStructures;
//using MythMod.UI.YinYangLife;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items
{
    public class EvilOff : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("恶灵封印卡");
            base.Tooltip.SetDefault("用于封印整个世界的能量,难度和你的收获都将下降\n神话");
        }
        public override void SetDefaults()
        {
            base.Item.width = 52;
            base.Item.height = 58;
            base.Item.expert = true;
            base.Item.useAnimation = 45;
            base.Item.useTime = 45;
            base.Item.useStyle = 4;
            base.Item.UseSound = SoundID.Item105;
            base.Item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.expertMode;
        }
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            bool z = false;
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    z = true;
                    break;
                }
            }
            if (MythWorld.Myth && !z)
            {
                if (MythWorld.MythIndex > 1)
                {
                    MythWorld.MythIndex -= 1;
                }
                else
                {
                    MythWorld.MythIndex = 1;
                }
                string key = "当前神话指数:" + MythWorld.MythIndex.ToString();
                Color messageColor = Color.Gold;
                Main.NewText(Language.GetTextValue(key), messageColor);
            }
            return MythWorld.Myth;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//制作一个材料
            recipe.Register();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(26f, 29f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/恶灵封印卡Glow"), base.Item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
