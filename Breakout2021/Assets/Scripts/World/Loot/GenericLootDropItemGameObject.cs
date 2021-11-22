using UnityEngine;

namespace Owahu.Breakout.World.Loot
{
    /// <summary>
    /// When we're inheriting we have to insert GameObject as a type to GenericLootDropItem
    /// </summary>
    [System.Serializable]
    public class GenericLootDropItemGameObject : Loot<GameObject>
    {
    }
}