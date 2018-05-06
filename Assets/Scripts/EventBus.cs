using System.Collections;
using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine;

public class EventBus : MonoBehaviour
{
//    private static eventRegistry;
    
//    public delegate void EventObject(Dictionary<string, dynamic> parameters);
    
    public static void listenFor(string eventName, [CanBeNull] Action<Dictionary<string, dynamic>> callback)
    {
        
    }

    public static void trigger(string eventName, [CanBeNull] Dictionary<string, dynamic> parameters)
    {
        
    }
}