using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Weapons.SkyWeapons
{
    public class SunRise : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "海日");
            Tooltip.AddTranslation(GameCulture.Chinese, "日出的幻景\n最后的一次日出");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 200;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 90;
            Item.height = 100;
            Item.useTime = 60;
            Item.rare = 11;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 12;
            Item.UseSound = SoundID.Item1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 25;
            Item.value = 10000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("SunRise").Type;
            Item.shootSpeed = 3f;
        }
        public override Vector2? HoldoutOffset()
        {
            return base.HoldoutOrigin();    
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.boss)
            {
                target.StrikeNPC(target.life,0,-1);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, (int)((double)damage), 0, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
