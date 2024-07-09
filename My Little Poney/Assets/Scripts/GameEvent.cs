using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameEvent"), ]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {

    }

    public void RegisterListener(GameEventListener _listener)
    {
        if(listeners.Contains(_listener))
        {
            listeners.Add(_listener);
        }
    }

    public void UnregisterListener(GameEventListener _listener)
    {
        if (listeners.Contains(_listener))
        {
            listeners.Remove(_listener);
        }
    }
}
