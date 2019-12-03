using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs
{
	public class UFO : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost UFO");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 32;
			npc.height = 28;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath44;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("UFOItem");
			banner = npc.type;
			bannerItem = mod.ItemType("LostUFOBanner");
			npc.knockBackResist = .45f;
			npc.aiStyle = 64;
			npc.npcSlots = 0;
			npc.noGravity = true;
			aiType = NPCID.Firefly;
			Main.npcFrameCount[npc.type] = 4;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 32;
				npc.height = 32;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 226, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.07f;
					}
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.sky && NPC.downedPlantBoss ? 0.1f : 0f;
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
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .4f, .4f, .4f);
		}
		public override void NPCLoot()
		{
			int Bark = Main.rand.Next(2) + 9;
			for (int J = 0; J <= Bark; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MartianConduitPlating);
			}
		}
	}
}
