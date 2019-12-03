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
using System.Reflection;
using Terraria.Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using Terraria.GameContent.Events;

namespace Critters
{
	public class CrittersWorld : ModWorld
	{
		public static bool Rain = false;
		public static bool sandStorm = false;
		public static int DeathTiles = 0;
		public override void TileCountsAvailable(int[] tileCounts)
		{
			DeathTiles = tileCounts[mod.TileType("DeathCap")];
		}
		public override TagCompound Save()
		{
			TagCompound data = new TagCompound();
			data.Add("rain", Rain);
			data.Add("sandStorm", sandStorm);
			return data;
		}
		public override void Load(TagCompound tag)
		{
			Rain = tag.GetBool("rain");
			sandStorm = tag.GetBool("sandStorm");
		}
		public override void PostUpdate()
		{
			if(Main.raining)
			{
				Rain = true;
			}
			else
			{
				Rain = false;
			}
			if (Sandstorm.Happening)
			{
				sandStorm = true;
			}
			else
			{
				sandStorm = false;
			}
		}
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            if (ShiniesIndex == -1)
            {
                // Shinies pass removed by some other mod.
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Fountain", delegate (GenerationProgress progress)
            {
                progress.Message = "Adding Even More Plants!";
				for (int C = 0; C < Main.maxTilesX * 18; C++)
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

                     for (int C = 0; C < Main.maxTilesX * 18; C++)
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
					for (int C = 0; C < Main.maxTilesX * 14; C++)
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

                     for (int C = 0; C < Main.maxTilesX * 14; C++)
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
					for (int C = 0; C < Main.maxTilesX * 16; C++)
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

                     for (int C = 0; C < Main.maxTilesX * 16; C++)
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
					 for (int C = 0; C < Main.maxTilesX * 16; C++)
                    {
						{
                        int X = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int Y = WorldGen.genRand.Next((int)WorldGen.worldSurface, Main.maxTilesY);
						{
						if (Main.tile[X, Y].liquid == 255)
						{
                         WorldGen.PlaceObject(X, Y, mod.TileType("Kelp"));
                     NetMessage.SendObjectPlacment(-1, X, Y, mod.TileType("Kelp"), 0, 0, -1, -1);
						}
						}
						}


                    }


            }));


        }
	}
}