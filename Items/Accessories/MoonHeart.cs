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
namespace MythMod.Items.Accessories
{
    public class MoonHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("幻影之心");
            // base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "幻影之心");
            // Tooltip.SetDefault("增加17%闪避和伤害");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "增加17%闪避和伤害");
        }
        public override void SetDefaults()
        {
            base.Item.width = 44;
            base.Item.height = 32;
            base.Item.value = 50000;
            base.Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.arrowDamage *= 1.17f;
            player.GetDamage(DamageClass.Melee) *= 1.17f;
            player.bulletDamage *= 1.17f;
            player.GetDamage(DamageClass.Magic) *= 1.17f;
            player.GetDamage(DamageClass.Summon) *= 1.17f;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.MoonHeart = 2;
        }
    }
}
