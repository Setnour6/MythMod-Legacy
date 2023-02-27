using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class SolarSwirl : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("日炎双杀");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "快速旋转挥舞可以反射敌人的攻击，且反射后伤害提高10倍\n对高速密集弹幕或激光及不可反射弹幕无效\n神话");
        }
        public override void SetDefaults()
        {
            item.damage = 200;
            item.melee = true;
            item.width = 44;
            item.height = 50;
            item.useTime = 4;
            item.rare = 8;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 14;
            item.value = 50000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("SolarKnife");
            item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
            if (!Main.mouseLeft)
            {
                St = false;
            }
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Ry = 2;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Vector2 origin = new Vector2(item.width / 2f, item.height / 2f);
            spriteBatch.Draw(base.mod.GetTexture("Items/Weapons/日炎双杀Glow"), base.item.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), rotation, origin, 1f, SpriteEffects.None, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(!St && Main.mouseLeft)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, mod.ProjectileType("SolarKnife"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
