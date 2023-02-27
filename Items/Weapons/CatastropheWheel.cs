using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;

namespace MythMod.Items.Weapons
{
    public class CatastropheWheel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("浩劫轮回");
            Tooltip.SetDefault("轮 回 终 尽");
        }
        public override void SetDefaults()
        {
            item.damage = 1000000;
            item.melee = true;
            item.width = 68;
            item.height = 110;
            item.useTime = 21;
            item.rare = 2;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 1.1f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.crit = 6;
            item.value = 800;
            item.scale = 1f;
            item.shoot = mod.ProjectileType("CatastropheWheelKnife");
            item.shootSpeed = 0;
        }
        public override bool CanUseItem(Player player)
        {
            if(!player.name.Contains("万象元素") && player.name != "=w=" && !player.name.Contains("幻象·赤瞳") && !player.name.Contains("红尘"))
            {
                player.lastDeathPostion = player.Center;
                player.lastDeathTime = DateTime.Now;
                player.showLastDeath = true;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.lostCoinString = Main.ValueToCoins(player.lostCoins);
                }
                Main.PlaySound(5, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                if (player.stoned)
                {
                    player.headPosition = Vector2.Zero;
                    player.bodyPosition = Vector2.Zero;
                    player.legPosition = Vector2.Zero;
                }
                for (int j = 0; j < 100; j++)
                {
                    Dust.NewDust(player.position, player.width, player.height, 205, 0f, -2f, 0, default(Color), 1f);
                }
                player.statLife = 0;
                player.dead = true;
                player.respawnTimer = 600;
                player.head = -1;
                player.body = -1;
                player.legs = -1;
                player.handon = -1;
                player.handoff = -1;
                player.back = -1;
                player.front = -1;
                player.shoe = -1;
                player.waist = -1;
                player.shield = -1;
                player.neck = -1;
                player.face = -1;
                player.balloon = -1;
                player.mount.Dismount(player);
                if (Main.expertMode)
                {
                    player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
                }
                player.immuneAlpha = 0;
                player.palladiumRegen = false;
                player.iceBarrier = false;
                player.crystalLeaf = false;
                if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
                {
                    player.DropCoins();
                }
                else if (player.difficulty == 1)
                {
                    player.DropItems();
                }
                else if (player.difficulty == 2)
                {
                    player.DropItems();
                    player.KillMeForGood();
                }
                return false;
            }
            else
            {
                if (player.name == "=w=")
                {
                    return true;
                }
                if (player.name.Contains("万象元素") || player.name.Contains("幻象·赤瞳") || player.name.Contains("红尘"))
                {
                    MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                    mplayer.CatastropheWheel = 30;
                    item.useTime = 22;
                    item.useAnimation = 22;
                    for(int i = 0;i < 200;i++)
                    {
                        if(!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                        {
                            Main.npc[i].StrikeNPC((int)(item.damage * Main.rand.NextFloat(0.85f, 1.15f) / 2f), 1, 0);
                        }
                    }
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 50f)).RotatedByRandom(MathHelper.TwoPi);
                    Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, mod.ProjectileType("CatastropheWheel"), item.damage, item.knockBack, Main.myPlayer, player.direction, 0f);
                    return true;
                }
            }
            return base.UseItem(player);
        }
    }
}
