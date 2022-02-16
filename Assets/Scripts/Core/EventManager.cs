using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class EventManager : MonoBehaviour {

        private Dictionary <string, UnityEvent> eventDictionary;
        private static EventManager eventManager;

        public static EventManager Instance()
        {
            var manager = FindCreatedEventManager();
            if (!manager)
                manager = CreateEventManager();
            
            eventManager = manager;
            
            if (!eventManager)
                throw new Exception("There needs to be one active EventManger script on a GameObject in your scene.");
            
            eventManager.Init();
            return eventManager;
        }

        private static EventManager CreateEventManager()
        {
            return new GameObject().AddComponent<EventManager>();
        }
        
        private static EventManager FindCreatedEventManager()
        {
            return FindObjectOfType(typeof(EventManager)) as EventManager;
        }

        void Init ()
        {
            if (eventDictionary == null)
                eventDictionary = new Dictionary<string, UnityEvent>();
        }

        public static void StartListening(Enum eventName, UnityAction listener)
        {
            UnityEvent thisEvent = null;
            if (Instance().eventDictionary.TryGetValue(eventName.ToString(), out thisEvent))
            {
                thisEvent.AddListener (listener);
            } 
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance().eventDictionary.Add(eventName.ToString(), thisEvent);
            }
        }

        public static void StopListening(Enum eventName, UnityAction listener)
        {
            if (eventManager == null) return;
            UnityEvent thisEvent = null;
            
            if (Instance().eventDictionary.TryGetValue(eventName.ToString(), out thisEvent))
                thisEvent.RemoveListener (listener);

        }

        public static void TriggerEvent(Enum eventName)
        {
            UnityEvent thisEvent = null;
            if (Instance().eventDictionary.TryGetValue(eventName.ToString(), out thisEvent))
                thisEvent.Invoke();
        }
    }
}