using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Specialized;
using JetBrains.Annotations;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private static ListDictionary eventRegistry = new ListDictionary();
    
//    public delegate void EventObject(Dictionary<string, dynamic> parameters);
    
    /*
    public static void listenFor(string eventName, [CanBeNull] Action<Dictionary<string, dynamic>> callback)
    {
        eventRegistry.Add(eventName, callback);
    }
    */
/*
    public static void trigger(string eventName, [CanBeNull] Dictionary<string, dynamic> parameters)
    {
//        if (!eventRegistry.Contains(eventName)) {
//            return;
//        }

        foreach (DictionaryEntry eventRegistrySublist in eventRegistry) {
            if (eventRegistrySublist.Key != eventName) {
                continue;
            }
            
//            foreach (var e in eventRegistrySublist.Value) {
//                Console.WriteLine("\t{0}:{1}", eventRegistrySublist.Key, eventRegistrySublist.Value);
//            }
        }
        
//        foreach(KeyValuePair<string, Action<Dictionary<string, dynamic>>> callback in eventRegistry[eventName])
//        {
            
//        }
    }*/
}