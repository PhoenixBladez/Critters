using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class Skull : ModItem
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Strange Skull");
		}


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 18;

            item.value = Item.sellPrice(0, 0, 7, 20);
            item.rare = 1;
            item.vanity = true;
        }
    }
}
