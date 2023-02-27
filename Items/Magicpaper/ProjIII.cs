using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class ProjIII : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶弹球符咒");
            Tooltip.SetDefault("释放若干个高速弹球和很多小弹球\n冷却10s");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            Item.width = 26;//长度
            Item.height = 40;//高度
            Item.maxStack = 999;//最大叠加
            Item.damage = 362;
            Item.value = 8000;//价值
            Item.rare = 2;//稀有度
            base.Item.useStyle = 1;
            Item.consumable = true;
            base.Item.useAnimation = 17;
            base.Item.useTime = 17;
            base.Item.consumable = true;
        }

        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.ProjMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(mplayer.MagicCool == 0)
            {
                Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                Vector2 v2 = (v1 - player.Center).RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f)) / (v1 - player.Center).Length() * 10f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X * 1.2f, v2.Y * 1.2f, Mod.Find<ModProjectile>("HighSpeedBall").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                v2 = (v1 - player.Center).RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f)) / (v1 - player.Center).Length() * 10f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X * 1.27f, v2.Y * 1.27f, Mod.Find<ModProjectile>("HighSpeedBall").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                v2 = (v1 - player.Center).RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f)) / (v1 - player.Center).Length() * 10f;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X * 1.4f, v2.Y * 1.4f, Mod.Find<ModProjectile>("HighSpeedBall").Type, Item.damage, 0.5f, Main.myPlayer, 10f, 25f);
                for (int i = 0; i < 15; i++)
                {
                    Vector2 v3 = new Vector2(0, Main.rand.NextFloat(0f, 6f)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, v2.X + v3.X, v2.Y + v3.Y, Mod.Find<ModProjectile>("JellyBall").Type, Item.damage / 3, 0.5f, Main.myPlayer, 10f, 25f);
                }
                mplayer.MagicCool += 600;
                Item.stack--;
                player.AddBuff(Mod.Find<ModBuff>("愚昧诅咒").Type, 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}