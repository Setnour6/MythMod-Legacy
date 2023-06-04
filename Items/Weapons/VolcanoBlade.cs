using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items.Weapons
{
    public class VolcanoBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("�0�10�6�93�0�3�0�0�0�10��0�0�10�0�34�0�10��8�0�10�0�34�0�10�6�06�0�10�6�09�0�10�0�37�0�10�0�34�0�10�6�90�0�10�6�03�0�10�6�00�0�10�6�08�0�10�0�36�0�10�6�85�0�3��0�10�6�74�0�10�6�99�0�10�0�36�0�10�6�93�0�10�0�78�0�3�0�8�0�10��1�0�10�0�39�0�3��");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 185;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 62;
            Item.height = 68;
            Item.useTime = 6;
            Item.rare = 4;
            Item.useAnimation = 14;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 15;
            Item.value = 60000;
            Item.scale = 1f;//�0�10��7���0�3�0�10�0�34�0�10�6�73
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 48; i++)
            {
                int num = Dust.NewDust(target.position, target.width, target.height, 259, target.velocity.X * 0f, target.velocity.Y * 0f, 259, default(Color), 2.4f);
                Main.dust[num].noGravity = true;
            }
            if (target.type == 488)
            {
                return;
            }
            float num1 = (float)damage * 0.04f;
            if ((int)num1 == 0)
            {
                return;
            }
            if (Main.rand.Next(5) == 1)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 2f, 2f, base.Mod.Find<ModProjectile>("�0�10�6�93�0�10�0�78�0�10�6�07�0�10�6�95�0�3�0�8�0�10��1�0�10�0�39�0�3��").Type, damage * 3, knockback, player.whoAmI, 0f, 0f);
            }
            target.AddBuff(24, 600);
        }
        //15343648
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int num = Main.rand.Next(3);
            if (num == 0)
            {
                num = 6;
            }
            else if (num == 1)
            {
                num = 6;
            }
            else
            {
                num = 6;
            }
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, num, 0, 0, 259, default(Color), 1f);
        }
    }
}
