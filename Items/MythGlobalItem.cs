using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MythMod.UI.smartPhone;
using Terraria.ID;
using Terraria.Localization;

namespace MythMod.Items
{
	public class MythGlobalItem : GlobalItem
	{
        public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
        public override bool CloneNewInstances
		{
			get
			{
				return true;
			}
		}

        public override void SetDefaults(Item item)
		{
        }
		public override bool NeedsSaving(Item item)
		{
			return true;
		}
		public override TagCompound Save(Item item)
		{
			TagCompound tagCompound = new TagCompound();
			tagCompound.Add("rarity", this.postMoonLordRarity);
			return tagCompound;
		}
        /*public override Color? GetAlpha(Item item, Color lightColor)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (item.type == 58 && mplayer.PoisonHeart > 0)
            {
                return new Color(0, 0.5f,0.5f,0f);
            }
            return base.GetAlpha(item, lightColor);
        }*/
        public override bool OnPickup(Item item, Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int i = 1;i < 15;i++)
            {
                for (int j = 1; j < 29; j++)
                {
                    if (item.type == smartPhoneMain.FoodKind[i, j])
                    {
                        if(!mplayer.BanFood[i, j])
                        {
                            mplayer.BanFood[i, j] = true;
                            mplayer.FoodExp += 5;
                        }
                    }
                }
            }
            if(item.type == 58 && mplayer.PoisonHeart > 0)
            {
                return false;
            }
            return base.OnPickup(item, player);
        }
        public static int MrC = 0;
        public override void HoldItem(Item item, Player player)
        {
            if (item.type == 1911)
            {
                if (Main.mouseRight)
                {
                    item.createTile = base.mod.TileType("圣诞布丁");
                    item.buffType = -1;
                    item.buffTime = 0;
                    item.useStyle = 1;
                }
                else
                {
                    item.createTile = -1;
                    item.buffType = 26;
                    item.buffTime = 126000;
                    item.useStyle = 2;
                }
            }
            if (item.type == 1787)
            {
                if (Main.mouseRight)
                {
                    item.createTile = base.mod.TileType("南瓜饼");
                    item.buffType = -1;
                    item.buffTime = 0;
                    item.useStyle = 1;
                }
                else
                {
                    item.createTile = -1;
                    item.buffType = 26;
                    item.buffTime = 162000;
                    item.useStyle = 2;
                }
            }
            if (item.type == 2267)
            {
                if (Main.mouseRight)
                {
                    item.createTile = base.mod.TileType("泰式炒面");
                    item.buffType = -1;
                    item.buffTime = 0;
                    item.useStyle = 1;
                }
                else
                {
                    item.createTile = -1;
                    item.buffType = 26;
                    item.buffTime = 36000;
                    item.useStyle = 2;
                }
            }
            if (item.type == 2268)
            {
                if (Main.mouseRight)
                {
                    item.createTile = base.mod.TileType("越南河粉");
                    item.buffType = -1;
                    item.buffTime = 0;
                    item.useStyle = 1;
                }
                else
                {
                    item.createTile = -1;
                    item.buffType = 26;
                    item.buffTime = 54000;
                    item.useStyle = 2;
                }
            }
            if (item.type == 1912)
            {
                if (Main.mouseRight)
                {
                    item.createTile = base.mod.TileType("蛋酒");
                    item.healLife = 0;
                    item.potion = false;
                    item.buffType = -1;
                    item.useStyle = 1;
                }
                else
                {
                    item.createTile = -1;
                    item.healLife = 80;
                    item.potion = true;
                    item.buffType = 21;
                    item.useStyle = 2;
                }
            }
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(item.type == 3124 && mplayer.signal > 0)
            {
                if (Main.mouseRight && MrC == 0 && !smartPhone.Open)
                {
                    MrC = 60;
                    smartPhoneMain.Book = 0;
                    smartPhone.Open = true;
                }
                if(Main.mouseRight && smartPhone.Open && MrC == 0)
                {
                    MrC = 60;
                    smartPhone.Open = false;
                }
            }
            if(item.type != 3124 && item.type != mod.ItemType("Food1") && item.type != mod.ItemType("Food2") && item.type != mod.ItemType("Food3") && item.type != mod.ItemType("Food4") && item.type != mod.ItemType("Food5"))
            {
                smartPhone.Open = false;
            }
            if(MrC > 0)
            {
                MrC -= 1;
            }
            else
            {
                MrC = 0;
            }
            base.HoldItem(item, player);
        }
        public override void MeleeEffects(Item item, Player player, Rectangle hitbox)
        {
            if (player.HasBuff(mod.BuffType("StarSword")))
            {
                Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 87, 0f, 0f, 0, default(Color), 16f);
                Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 235, 0f, 0f, 0, default(Color), 16f);
            }
            base.MeleeEffects(item, player, hitbox);
        }
        public override void Load(Item item, TagCompound tag)
		{
			this.postMoonLordRarity = tag.GetInt("rarity");
		}
        public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (player.HasBuff(mod.BuffType("嗜血狂暴")))
            {
                mplayer.Crazyindex += Main.rand.Next(1, 3);
            }
            if (player.HasBuff(mod.BuffType("StarSword")))
            {
                target.AddBuff(mod.BuffType("XYPoison"), 360, false);
            }
            if(Main.rand.Next(10000) < mplayer.ExpolodePoint)
            {
                for (int i = 0; i < 170; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(item.damage)))).RotatedByRandom(Math.PI * 2);
                    int num5 = Dust.NewDust(new Vector2(item.position.X, item.position.Y), 0, 0, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(item.damage)));
                    Main.dust[num5].velocity = v;
                }
                Main.PlaySound(SoundID.Item14, (int)target.Center.X, (int)target.Center.Y);
                for (int i = 0; i < 200; i++)
                {
                    if ((Main.npc[i].Center - target.position).Length() < Main.npc[i].Hitbox.Width / 2f + 30)
                    {
                        Main.npc[i].StrikeNPC((int)(item.damage * 6 * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1, Main.rand.Next(100) > 50 ? false : true);
                    }
                }
                target.AddBuff(189, 900, false);
            }
            if (Main.rand.Next(10000) < mplayer.LightingPoint)
            {
                Vector2 v1 = target.Center;
                Vector2 v2 = (v1 - new Vector2(v1.X, v1.Y - 1000)) / (v1 - new Vector2(v1.X, v1.Y - 1000)).Length() * 12f + new Vector2(0, 3).RotatedByRandom(MathHelper.Pi * 2);
                v2 = v2 / v2.Length() * 2;
                Projectile.NewProjectile(v1.X + Main.rand.Next(-200, 200), v1.Y - 1500 + Main.rand.Next(-200, 600), v2.X, v2.Y, mod.ProjectileType("LightingBolt"), damage * 20, 0.5f, Main.myPlayer, v1.X, v1.Y);
            }
            if (Main.rand.Next(10000) < mplayer.BloodPoint)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, 0, 305, 1000, 0, Main.myPlayer, 0, damage / 30f);
            }
            if (Main.rand.Next(10000) < mplayer.PoisonPoint)
            {
                target.AddBuff(70, 600, false);
                target.AddBuff(20, 600, false);
            }
            if (Main.rand.Next(10000) < mplayer.FreezingPoint)
            {
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
                {
                    target.AddBuff(mod.BuffType("Freeze"), 360);
                    target.AddBuff(mod.BuffType("Freeze2"), 362);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 360);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 362);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 360);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 362);
                        }
                    }
                }
                Main.PlaySound(2, (int)target.position.X, (int)target.position.Y, 27, 1f, 0f);
                for (int i = 0; i < 30; i++)
                {
                    int num = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 88, 0f, 0f, 100, default(Color), 0.8f);
                    Main.dust[num].velocity *= 0.6f;
                }
                for (int k = 0; k <= 20; k++)
                {
                    float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                    float m = (float)Main.rand.Next(0, 50000);
                    float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                    int num4 = Projectile.NewProjectile(target.Center.X, target.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.06f, (float)((float)l * Math.Sin((float)a)) * 0.06f, base.mod.ProjectileType("FreezeBallBrake"), 25, 0, 255, 0f, 30);
                    Main.projectile[num4].timeLeft = (int)(40 * Main.rand.NextFloat(0.2f, 0.7f));
                }
                Projectile.NewProjectile(target.Center.X, target.Center.Y - 199, 0, 0, base.mod.ProjectileType("IceKill"), 0, 0, 255, 0f, 0);
            }
        }
        public override void LoadLegacy(Item item, BinaryReader reader)
		{
			int num = reader.ReadInt32();
			this.postMoonLordRarity = reader.ReadInt32();
			ErrorLogger.Log("MythMod: Unknown loadVersion: " + num);
		}
		public override void NetSend(Item item, BinaryWriter writer)
		{
			BitsByte bitsByte = default(BitsByte);
			writer.Write(bitsByte);
			writer.Write(this.postMoonLordRarity);
		}
		public override void NetReceive(Item item, BinaryReader reader)
		{
			this.postMoonLordRarity = reader.ReadInt32();
		}
        public override bool CanUseItem(Item item, Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(smartPhone.Open && item.type == 3124)
            {
                return false;
            }
            if (Main.worldName == mplayer.worldnm)
            {
                if(mplayer.BanTra && player.name != "万象元素")
                {
                    if(item.type == 2997 || item.type == 1326 || item.type == 2351 || item.type == mod.ItemType("UnstableTranspStaff") || item.type == 3384 || item.type == 1263 || item.type == 3664 || item.type == 205 || item.type == 206 || item.type == 207 || item.type == 3031 || item.type == 1128)
                    {
                        return false;
                    }
                }
            }
            if (player.behindBackWall && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].wall == mod.WallType("熔岩石墙") && mplayer.ZoneVolcano)
            {
                if (item.pick < 200)
                {
                    return false;
                }
            }
            return true;
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //if (item.useAmmo == 40 && player.HasItem(mod.ItemType("无尽燃烧箭袋")))
            //{
                //int u = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack);
                //Main.projectile[u].noDropItem = true;
            //}
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");
            if(item.type == 320)
            {
                TooltipLine line = new TooltipLine(mod, "Discription","增加:1%闪避,0.25速度,0.5秒飞行时间");
                line.overrideColor = new Color(255, 255, 255);
                tooltips.Add(line);
            }
            if (item.type == 1516)
            {
                TooltipLine line = new TooltipLine(mod, "Discription", "增加:3%闪避,0.6速度,1秒飞行时间");
                line.overrideColor = new Color(255, 255, 255);
                tooltips.Add(line);
            }
            if (item.type == 1517)
            {
                TooltipLine line = new TooltipLine(mod, "Discription", "增加:2%闪避,1%伤害,0.6速度,1秒飞行时间");
                line.overrideColor = new Color(255, 255, 255);
                tooltips.Add(line);
            }
            if (item.type == 1518)
            {
                TooltipLine line = new TooltipLine(mod, "Discription", "增加:2%闪避,4‰概率点燃敌人,0.6速度,1秒飞行时间");
                line.overrideColor = new Color(255, 255, 255);
                tooltips.Add(line);
            }
            if (item.type == 1519)
            {
                TooltipLine line = new TooltipLine(mod, "Discription", "增加:2%闪避,2‰概率冰冻敌人,0.6速度,1秒飞行时间");
                line.overrideColor = new Color(255, 255, 255);
                tooltips.Add(line);
            }

            if (tooltipLine != null)
            {
                switch (this.postMoonLordRarity)
                {
                    case 12:
                        tooltipLine.overrideColor = new Color?(new Color(0, 255, 200));
                        break;
                    case 13:
                        tooltipLine.overrideColor = new Color?(new Color(0, 255, 0));
                        break;
                    case 14:
                        tooltipLine.overrideColor = new Color?(new Color(43, 96, 222));
                        break;
                    case 15:
                        tooltipLine.overrideColor = new Color?(new Color(108, 45, 199));
                        break;
                    case 16:
                        tooltipLine.overrideColor = new Color?(new Color(255, 0, 255));
                        break;
                    case 17:
                        tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, 203, 103));
                        break;
                    case 18:
                        tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, 100, 255));
                        break;
                    case 19:
                        tooltipLine.overrideColor = new Color?(new Color(0, 0, 255));
                        break;
                    case 20:
                        tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
                        break;
                    case 21:
                        tooltipLine.overrideColor = new Color?(new Color(139, 0, 0));
                        break;
                    case 22:
                        tooltipLine.overrideColor = new Color?(new Color(255, 140, 0));
                        break;
                }
            }
        }
		public int postMoonLordRarity;
	}
}
