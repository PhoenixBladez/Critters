using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CrimsonFeather : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Feather");
			Tooltip.SetDefault("'Brilliantly colored'");
		}


        public override void SetDefaults()
        {
            item.width = 16;
			item.height = 22;
            item.rare = 2;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.noMelee = true;
            item.autoReuse = false;

        }
    }
}
