using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
    public class Kelp : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            //TileObjectData.addTile(Type);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 6;
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("");
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
						name.SetDefault("Kelp");
            AddMapEntry(new Color(86, 158, 89), name);
			
			dustType = 2;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
				16, 
				16,
				16,
				16
            };

            TileObjectData.addTile(Type);
						adjTiles = new int[] { TileID.GrandfatherClocks };
            TileObjectData.newTile.DrawYOffset = 2;
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
      public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			{				
			}
			 			 Main.PlaySound(6, i * 16, j * 16, 1);
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Kelp"), Main.rand.Next(10) + 5);
			
			if (Main.rand.Next (23) == 0)
			{
				  Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("KelpHook"));
			}
             
        }
       

    }
}
