using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Critters.NPCs.Sky
{
    public class SandGust : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandy Gust");
			Main.npcFrameCount[npc.type] = 8;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 64;  
			npc.lifeMax = 5;	 
            npc.defense = 0;  
            npc.width = 20;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("SandGustItem");
			banner = npc.type;
			bannerItem = mod.ItemType("SandGustBanner");
            npc.height = 34;
			npc.damage = 0;
			npc.npcSlots = 0;
            npc.noGravity = true;
			npc.dontCountMe = true;
            npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit11;
			npc.DeathSound = SoundID.NPCDeath15;
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
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 32, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.SandstormEvent.Chance * 0.18f;
		}
		public override void NPCLoot ()
		{		
			/*if (Main.rand.Next(2) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Aurora_Bowl"), Main.rand.Next(1, 5));
			}*/
		}
		public override void FindFrame(int frameHeight)
		{
			const int Frame_1 = 0;
			const int Frame_2 = 1;
			const int Frame_3 = 2;
			const int Frame_4 = 3;
			const int Frame_5 = 4;
			const int Frame_6 = 5;
			const int Frame_7 = 6;
			const int Frame_8 = 7;
			
			npc.frameCounter++;
			if (npc.frameCounter < 4)
			{
				npc.frame.Y = Frame_1 * frameHeight;
			}
			else if (npc.frameCounter < 8)
			{
				npc.frame.Y = Frame_2 * frameHeight;
			}
			else if (npc.frameCounter < 12)
			{
				npc.frame.Y = Frame_3 * frameHeight;
			}
			else if (npc.frameCounter < 16)
			{
				npc.frame.Y = Frame_4 * frameHeight;
			}
			else if (npc.frameCounter < 20)
			{
				npc.frame.Y = Frame_5 * frameHeight;
			}
			else if (npc.frameCounter < 24)
			{
				npc.frame.Y = Frame_6 * frameHeight;
			}
			else if (npc.frameCounter < 28)
			{
				npc.frame.Y = Frame_7 * frameHeight;
			}
			else if (npc.frameCounter < 32)
			{
				npc.frame.Y = Frame_8 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}
		}
    }
}