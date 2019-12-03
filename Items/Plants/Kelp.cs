using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace Critters.Items.Plants
{
    public class Kelp : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kelp");
		}


        public override void SetDefaults()
        {
            item.width = 16;
			item.height = 26;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.autoReuse = false;

        }

    }
}
