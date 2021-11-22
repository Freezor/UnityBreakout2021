using Owahu.Breakout.World.Loot;
using UnityEngine;

namespace Owahu.Breakout.World.Targets
{
    [System.Serializable]
    public class TargetLootSpawner : MonoBehaviour
    {
        // Loot drop table that contains items that can spawn
        public GenericLootDropTableGameObject lootDropTable;


        void OnValidate()
        {
            // Validate table and notify the programmer / designer if something went wrong.
            lootDropTable.ValidateTable();
        }

        /// <summary>
        /// Spawning objects in horizontal line
        /// </summary>
        /// <param name="amountOfItemsToDrop"></param>
        public void DropLoot(int amountOfItemsToDrop = 1)
        {
            for (var i = 0; i < amountOfItemsToDrop; i++)
            {
                var selectedItem = lootDropTable.PickLootDropItem();
                SpawnItemInWorld(amountOfItemsToDrop, selectedItem, i);
            }
        }

        private void SpawnItemInWorld(int amountOfItemsToDrop, GenericLootDropItemGameObject selectedItem, int i)
        {
            var selectedItemGameObject = Instantiate(selectedItem.Item);
            if (amountOfItemsToDrop == 1)
            {
                var gameObjectPosition = gameObject.transform.position;
                selectedItemGameObject.transform.position = new Vector2(gameObjectPosition.x,
                    gameObjectPosition.y - 0.05f);
            }
            else
            {
                selectedItemGameObject.transform.position = new Vector2(i / 2f, 0f);
            }
        }
    }
}