using Terraria.Audio;
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
            Item.damage = 1000000;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 68;
            Item.height = 110;
            Item.useTime = 21;
            Item.rare = 2;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 1.1f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 6;
            Item.value = 800;
            Item.scale = 1f;
            Item.shoot = Mod.Find<ModProjectile>("CatastropheWheelKnife").Type;
            Item.shootSpeed = 0;
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
                SoundEngine.PlaySound(SoundID.PlayerKilled, player.position);
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
                    Item.useTime = 22;
                    Item.useAnimation = 22;
                    for(int i = 0;i < 200;i++)
                    {
                        if(!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                        {
                            Main.npc[i].StrikeNPC((int)(Item.damage * Main.rand.NextFloat(0.85f, 1.15f) / 2f), 1, 0);
                        }
                    }
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 50f)).RotatedByRandom(MathHelper.TwoPi);
                    Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, Mod.Find<ModProjectile>("CatastropheWheel").Type, Item.damage, Item.knockBack, Main.myPlayer, player.direction, 0f);
                    return true;
                }
            }
            return base.UseItem(player);
        }
    }
}
