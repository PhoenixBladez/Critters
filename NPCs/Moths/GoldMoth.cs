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
	public class GoldMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Moth");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 24;
			npc.height = 20;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.dontCountMe = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("GoldMothItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 64;
			npc.rarity = 3;
			banner = npc.type;
			bannerItem = mod.ItemType("GoldMothBanner");
			npc.npcSlots = 0;
			npc.noGravity = true;
			aiType = NPCID.Butterfly;
			Main.npcFrameCount[npc.type] = 3;
		}
		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
			int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldCoin);
			Main.dust[dust].noGravity = true;
 		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth7"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Moth5"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.playerSafe && !Main.dayTime ? 0.0007666f : 0f;
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
