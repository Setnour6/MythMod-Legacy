using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons.Clubs
{
    public class BloodLiquidClub : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("灵液棍");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "快速旋转挥舞");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.damage = 50;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 4;
            item.rare = 4;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 11f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 0;
            item.value = 5000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("BloodLiquidClub");
            item.shootSpeed = 0;
        }
        private bool St = false;
        public override void HoldItem(Player player)
        {
            if (!Main.mouseLeft)
            {
                St = false;
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(!St && Main.mouseLeft)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
