using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CrismiteCrystal : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dazzling Prism");
			Tooltip.SetDefault("'It shimmers brightly'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 18;
            item.rare = 5;
            item.maxStack = 99;
            item.noUseGraphic = true;
			item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.noMelee = true;
            item.autoReuse = false;

        }
    }
}
