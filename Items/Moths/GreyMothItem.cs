using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Moths
{
    public class GreyMothItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grey Moth");
		}


        public override void SetDefaults()
        {
            item.width = 24;
			item.height = 22;
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.useTime = item.useAnimation = 20;
			item.bait = 10;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("GreyMoth"));
            return true;
        }

        }
}
