using System;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using TestMod.Items.Materials;
using static Terraria.ModLoader.ModContent;
namespace TestMod.Drops
{
    public class CustomDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(Terraria.NPC npc, NPCLoot npcLoot)
        {
            if(npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<VampireFang>(), 1,1,2));
            }
            if(npc.type == NPCID.ChaosElemental)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<ChaoticBone>(), 1,2,6 ));
            }

        }
    }
}