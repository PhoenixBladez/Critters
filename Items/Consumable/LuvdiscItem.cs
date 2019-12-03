using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class LuvdiscItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ardorfish");
			Tooltip.SetDefault("'It exudes affection'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 22;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.value = Item.sellPrice(0, 0, 4, 0);
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Luvdisc"));
            return true;
        }

        }
}
