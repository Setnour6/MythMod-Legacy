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
            Tooltip.SetDefault("厄运降临");
        }
        public override void SetDefaults()
        {
            item.damage = 230;
            item.melee = true;
            item.width = 52;
            item.height = 62;
            item.useTime = 18;
            item.rare = 11;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 22;
            item.value = 80000;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("CrowSickle");
            item.shootSpeed = 4f;
        }
        private int a = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int u = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CrowSickle"), (int)((double)damage), knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[u].rotation = Main.rand.NextFloat((MathHelper.TwoPi));
            return false;
        }
    }
}
