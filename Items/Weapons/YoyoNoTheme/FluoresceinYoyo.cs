using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
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

namespace MythMod.Items.Weapons.YoyoNoTheme
{
    public class FluoresceinYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.AddTranslation(GameCulture.Chinese, "荧光素球");
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
            base.Tooltip.AddTranslation(GameCulture.Chinese, "剧毒的果冻");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.useStyle = 5;
            item.width = 30;
            item.height = 26;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.shoot = mod.ProjectileType("FluoresceinYoyo");
            item.useAnimation = 5;
            item.useTime = 14; 
            item.shootSpeed = 0f;
            item.knockBack = 0.2f;
            item.damage = 225;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 11;
            item.alpha = 90;
        }
    }
}
