using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class LazaIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶激光雨符咒");
            Tooltip.SetDefault("降下激光雨\n无精准度可言\n冷却10s");
        }
        public override void SetDefaults()
        {
            item.width = 26;//长度
            item.height = 40;//高度
            item.maxStack = 999;//最大叠加
            item.damage = 370;
            item.value = 24000;//价值
            item.rare = 3;//稀有度
            base.item.useStyle = 2;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.LazaMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for(int t = 0;t < 288;t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    int num = Projectile.NewProjectile(v1.X + Main.rand.Next(-600, 600), v1.Y - 1000 + Main.rand.Next(-4800, 200), v2.X * 4f, v2.Y * 4f, 83, item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[num].friendly = true;
                    Main.projectile[num].hostile = false;
                }
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