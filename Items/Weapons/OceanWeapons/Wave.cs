using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using System;

namespace MythMod.Items.Weapons.OceanWeapons
{
    public class Wave : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "波江");
        }
        private int num = 0;
        private bool k = true;
        public override void SetDefaults()
        {
            Item.damage = 222;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 68;
            Item.height = 68;
            Item.useTime = 29;
            Item.rare = 11;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 7;
            Item.value = 14000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("Wave").Type;
            Item.shootSpeed = 5f;
            Item.useTurn = false;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(Main.rand.Next(100) > 10)
            {
                int num = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("WaveBallMini").Type, Item.damage * 2, Item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[num].timeLeft = 1;
            }
            else
            {
                int num = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("WaveBall").Type, Item.damage * 10, Item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[num].timeLeft = 1;
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("Wave").Type, 0f, 0f, 0,  default(Color), 0.6f);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 vp0 = new Vector2(-100f * player.direction + player.width / 2f, -50f).RotatedBy(0) + player.position;
            Vector2 pc = player.position + new Vector2(player.width, player.height) / 2;
            Projectile.NewProjectile(pc.X, pc.Y, 0, 0, Mod.Find<ModProjectile>("WaveShader").Type, 0, 0, player.whoAmI);
            return false;
        }
    }
}
