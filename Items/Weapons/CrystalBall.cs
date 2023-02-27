using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Weapons
{
    public class CrystalBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "水晶魔球");
        }
        public override void SetDefaults()
        {
            item.damage = 500;
            item.width = 20;
            item.height = 20;
            item.magic = true;
            item.mana = 2;
            item.useTime = 4;
            item.rare = 11;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 4;
            item.useStyle = 5;
            item.knockBack = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 12;
            item.value = 80000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("CrystalBall");
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
        public override bool CanUseItem(Player player)
        {
            if(player.statMana <= 2)
            {
                item.autoReuse = false;
                return false;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.statMana <= 2)
            {
                player.statMana = 1;
                return false;
            }
            if (!St && Main.mouseLeft && player.statMana > 2)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, mod.ProjectileType("CrystalBall"), damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
