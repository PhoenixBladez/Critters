using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs.Ocean
{
	public class Floater : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminous Floater");
			Main.npcFrameCount[npc.type] = 40;
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 22;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit25;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("FloaterItem");
			npc.DeathSound = SoundID.NPCDeath28;
			npc.knockBackResist = .35f;
			npc.aiStyle = 18;
			npc.noGravity = true;
			npc.npcSlots = 0;
			aiType = NPCID.PinkJellyfish;
			banner = npc.type;
			bannerItem = mod.ItemType("FloaterBanner");
		}
		bool txt = false;
		public override bool PreAI()
		{
		if(!txt)
		{
			for (int i = 0; i < 8; ++i)
			{
             Vector2 dir = Main.player[npc.target].Center - npc.Center;
             dir.Normalize();
             dir *= 1;
             int newNPC = NPC.NewNPC((int)npc.Center.X + (Main.rand.Next(-20, 20)), (int)npc.Center.Y + (Main.rand.Next(-20, 20)), mod.NPCType("Floater1"), npc.whoAmI);
              Main.npc[newNPC].velocity = dir;
			}
			txt = true;
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), .3f, .2f, .3f);
		}
			return true;
		}
		

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe || Main.dayTime)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 0.173f;
		}
			public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/Floater_Critter_Glow"));
        }

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				npc.position.X = npc.position.X + (float)(npc.width / 2);
				npc.position.Y = npc.position.Y + (float)(npc.height / 2);
				npc.width = 30;
				npc.height = 30;
				npc.position.X = npc.position.X - (float)(npc.width / 2);
				npc.position.Y = npc.position.Y - (float)(npc.height / 2);
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 242, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true;
					{
						Main.dust[num622].scale = 0.23f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}


		public override void NPCLoot()
		{
			if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RawFish"), 1);
			}
		}
	}
}
