using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;

namespace Critters.Items.Plants
{
    public class Boquet : ModItem
    {
		 private int WillGenn = 0;
		 private int Meme;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystical Boquet");
			Tooltip.SetDefault("Spawns a few Death Caps, Cryovines, and Ghost Reeds around the world\nUse this only once");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 40;
            item.rare = 2;
            item.maxStack = 1;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 60;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
			item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            #region Plants
			            {
              Main.NewText("Plants have sprouted up everywhere!", Color.Green.R, Color.Green.G, Color.Green.B);
				for (int C = 0; C < Main.maxTilesX * 6; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
						if (Main.tile[X,Y].type == TileID.Stone)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("DeathCap"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("DeathCap"), 0, 0, -1, -1);
						}
						}


                    }

                     for (int C = 0; C < Main.maxTilesX * 6; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                       if (Main.tile[X,Y].type == TileID.Stone)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("DeathCap"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("DeathCap"), 0, 0, -1, -1);
						}
						}


                    }
					for (int C = 0; C < Main.maxTilesX * 4; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
						if (Main.tile[X,Y].type == TileID.IceBlock)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("Cryovine"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("Cryovine"), 0, 0, -1, -1);
						}
						}


                    }

                     for (int C = 0; C < Main.maxTilesX * 4; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                       if (Main.tile[X,Y].type == TileID.IceBlock)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("Cryovine"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("Cryovine"), 0, 0, -1, -1);
						}
						}


                    }
					for (int C = 0; C < Main.maxTilesX * 3; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY);
						{
						if (Main.tile[X, Y].liquid == 255)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("GhostReed"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("GhostReed"), 0, 0, -1, -1);
						}
						}
						}


                    }

                     for (int C = 0; C < Main.maxTilesX * 3; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY);
						{
						if (Main.tile[X, Y].liquid == 255)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("GhostReed"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("GhostReed"), 0, 0, -1, -1);
						}
						}
						}


                    }


            }
            #endregion
            return true;
        }

        }
}
