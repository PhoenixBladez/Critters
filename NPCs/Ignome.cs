using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs
{
	public class Ignome : ModNPC
	{
		int moveSpeed = 0;
		int moveSpeedY = 0;
		float HomeY = 150f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ignome");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 32;
			npc.damage = 0;
			npc.defense = 0;
			npc.dontCountMe = true;
			npc.lifeMax = 5;
			Main.npcCatchable[npc.type] = true;
			npc.catchItem = (short)mod.ItemType("IgnomeItem");
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.chaseable = false;
			npc.npcSlots = 0;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			banner = npc.type;
			bannerItem = mod.ItemType("IgnomeBanner");
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
            CrittersUtility.DrawNPCGlowMask(spriteBatch, npc, ModContent.GetTexture("Critters/NPCs/Masks/Ignome_Glow"));
        }
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
				if (npc.Center.X >= player.Center.X && moveSpeed >= -120) // flies to players x position
				moveSpeed--;
			else if (npc.Center.X <= player.Center.X && moveSpeed <= 120)
				moveSpeed++;

			npc.velocity.X = moveSpeed * 0.09f;

			if (npc.Center.Y >= player.Center.Y -130f && moveSpeedY >= -30) //Flies to players Y position
				moveSpeedY--;
			else if (npc.Center.Y <= player.Center.Y - 130f && moveSpeedY <= 30)
				moveSpeedY++;

			npc.velocity.Y = moveSpeedY * 0.03f;

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
					int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num622].scale = 0.23f;
						Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.JungleTemple.Chance * 0.019457f;
		}
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}
	}
}
