using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
    public class GhostReed : ModTile
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
			name.SetDefault("Ghost Reed");
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(97, 165, 120), name);
			dustType = 2;
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
			r = .097f;
			g = .165f;
			b = 0.124f;
		}
      public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 Main.PlaySound(6, i * 16, j * 16, 1);
			 if (!Main.dayTime)
			{
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("GhostReedItem"));
			}
             
        }
			public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			if (!Main.dayTime)
			{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = (tile.frameY == 36) ? 18 : 16;
			Main.spriteBatch.Draw(mod.GetTexture("Tiles/GhostReed_Glow"), new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, new Rectangle?(new Rectangle((int)tile.frameX, (int)tile.frameY, 16, height)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
		}
    }
}
