using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_speedValue;
    [Range(0,2f)]
    [SerializeField] private float m_angleOfLaunch;
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    //[SerializeField] private bool m_isMoving;
    enum PlayerStates
    {
        Default,
        Launching,
        Moving,
        Bouncing, 
        Falling
    }
    private PlayerStates m_states;

    private void Start()
    {
        //m_isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_states)
        {
            case PlayerStates.Default:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("player launching");
                    var direction = Vector3.Normalize(Vector3.right + m_angleOfLaunch * Vector3.up);
                    m_rigidbody2D.AddForce(direction * m_speedValue, ForceMode2D.Impulse);
                    m_states = PlayerStates.Moving;
                    //Vector2 direction = Vector2.Normalize(Vector2.right + m_angle * Vector2.up);
                }
                break;
            case PlayerStates.Launching:
                break;
            case PlayerStates.Moving:

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Player bouncing");
                    //m_states = PlayerStates.Bouncing;
                }
                break;
            case PlayerStates.Bouncing:
                break;
            case PlayerStates.Falling:
                break;
        }

        /*if (!m_isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("player launching");
                //var direction = Vector2.Normalize(Vector2.forward + )
                m_rigidbody2D.AddForce(Vector3.forward * m_speedValue, ForceMode2D.Impulse);
                m_isMoving = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Player bouncing");
                //should be able to bounce when touching enemies
            }
        }*/
    }

    private void onLaunch()
    {

    }
}
