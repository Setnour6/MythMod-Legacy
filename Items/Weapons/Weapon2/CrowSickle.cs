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
namespace MythMod.Items.Weapons.Weapon2
{
    public class CrowSickle : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.AddTranslation(GameCulture.Chinese, "凶鸦夺命镰");
            // Tooltip.SetDefault("厄运降临");
        }
        public override void SetDefaults()
        {
            Item.damage = 230;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 52;
            Item.height = 62;
            Item.useTime = 18;
            Item.rare = 11;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 22;
            Item.value = 80000;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("CrowSickle").Type;
            Item.shootSpeed = 4f;
        }
        private int a = 0;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("CrowSickle").Type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            return false;
        }
    }
}
