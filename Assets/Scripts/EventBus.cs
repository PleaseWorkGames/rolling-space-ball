using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Specialized;
using JetBrains.Annotations;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static DictionaryCollection<Action<Dictionary<string, object>>> eventRegistry = new DictionaryCollection<Action<Dictionary<string, object>>>();

    public static void listenFor(string eventName, [CanBeNull] Action<Dictionary<string, object>> callback)
    {
        eventRegistry.Add("listeners", eventName, callback);
    }

    public static void trigger(string eventName, [CanBeNull] Dictionary<string, object> parameters)
    {
// TODO - allow for multiple listeners to be registered under eventName namespace
        eventRegistry.Get("listeners", eventName)(parameters);
//        foreach(KeyValuePair<string, string> entry in eventRegistry.Get("listeners", eventName))
//        {
//             do something with entry.Value or entry.Key
//        }
        
//        foreach (var dictPair in eventRegistry.Get("listeners", eventName)) {
//            Console.WriteLine("YO");
//            Console.WriteLine("Key: {0}", dictPair.Key);
//            foreach (var innerPair in dictPair.Value) {
//                Console.WriteLine("\t{0}:{1}", innerPair.Key, innerPair.Value);
//            }
//        }

//        foreach (DictionaryEntry eventRegistrySublist in eventRegistry) {
//            if (eventRegistrySublist.Key != eventName) {
//                continue;
//            }

//            foreach (DictionaryEntry a in eventRegistrySublist.Value)

//            foreach (var e in eventRegistrySublist.Value) {
//                Console.WriteLine("\t{0}:{1}", eventRegistrySublist.Key, eventRegistrySublist.Value);
//            }
//        }

//        foreach(KeyValuePair<string, Action<Dictionary<string, dynamic>>> callback in eventRegistry[eventName])
//        {

//        }
    }
}

public class DictionaryCollection<TType> : Dictionary<string, Dictionary<string, TType>>
{
    public void Add(string dictionaryKey, string key, TType value)
    {
        if (!ContainsKey(dictionaryKey)) {
            Add(dictionaryKey, new Dictionary<string, TType>());
        }

        this[dictionaryKey].Add(key, value);
    }

    public TType Get(string dictionaryKey, string key)
    {
        return this[dictionaryKey][key];
    }
}