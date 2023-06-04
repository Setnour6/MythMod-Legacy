using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
namespace MythMod.Items.Weapons.FestivalWeapons
{ 
    public class OrangeBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
            // DisplayName.SetDefault("桔之锋");
        }
        public override void SetDefaults()
        {
            Item.damage = 420;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 62;
            Item.height = 76;
            Item.useTime = 60;
            Item.useAnimation = 30;
            Item.useStyle = 1;
            Item.knockBack = 7;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 8;
            Item.value = 100000;
            Item.rare = 11;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("TangerineBlade").Type;
            Item.shootSpeed = 4f;

        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if(Main.rand.Next(15) == 1)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(hitbox.X + Main.rand.NextFloat(hitbox.Width), hitbox.Y + Main.rand.NextFloat(hitbox.Height), v.X, v.Y, Mod.Find<ModProjectile>("Tangerine2").Type, (int)(Item.damage), base.Item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
            if (Main.rand.Next(5) == 1)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(hitbox.X + Main.rand.NextFloat(hitbox.Width), hitbox.Y + Main.rand.NextFloat(hitbox.Height), v.X, v.Y, Mod.Find<ModProjectile>("TangerineLeaf").Type, (int)(Item.damage), base.Item.knockBack, Main.myPlayer, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
    }
}
