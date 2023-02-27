using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Weapons.Bottle
{
    public class EvilSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("附邪魔剑");
        }
        public override void SetDefaults()
        {
            item.damage = 42;
            item.melee = true;
            item.width = 68;
            item.height = 68;
            item.useTime = 28;
            item.rare = 3;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 8;
            item.value = 6000;
            item.scale = 1f;
            item.shoot = base.mod.ProjectileType("EvilSword");
            item.shootSpeed = 4f;

        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 27, 0f, 0f, 0, default(Color), 2f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 27, 0f, 0f, 0, default(Color), 1.3f);
        }
        private int Cou = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            /*Cou += 1;
            if(Cou % 5 == 0)
            {
                Cou = 0;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("DarkFlameMagicF"), damage, 0f, Main.myPlayer, 0f, 0f);
            }*/
            return true;
        }
    }
}
