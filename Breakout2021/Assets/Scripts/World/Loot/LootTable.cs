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
        private float _probabilityTotalWeight;

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

            var currentProbabilityWeightMaximum = lootDropItems.Aggregate(0f, (current, lootDropItem) => CalculateCurrentProbabilityWeightMaximum(lootDropItem, current));

            _probabilityTotalWeight = currentProbabilityWeightMaximum;
            foreach (var lootDropItem in lootDropItems)
            {
                CalculateDropChance(lootDropItem);
            }
        }

        private void CalculateDropChance(T lootDropItem)
        {
            lootDropItem.ProbabilityPercent =
                ((lootDropItem.ProbabilityWeight) / _probabilityTotalWeight) * 100;
        }

        private static float CalculateCurrentProbabilityWeightMaximum(T lootDropItem, float currentProbabilityWeightMaximum)
        {
            if (lootDropItem.ProbabilityWeight < 0f)
            {
                // Prevent usage of negative weight.
                Debug.Log("You can't have negative weight on an item. Resetting item's weight to 0.");
                lootDropItem.ProbabilityWeight = 0f;
            }
            else
            {
                lootDropItem.ProbabilityRangeFrom = currentProbabilityWeightMaximum;
                currentProbabilityWeightMaximum += lootDropItem.ProbabilityWeight;
                lootDropItem.ProbabilityRangeTo = currentProbabilityWeightMaximum;
            }

            return currentProbabilityWeightMaximum;
        }

        /// <summary>
        /// Picks and returns the loot drop item based on it's probability.
        /// </summary>
        public T PickLootDropItem()
        {
            var pickedNumber = Random.Range(0, _probabilityTotalWeight);

            if (FindLootInSelectedRange(pickedNumber, out var loot)) return loot;

            Debug.LogError(
                "Item couldn't be picked... Be sure that all of your active loot drop tables have assigned at least one item!");
            return lootDropItems[0];
        }

        private bool FindLootInSelectedRange(float pickedNumber, out T loot)
        {
            foreach (var lootDropItem in lootDropItems.Where(lootDropItem =>
                pickedNumber > lootDropItem.ProbabilityRangeFrom &&
                pickedNumber < lootDropItem.ProbabilityRangeTo))
            {
                {
                    loot = lootDropItem;
                    return true;
                }
            }

            loot = null;
            return false;
        }
    }
}