using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MythMod.Items.Magicpaper//在虚无mod的Items文件夹里
{
    public class ArrowIII : ModItem//血晶之魂是物件名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("三阶万箭齐发符咒");
            Tooltip.SetDefault("让玩家射出箭雨\n冷却10s");//物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            item.width = 26;//长度
            item.height = 40;//高度
            item.maxStack = 999;//最大叠加
            item.damage = 132;
            item.value = 25000;//价值
            item.rare = 3;//稀有度
            base.item.useStyle = 3;
            item.consumable = true;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.consumable = true;
        }
        public override void HoldItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.ArrowMHold = 2;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.MagicCool == 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        Vector2 speed = (v1 - player.position) / (v1 - player.position).Length();
                        Vector2 v2 = player.position + new Vector2(speed.X, speed.Y) * 14f;
                        Vector2 v = new Vector2(speed.X * 14f, speed.Y * 14f).RotatedBy((float)Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * (0.3f + j / 8f) * Main.rand.Next(25, 40) / 15f;
                        int u = Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, 81, item.damage, 3, player.whoAmI, 0f, 0f);
                        Main.projectile[u].friendly = true;
                        Main.projectile[u].hostile = false;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        Vector2 speed = (v1 - player.position) / (v1 - player.position).Length();
                        Vector2 v2 = player.position + new Vector2(speed.X, speed.Y) * 14f;
                        Vector2 v = new Vector2(speed.X * 14f, speed.Y * 14f).RotatedBy((float)Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * (0.3f + j / 8f) * Main.rand.Next(25, 40) / 15f;
                        int u = Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, 81, item.damage, 3, player.whoAmI, 0f, 0f);
                        Main.projectile[u].friendly = true;
                        Main.projectile[u].hostile = false;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        Vector2 speed = (v1 - player.position) / (v1 - player.position).Length();
                        Vector2 v2 = player.position + new Vector2(speed.X, speed.Y) * 12f;
                        Vector2 v = new Vector2(speed.X * 12f, speed.Y * 12f).RotatedBy((float)Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * (0.3f + j / 8f) * Main.rand.Next(25, 40) / 15f;
                        int u = Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, 82, item.damage, 3, player.whoAmI, 0f, 0f);
                        Main.projectile[u].friendly = true;
                        Main.projectile[u].hostile = false;
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 v1 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                        Vector2 speed = (v1 - player.position) / (v1 - player.position).Length();
                        Vector2 v2 = player.position + new Vector2(speed.X, speed.Y) * 12f;
                        Vector2 v = new Vector2(speed.X * 12f, speed.Y * 12f).RotatedBy((float)Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * (0.3f + j / 8f) * Main.rand.Next(25, 40) / 15f;
                        int u = Projectile.NewProjectile(v2.X, v2.Y - 4, v.X, v.Y, 82, item.damage, 3, player.whoAmI, 0f, 0f);
                        Main.projectile[u].friendly = true;
                        Main.projectile[u].hostile = false;
                    }
                }
                mplayer.MagicCool += 600;
                item.stack--;
                player.AddBuff(mod.BuffType("愚昧诅咒"), 600, true);
            }
            return mplayer.MagicCool > 0;
        }
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}