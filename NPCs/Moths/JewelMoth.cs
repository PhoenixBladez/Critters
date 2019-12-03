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
	public class JewelMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jewel Moth");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 20;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("JewelMothItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 64;
			npc.npcSlots = 0;
			npc.noGravity = true;
			aiType = NPCID.Butterfly;
						banner = npc.type;
			bannerItem = mod.ItemType("JewelMothBanner");
			Main.npcFrameCount[npc.type] = 3;
		}
		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, 242);
			Main.dust[dust].noGravity = true;
 		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth6"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth4"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.playerSafe && !Main.dayTime && spawnInfo.spawnTileY < Main.rockLayer ? 0.00959f : 0f;
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
