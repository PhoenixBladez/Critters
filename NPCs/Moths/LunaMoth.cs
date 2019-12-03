using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs.Moths
{
	public class LunaMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luna Moth");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 24;
			npc.damage = 0;
			npc.dontCountMe = true;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("LunaMothItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 64;
			npc.npcSlots = 0;
			npc.noGravity = true;
			banner = npc.type;
			bannerItem = mod.ItemType("LunaMothBanner");
			aiType = NPCID.Butterfly;
			Main.npcFrameCount[npc.type] = 3;
		}
		public override void AI()
		{
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .05f, .18f, .2f);
			npc.spriteDirection = npc.direction;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth3"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.playerSafe && !Main.dayTime && spawnInfo.spawnTileY < Main.rockLayer ? 0.02f : 0f;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
	}
}
