using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	// Token: 0x0200040F RID: 1039
    public class End : ModItem
	{
		// Token: 0x060013DF RID: 5087 RVA: 0x00090C04 File Offset: 0x0008EE04
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("终结符文");
			base.Tooltip.SetDefault("让一切归于无有\n在玩家正上方召唤终天灭世眼\n无消耗");
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x00051D1C File Offset: 0x0004FF1C
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 18;
			base.item.useAnimation = 45;
			base.item.useTime = 60;
			base.item.useStyle = 4;
			base.item.consumable = false;
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x00035B90 File Offset: 0x00033D90
		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine tooltipLine in list)
			{
				if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
				{
					tooltipLine.overrideColor = new Color?(new Color(43, 96, 222));
				}
			}
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x00007F1C File Offset: 0x0000611C
		// Token: 0x06000C79 RID: 3193 RVA: 0x00006C71 File Offset: 0x00004E71
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(base.mod.NPCType("FinalEye"));
		}
		// Token: 0x060013E3 RID: 5091 RVA: 0x00007F40 File Offset: 0x00006140
		public override bool UseItem(Player player)
		{
			if(NPC.CountNPCS(mod.NPCType("FinalEye")) < 1 && NPC.CountNPCS(mod.NPCType("FinalSeal")) < 1)
			{
			    if(MythWorld.Myth)
		    	{
		    		NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, mod.NPCType("FinalSeal"), 0, 0f, 0f, 0f, 0f, 255);
	    	        Main.PlaySound(15, player.position, 0);
	    	    	return true;
	    		}
		    	else
	    		{
		    		NPC.NewNPC((int)player.position.X, (int)player.position.Y - 750, mod.NPCType("FinalEye"), 0, 0f, 0f, 0f, 0f, 255);
	    	        Main.PlaySound(15, player.position, 0);
	    	    	return true;
	    		}
				return false;
			}
			return false;
		}
		// Token: 0x060013E4 RID: 5092 RVA: 0x00090C5C File Offset: 0x0008EE5C
	}
}
