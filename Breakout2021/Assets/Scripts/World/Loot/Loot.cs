using UnityEngine;

namespace Owahu.Breakout.World.Loot
{
    public abstract class Loot<T>
    {
        // Item it represents - usually GameObject, integer etc...
        public T Item;

        // How many units the item takes - more units, higher chance of being picked
        public float ProbabilityWeight;

        // Displayed only as an information for the designer/programmer. Should not be set manually via inspector!    
        public float ProbabilityPercent;

        // These values are assigned via LootDropTable script. They represent from which number to which number if selected, the item will be picked.
        [HideInInspector] public float ProbabilityRangeFrom;
        [HideInInspector] public float ProbabilityRangeTo;
    }
}