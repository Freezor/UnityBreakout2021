using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Owahu.Breakout.World.Loot
{
    /// <summary>
    /// Class serves for assigning and picking loot drop items.
    /// </summary>
    public abstract class LootTable<T, U> where T : Loot<U>
    {
        // List where we'll assign the items.
        [SerializeField] public List<T> lootDropItems;

        // Sum of all weights of items.
        float probabilityTotalWeight;

        /// <summary>
        /// Calculates the percentage and asigns the probabilities how many times
        /// the items can be picked. Function used also to validate data when tweaking numbers in editor.
        /// </summary>	
        public void ValidateTable()
        {
            // Prevent editor from "crying" when the item list is empty :)
            if (lootDropItems == null || lootDropItems.Count <= 0)
            {
                return;
            }

            var currentProbabilityWeightMaximum = 0f;

            // Sets the weight ranges of the selected items.
            foreach (var lootDropItem in lootDropItems)
            {
                if (lootDropItem.ProbabilityWeight < 0f)
                {
                    // Prevent usage of negative weight.
                    Debug.Log("You can't have negative weight on an item. Reseting item's weight to 0.");
                    lootDropItem.ProbabilityWeight = 0f;
                }
                else
                {
                    lootDropItem.ProbabilityRangeFrom = currentProbabilityWeightMaximum;
                    currentProbabilityWeightMaximum += lootDropItem.ProbabilityWeight;
                    lootDropItem.ProbabilityRangeTo = currentProbabilityWeightMaximum;
                }
            }

            probabilityTotalWeight = currentProbabilityWeightMaximum;

            // Calculate percentage of item drop select rate.
            foreach (var lootDropItem in lootDropItems)
            {
                lootDropItem.ProbabilityPercent =
                    ((lootDropItem.ProbabilityWeight) / probabilityTotalWeight) * 100;
            }
        }

        /// <summary>
        /// Picks and returns the loot drop item based on it's probability.
        /// </summary>
        public T PickLootDropItem()
        {
            var pickedNumber = Random.Range(0, probabilityTotalWeight);

            // Find an item whose range contains pickedNumber
            foreach (var lootDropItem in lootDropItems.Where(lootDropItem =>
                pickedNumber > lootDropItem.ProbabilityRangeFrom &&
                pickedNumber < lootDropItem.ProbabilityRangeTo))
            {
                return lootDropItem;
            }

            // If item wasn't picked... Notify programmer via console and return the first item from the list
            Debug.LogError(
                "Item couldn't be picked... Be sure that all of your active loot drop tables have assigned at least one item!");
            return lootDropItems[0];
        }
    }
}