using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Items.Magicpaper
{
    public class CoinIII : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("三阶金银雨符咒");
            // Tooltip.SetDefault("从天降钱\n全屏范围\n冷却10s");
        }
        public override void SetDefaults()
        {
            Item.width = 26;//长度
            Item.height = 40;//高度
            Item.maxStack = 999;//最大叠加
            Item.damage = 300;
            Item.value = 24000;//价值
            Item.rare = 3;//稀有度
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.CoinMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                for (int t = 0; t < 18; t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    int num = Projectile.NewProjectile(v1.X + Main.rand.Next(-600, 600), v1.Y - 1000 + Main.rand.Next(-900, 200), v2.X * 4f * 0.15f, v2.Y * 4f * 0.015f, Mod.Find<ModProjectile>("CuCoin").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[num].frame = Main.rand.Next(0, 4);
                }
                for (int t = 0; t < 18; t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    int num = Projectile.NewProjectile(v1.X + Main.rand.Next(-600, 600), v1.Y - 1000 + Main.rand.Next(-900, 200), v2.X * 4f * 0.15f, v2.Y * 4f * 0.015f, Mod.Find<ModProjectile>("AgCoin").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[num].frame = Main.rand.Next(0, 4);
                }
                for (int t = 0; t < 18; t++)
                {
                    Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                    int num = Projectile.NewProjectile(v1.X + Main.rand.Next(-600, 600), v1.Y - 1000 + Main.rand.Next(-900, 200), v2.X * 4f * 0.15f, v2.Y * 4f * 0.015f, Mod.Find<ModProjectile>("AuCoin").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[num].frame = Main.rand.Next(0, 4);
                }
                mplayer.MagicCool += 600;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
                Item.stack--;
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}