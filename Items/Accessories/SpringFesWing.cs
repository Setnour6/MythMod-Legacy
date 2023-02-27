using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Accessories
{
    [AutoloadEquip(new EquipType[]
    {
        (Terraria.ModLoader.EquipType)9
    })]
    public class SpringFesWing : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Flameflow Wings");
            base.Tooltip.SetDefault("It can fly in volcano");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "吉祥之翼");
        }
        public override void SetDefaults()
        {
            base.Item.width = 38;
            base.Item.height = 38;
            base.Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = 8;
            base.Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.controlJump && player.wingTime > 0f && !player.jumpAgainCloud && player.jump == 0 && player.velocity.Y != 0f && !hideVisual)
            {
                int num = 4;
                if (player.direction == 1)
                {
                    num = -40;
                }
                int num2 = Dust.NewDust(new Vector2(player.position.X + (float)(player.width / 2) + (float)num, player.position.Y + (float)(player.height / 2) - 15f), 30, 30, 188, 0f, 0f, 100, default(Color), 2.4f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity *= 0.3f;
                if (Main.rand.Next(10) == 0)
                {
                    Main.dust[num2].fadeIn = 2f;
                }
                Main.dust[num2].shader = GameShaders.Armor.GetSecondaryShader(player.cWings, player);
            }
            player.wingTimeMax = 195;
        }
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1f;
            ascentWhenRising = 0.175f;
            maxCanAscendMultiplier = 1.2f;
            maxAscentMultiplier = 3.25f;
            constantAscend = 0.15f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 11f;
            acceleration *= 2.7f;
        }
        //public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        //{
            //base.DrawArmorColor(drawPlayer, shadow, ref color, ref glowMask, ref glowMaskColor);
        //}
    }
}
