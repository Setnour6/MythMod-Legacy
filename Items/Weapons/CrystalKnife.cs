using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Weapons
{
    public class CrystalKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("晶状体短刃");
            DisplayName.AddTranslation(GameCulture.Chinese, "晶状体短刃");
        }
        public override void SetDefaults()
        {
            item.damage = 11;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 4;
            item.rare = 2;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 4;
            item.useStyle = 1;
            item.knockBack = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
            item.value = 800;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("CrystalKnife");
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
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, mod.ProjectileType("CrystalKnife"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
