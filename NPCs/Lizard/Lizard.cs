using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs.Lizard
{
	public class Lizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dusty Lizard");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 22;
			npc.height = 24;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath4;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("LizardItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 7;
			npc.npcSlots = 0;
			npc.noGravity = false;
			aiType = NPCID.ScorpionBlack;
			animationType = NPCID.ScorpionBlack;
									banner = npc.type;
			bannerItem = mod.ItemType("LizardBanner");
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Lizard"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Lizard1"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OverworldDayDesert.Chance * 0.2f;
		}
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
		}
	}
}
