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
    public class FlowFireWing : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Flameflow Wings");
            base.Tooltip.SetDefault("It can fly in volcano");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "流火之翼");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "可以在火山飞行");
        }
        public override void SetDefaults()
        {
            base.item.width = 38;
            base.item.height = 38;
            base.item.value = Item.buyPrice(0, 40, 0, 0);
            item.rare = 11;
            base.item.accessory = true;
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
                Vector2 v = new Vector2(0, Main.rand.Next(0, 20)).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, player.velocity.X * 1.2f, player.velocity.Y * 1.2f, base.mod.ProjectileType("熔炉烈焰"), 200, 0, Main.myPlayer, Main.rand.Next(2500, 3200) / 4000f, 0f);
            }
            player.wingTimeMax = 261;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.VIm = 2;
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
            speed = 10f;
            acceleration *= 2.7f;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Accessories/流火之翼Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        //public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        //{
            //base.DrawArmorColor(drawPlayer, shadow, ref color, ref glowMask, ref glowMaskColor);
        //}
    }
}
