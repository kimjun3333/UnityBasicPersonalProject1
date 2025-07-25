using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public enum QuestType
    {
        Talking,
        Gaming,
        Riding    
    }

    private static readonly IDictionary<QuestType, UnityEvent<int>> Events = new Dictionary<QuestType, UnityEvent<int>>();

    public static void Register(QuestType type, UnityAction<int> action)
    {
        if(!Events.ContainsKey(type))
            Events[type] = new UnityEvent<int>();

        Events[type].AddListener(action);
    }

    public static void UnRegister(QuestType type, UnityAction<int> action)
    {
        if(Events.ContainsKey(type))
            Events[type].RemoveListener(action);
    }

    public static void Publish(QuestType type , int targetID)
    {
        if(Events.ContainsKey(type))
            Events[type].Invoke(targetID);
    }

    
}
