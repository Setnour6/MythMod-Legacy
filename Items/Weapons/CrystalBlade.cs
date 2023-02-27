using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Weapons
{
    public class CrystalBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "水晶石之刃");
        }
        public override void SetDefaults()
        {
            item.damage = 480;
            item.melee = true;
            item.width = 90;
            item.height = 100;
            item.useTime = 60;
            item.rare = 11;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 12;
            item.UseSound = SoundID.Item1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 25;
            item.value = 10000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("HugeCrystalSpike");
            item.shootSpeed = 21f;
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (!target.boss)
            {
                target.StrikeNPC(target.life,0,-1);
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage * 3d), knockBack * 10, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
