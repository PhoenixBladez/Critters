using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CleftShell : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cleft Shell");
			Tooltip.SetDefault("'Sturdy as rock'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 18;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.noMelee = true;
            item.autoReuse = false;

        }
    }
}
