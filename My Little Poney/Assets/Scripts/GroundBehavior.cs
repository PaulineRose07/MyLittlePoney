using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    [SerializeField] GameEvent m_onGroundHasBeenTouched;
    private bool m_canShake;

    private void Start()
    {
        m_canShake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!m_canShake) return;
        if(collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            Debug.Log("Ground Has Been Touched");
            m_onGroundHasBeenTouched.Raise();
        }
    }

    public void CanShakeWhenPlayerHasLaunched()
    {
        m_canShake = true;
    }

}
