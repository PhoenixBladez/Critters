using System;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace Critters.Tiles.Pet
{
	public class GreyMoth_Tile : ModTile
	{
		public override void SetDefaults()
		{
			 Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			animationFrameHeight = 36;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16,16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table| AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
		}
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter >= 4) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 6;
			}
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("GreyMothJar"));
		}
	}
	public class JewelMoth_Tile : ModTile
	{
		public override void SetDefaults()
		{
			 Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			animationFrameHeight = 36;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16,16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table| AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
		}
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter >= 8) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 6;
			}
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("JewelMothJar"));
		}
	}
	public class LunaMoth_Tile : ModTile
	{
		public override void SetDefaults()
		{
			 Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			animationFrameHeight = 36;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16,16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table| AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
		}
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter >= 10) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 6;
			}
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("LunaMothJar"));
		}
	}
	public class GoldMoth_Tile : ModTile
	{
		public override void SetDefaults()
		{
			 Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			animationFrameHeight = 36;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16,16};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table| AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
		}
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if(frameCounter >= 10) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 6;
			}
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 48, mod.ItemType("GoldMothJar"));
		}
	}
}