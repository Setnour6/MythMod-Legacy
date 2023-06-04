using Terraria.Audio;
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

namespace MythMod.Items.Weapons
{
    public class Redust : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("孖璟");
            // Tooltip.SetDefault("右键全屏伤害,但也对你自己造成自身1/4血量的伤害\n近战造成撕裂伤害");
        }
        public override void SetDefaults()
        {
            Item.damage = 69;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 88;
            Item.height = 88;
            Item.rare = 8;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = 1;
            Item.knockBack = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 4;
            Item.value = 50000;
            Item.scale = 1f;
            Item.shoot = base.Mod.Find<ModProjectile>("Redust").Type;
            Item.shootSpeed = 9f;

        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.useTime = 21;
                Item.useAnimation = 21;
                Item.reuseDelay = 21;
                Item.autoReuse = false;
                Item.useStyle = 5;
                for (int i = 0; i < 200; i++)
                {
                    if(!Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                    {
                        Main.npc[i].StrikeNPC((int)(Item.damage * 8f * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1, false);
                    }
                }
                if(!player.name.Contains("红尘") && !player.name.Contains("万象元素"))
                {
                    player.statLife -= player.statLifeMax / 4;
                }
                if (player.statLife <= 0)
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
                        Dust.NewDust(player.position, player.width, player.height, 235, 0f, -2f, 0, default(Color), 1f);
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
                    PlayerDeathReason playerDeathReason = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                    NetworkText deathText = playerDeathReason.GetDeathText(player.name);
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
                }
                return true;
            }
            else
            {
                Item.useStyle = 1;
                Item.useTime = 21;
                Item.reuseDelay = 21;
                Item.autoReuse = true;
                Item.useAnimation = 21;
                return true;
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            for (int i = 0; i < 4; i++)
            {
                Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 183, 0f, 0f, 0, default(Color), 1f);
            }
            base.MeleeEffects(player, hitbox);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            damage = 270;
            target.AddBuff(Mod.Find<ModBuff>("Break").Type, 900, false);
            if (Main.rand.Next(100) < 50 + Item.crit)
            {
                crit = true;
            }
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 7f)).RotatedByRandom(Math.PI * 2f);
                int num9 = Dust.NewDust(new Vector2(target.Center.X, target.Center.Y) - new Vector2(8, 8), 0, 0, 183, v.X, v.Y, 100, default(Color), 2.4f);
                Main.dust[num9].noGravity = true;
                if(i % 4 == 1)
                {
                    if (Main.rand.Next(100) < 10 + Item.crit)
                    {
                        target.StrikeNPC((int)(damage / 5f * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1, true);
                    }
                    else
                    {
                        target.StrikeNPC((int)(damage / 5f * Main.rand.NextFloat(0.85f, 1.15f)), 0, 1, false);
                    }
                }
            }
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(368, 1);
            recipe.AddIngredient(501, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("LazarBattery").Type, 12);
            recipe.requiredTile[0] =134;
            recipe.Register();
        }	
    }
}
