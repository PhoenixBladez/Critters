using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Critters.NPCs;

namespace Critters.NPCs
{
	public class GNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool alchemical = false;
		public override void ResetEffects(NPC npc)
		{

			alchemical = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			bool drain = false;
			if (alchemical)
			{
				drain = true;
				npc.lifeRegen -= 8;
				damage = 4;
			}
		}
		public override void HitEffect(NPC npc, int hitDirection, double damage)
		{
			if (Main.netMode != 1 && npc.life <= 0)
			{
				if(npc.netID == 244)
				{
				Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("BabySlimeRainbow"));
				}
				if (Main.rand.Next(6) == 0)
				{
					if(npc.netID == -3)
					{
					Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
					NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("BabySlimeGreen"));
					}
					if(npc.netID == 1)
					{
					Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
					NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("BabySlimeBlue"));
					}
					if(npc.netID == 147)
					{
					Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
					NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("BabySlimeIce"));
					}
					if(npc.netID == 537)
					{
					Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
					NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("BabySlimeSand"));
					}
				}
			}
		}
	}
}