using Terraria.DataStructures;
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
            Item.damage = 500;
            Item.width = 20;
            Item.height = 20;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.useTime = 4;
            Item.rare = 11;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 4;
            Item.useStyle = 5;
            Item.knockBack = 1.1f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 12;
            Item.value = 80000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("CrystalBall").Type;
            Item.shootSpeed = 0;
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
                Item.autoReuse = false;
                return false;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.statMana <= 2)
            {
                player.statMana = 1;
                return false;
            }
            if (!St && Main.mouseLeft && player.statMana > 2)
            {
                St = true;
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, Mod.Find<ModProjectile>("CrystalBall").Type, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            return false;
        }
    }
}
