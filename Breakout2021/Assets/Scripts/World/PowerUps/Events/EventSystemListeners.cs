using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Owahu.Breakout.World.PowerUps.Events
{
    public class EventSystemListeners : MonoBehaviour
    {
        public static EventSystemListeners main;

        [Tooltip(
            "Listeners that want to know about messages.  By default any object with tag = Listener is included, but you can add more here, or add at runtime with method EventSystemListeners.main.AddListener()")]
        public List<GameObject> listeners;

        public List<string> itemTags;

        /// <summary>
        /// Check we are singleton
        /// </summary>
        private void Awake()
        {
            if (main == null)
            {
                main = this;
            }
            else
            {
                Debug.LogWarning("EventSystemListeners re-creation attempted, destroying the new one");
                Destroy(gameObject);
            }

            AddListenersForAllTaggedObjects();
        }

        private void AddListenersForAllTaggedObjects()
        {
            foreach (var taggedObjects in itemTags.Select(itemTag => GameObject.FindGameObjectsWithTag(itemTag)))
            {
                listeners.AddRange(taggedObjects);
            }
        }

        void Start()
        {
            // Look for every object tagged as a listener
            listeners ??= new List<GameObject>();

            var gos = GameObject.FindGameObjectsWithTag("Listener");

            listeners.AddRange(gos);
        }

        public void AddListener(GameObject go)
        {
            // Don't add if already there
            if (!listeners.Contains(go))
            {
                listeners.Add(go);
            }
        }
    }
}