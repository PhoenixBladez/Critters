using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
    public class Blossom : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
  Main.tileFrameImportant[Type] = true;
            //TileObjectData.addTile(Type);
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Zenblossom");
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(97, 120, 170), name);
			dustType = 187;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };

            TileObjectData.addTile(Type);
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .194f;
			g = .22f;
			b = 0.32f;
		}
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				player.AddBuff(BuffID.Calm, 299);
			}
		}
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 2)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
      public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 Main.PlaySound(6, i * 16, j * 16, 1);
			{
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("BlossomItem"));
			}
             
        }
			public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = (tile.frameY == 36) ? 18 : 16;
			Main.spriteBatch.Draw(ModContent.GetTexture("Tiles/Blossom_Glow"), new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, new Rectangle?(new Rectangle((int)tile.frameX, (int)tile.frameY, 16, height)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
		}
    }
}
