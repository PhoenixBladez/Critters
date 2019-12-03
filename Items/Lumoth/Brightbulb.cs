using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Lumoth
{
    public class Brightbulb : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brightbulb");
			Tooltip.SetDefault("'Intricate and versatile'");
		}


        public override void SetDefaults()
        {
            item.width = 14;
			item.height = 20;
            item.rare = 2;
            item.maxStack = 99; 
            item.autoReuse = false;

        }
		  public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
}
