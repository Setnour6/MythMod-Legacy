using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class LighIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶闪电符咒");
            Tooltip.SetDefault("劈下一道闪电穿过你的鼠标\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.maxStack = 999;
            item.damage = 7500;
            item.value = 50000;
            item.rare = 3;
            base.item.useStyle = 2;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            item.noMelee = true;
            base.item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.ElectricMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                v2 = v2 / v2.Length() * 2;
                Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1500 + Main.rand.Next(-200, 600), v2.X, v2.Y, mod.ProjectileType("LightingBolt"), item.damage, 0.5f, Main.myPlayer, v1.X, v1.Y);
                mplayer.MagicCool += 600;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
                item.stack--;
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}