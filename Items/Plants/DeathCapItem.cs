using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Plants
{
    public class DeathCapItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Cap");
			Tooltip.SetDefault("'Potent and poisonous'");
		}


        public override void SetDefaults()
        {
            item.width = 18;
			item.height = 18;
            item.value = 6000;

            item.maxStack = 99;

            item.useStyle = 1;
			item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

			item.createTile = mod.TileType("DeathCap");
        }
    }
}
