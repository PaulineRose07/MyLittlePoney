using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("--- scriptables ---")]
    [SerializeField] FloatsScriptable m_speedValue;
    [SerializeField] FloatsScriptable m_angleOfLaunch;
    [Header("--- Bounce limiter ---")]
    [SerializeField] FloatsScriptable m_amountOfEnemiesBounced;
    [SerializeField] private int m_amountsOfBounceToJump = 3;
    [SerializeField] private float m_speedOfSlam;
    [Header("--- Bounce Information ---")]
    [SerializeField] private float m_angleOfBounce = 1;
    [Header("--- Links ---")]
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    [SerializeField] private ParticleSystem m_particlesOnBounce;
    [SerializeField] private float m_timer = 1.5f;
    public GameEvent m_onPlayerStoppedMoving;
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
                /*if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        print("Touch has Began");
                        var direction = Vector3.Normalize(Vector3.right + m_angleOfLaunch.m_information * Vector3.up);
                        m_rigidbody2D.AddForce(direction * m_speedValue.m_information, ForceMode2D.Impulse);
                        m_states = PlayerStates.Moving;
                    }
                }*/
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("player launching");
                    var direction = Vector3.Normalize(Vector3.right + m_angleOfLaunch.m_information * Vector3.up);
                    m_rigidbody2D.AddForce(direction * m_speedValue.m_information, ForceMode2D.Impulse);
                    m_states = PlayerStates.Moving;
                    //Vector2 direction = Vector2.Normalize(Vector2.right + m_angle * Vector2.up);
                }
                break;
            case PlayerStates.Launching:
                break;
            case PlayerStates.Moving:
                if(m_amountOfEnemiesBounced.m_information >= m_amountsOfBounceToJump)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        BoucingOnThings(m_speedOfSlam);
                        Debug.Log("Player bouncing");
                        m_amountOfEnemiesBounced.m_information = 0;
                        //m_states = PlayerStates.Bouncing;
                    }
                }

                break;
            case PlayerStates.Bouncing:
                break;
            case PlayerStates.Falling:
                break;
        }
        
        if(m_rigidbody2D.velocity.x <= 0 && m_amountOfEnemiesBounced.m_information <= m_amountsOfBounceToJump)
        {
            m_timer -= Time.deltaTime;
            if(m_timer <= 0)
            {
                m_onPlayerStoppedMoving.Raise();
            }
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

    public void BoucingOnThings(float _speedValue)
    {
        m_rigidbody2D.velocity = Vector3.zero;
        var direction = Vector3.Normalize(Vector3.up + Vector3.right);
        m_rigidbody2D.AddForce(direction * _speedValue, ForceMode2D.Impulse);
    }
}
