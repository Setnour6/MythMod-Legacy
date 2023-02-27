using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
    public class AncientVerdant : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("远古葱茏");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            Item.damage = 4000;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 92;
            Item.height = 92;
            Item.useTime = 25;
            Item.rare = 2;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 14f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 24;
            Item.value = 2000000;
            Item.scale = 1f;
            Item.shoot = 1;
            Item.shootSpeed = 14f;
        }
		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine tooltipLine in list)
			{
				if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.OverrideColor = new Color?(new Color(0, 246, 255));
				}
			}
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			switch (Main.rand.Next(1 , 7))
			{
			case 1:
                type = base.Mod.Find<ModProjectile>("火山剑气").Type;
				break;
			case 2:
                type = base.Mod.Find<ModProjectile>("海洋剑气").Type;
				break;
            case 3:
                type = base.Mod.Find<ModProjectile>("林木剑气").Type;
                break;
            case 4:
                type = base.Mod.Find<ModProjectile>("远古剑气").Type;
                break;
            case 5:
                type = base.Mod.Find<ModProjectile>("远古剑气").Type;
                break;
            case 6:
                type = base.Mod.Find<ModProjectile>("远古剑气").Type;
                break;
			}
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(47, 480, false);
        }    
    }
}
