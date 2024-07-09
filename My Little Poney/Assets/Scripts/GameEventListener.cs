using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent m_gameEvent;
    public UnityEvent m_response;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        m_response.Invoke();
    }
}
