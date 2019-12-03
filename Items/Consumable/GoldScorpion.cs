using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class GoldScorpion : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Scorpion");
		}


        public override void SetDefaults()
        {
            item.height = 18;
			item.width = 32;
            item.rare = 2;
            item.maxStack = 99;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = true;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("GoldScorp"));
            return true;
        }

        }
}
