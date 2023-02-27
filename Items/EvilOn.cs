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
    public class EvilOn : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("恶灵释放卡");
            base.Tooltip.SetDefault("用于释放整个世界的能量,难度和你的收获都将上升\n神话");
        }
        public override void SetDefaults()
        {
            base.item.width = 52;
            base.item.height = 58;
            base.item.expert = true;
            base.item.useAnimation = 45;
            base.item.useTime = 45;
            base.item.useStyle = 4;
            base.item.UseSound = SoundID.Item105;
            base.item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return Main.expertMode;
        }
        public override bool UseItem(Player player)
        {
            bool z = false;
            for(int i = 0;i < 200;i++)
            {
                if(Main.npc[i].active && Main.npc[i].boss)
                {
                    z = true;
                    break;
                }
            }
            if (MythWorld.Myth && !z)
            {
                if (MythWorld.MythIndex < 4)
                {
                    MythWorld.MythIndex += 1;
                }
                else
                {
                    MythWorld.MythIndex = 4;
                }
                string key = "当前神话指数:" + MythWorld.MythIndex.ToString();
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue(key), messageColor);
            }
            return MythWorld.Myth;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this, 1);//制作一个材料
            recipe.AddRecipe();
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(26f, 29f);
            spriteBatch.Draw(base.mod.GetTexture("Items/恶灵释放卡Glow"), base.item.Center - Main.screenPosition, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
