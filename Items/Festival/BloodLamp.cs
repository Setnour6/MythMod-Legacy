using MythMod.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MythMod.UI.SpringAct;

namespace MythMod.Items.Festival
{
    public class BloodLamp : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("血莲灯");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "召唤灯笼月");
        }
        public override void SetDefaults()
        {
            base.Item.width = 38;//宽
            base.Item.height = 60;//高
            base.Item.rare = 2;//品质
            base.Item.scale = 1f;//大小
            base.Item.useStyle = 4;
            base.Item.useTurn = true;
            base.Item.useAnimation = 30;
            base.Item.useTime = 30;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.maxStack = 999;
            base.Item.value = 10000;
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();

            if (!mplayer.LanternMoon && !Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon)
            {
                mplayer.LanternMoon = true;
                mplayer.LanternMoonPoint = 0;
                mplayer.PerWavePoint = 80;
                mplayer.Moon2 = 0;
                mplayer.LanternMoonWave = 1;
                mplayer.OldWavePoint = 0;
                Color messageColor = Color.MediumPurple;
                Color messageColor1 = Color.PaleGreen;
                Main.NewText(Language.GetTextValue("灯笼月正在升起"), messageColor1);
                Main.NewText(Language.GetTextValue("波数: 1:吉祥僵尸"), messageColor);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(19f, 30f);
            spriteBatch.Draw(base.Mod.GetTexture("Items/Festival/血莲灯Glow"), base.Item.Center - Main.screenPosition, null, new Color(255,255,255,0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);//制作一个材料
            recipe.AddIngredient(344, 1);
            recipe.AddIngredient(316, 1);
            recipe.AddIngredient(314, 1);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
