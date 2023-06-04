using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class OceanCrystalClub : ModItem
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("蓝晶石棍棒");
        }
        public override void SetDefaults()
        {
            Item.damage = 270;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 74;
            Item.height = 80;
            Item.useTime = 20;
            Item.rare = 8;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 5.0f ;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 27000;
            Item.scale = 1f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //Lighting.AddLight(new Vector2((float)hitbox.X, (float)hitbox.Y), 0 / 255f, 12 / 255f, 220 / 255f);
            Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("Aquamarine").Type, 0f, 0f, 0, default(Color), 1.8f);
        }
    }
}
