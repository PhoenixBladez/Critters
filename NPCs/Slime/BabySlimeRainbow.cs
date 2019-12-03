using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Critters.NPCs.Slime
{
	public class BabySlimeRainbow : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiny Rainbow Slime");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 16;
			npc.damage = 0;
			npc.defense = 1000;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("BabySlimeRainbow");
			npc.knockBackResist = .45f;
			npc.aiStyle = 1;
			npc.npcSlots = 0;
			npc.noGravity = false;
			aiType = NPCID.RainbowSlime;
			banner = npc.type;
			bannerItem = mod.ItemType("RainbowBannerItem");
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
		

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 20;
				npc.height = 16;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 10; num621++)
				{
					
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 267, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
				public override void AI()
		{
						npc.spriteDirection = -npc.direction;
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .4f, .4f, .4f);
		}
		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 1);
			}
		}
	}
}
