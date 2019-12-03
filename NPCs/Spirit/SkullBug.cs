using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SpiritMod;

namespace Critters.NPCs.Spirit
{
	public class SkullBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skruller");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.width = 28;
			npc.dontCountMe = true;
			npc.height = 20;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath4;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("SkullBugItem");
			npc.knockBackResist = .45f;
			npc.aiStyle = 67;
			npc.npcSlots = 0;
			aiType = NPCID.Snail;
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
				if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SkullBug1"), 1f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			var spirit = ModLoader.GetMod("SpiritMod");
			if(spirit != null)
			{
			SpiritMod.MyPlayer spiritPlayer = spawnInfo.player.GetModPlayer<SpiritMod.MyPlayer>();
			
			return spiritPlayer.ZoneReach && Main.dayTime ? 1.75f : 0f;
			}
			else
			return 0;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
		public override void AI()
		{
			npc.spriteDirection = -npc.direction;
		}
			public override void NPCLoot()
		{
			if (Main.rand.Next(22) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Skull"), 1);
			}
		}
	}
}
