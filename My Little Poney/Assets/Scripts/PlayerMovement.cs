
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("--- scriptables ---")]
    [SerializeField] FloatsScriptable m_speedValue;
    [SerializeField] FloatsScriptable m_angleOfLaunch;
    [Header("--- Bounce limiter ---")]
    [SerializeField] FloatsScriptable m_amountOfEnemiesBounced;
    [SerializeField] FloatsScriptable m_maxAmountForBoost;
    [SerializeField] private float m_speedOfSlam;
    [Header("--- Links ---")]
    [SerializeField] private Rigidbody2D m_rigidbody2D;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Collider2D m_collider2D;
    [Header("--- Game Ending ---")]
    private float m_timer;
    [SerializeField] private float m_timerUntilScreenGameOver = 1.5f;
    [Header("--- Effects Links --- ")]
    [SerializeField] private ParticleSystem m_particlesBouncing;
    [SerializeField] private AudioClip m_soundOnJump;

    [Header("--- Game Events ---")]
    public GameEvent m_onPlayerStoppedMoving;
    public GameEvent m_onPlayerIsLaunching;
    public GameEvent m_onPlayerHasJumped;

    enum PlayerStates
    {
        Default,
        Launching,
        Moving,
        Bouncing, 
        Falling,
        Ending
    }
    private PlayerStates m_states;

    private void Start()
    {
        //m_isMoving = false;
        m_timer = m_timerUntilScreenGameOver;
        m_collider2D.enabled = true;
        m_rigidbody2D.velocity = Vector3.zero;
        m_states = PlayerStates.Default;
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
                    m_animator.SetBool("OnLaunch 0",true);
                    m_onPlayerIsLaunching.Raise();
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
                    m_animator.SetBool("OnLaunch 0", false);
                    m_animator.SetBool("Moving", true);
                m_animator.SetFloat("Velocity", m_rigidbody2D.velocity.y);
                m_animator.SetFloat("PositionY", transform.position.y);
                if(m_amountOfEnemiesBounced.m_information >= m_maxAmountForBoost.m_information)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        BoucingOnThings(m_speedOfSlam);
                        Debug.Log("Player bouncing");
                        m_onPlayerHasJumped.Raise();
                        m_amountOfEnemiesBounced.m_information = 0;
                        //m_states = PlayerStates.Bouncing;
                    }
                }
                if (m_amountOfEnemiesBounced.m_information <= m_maxAmountForBoost.m_information && m_rigidbody2D.velocity.x <= 0)
                {
                    m_states = PlayerStates.Ending;
                }
                break;
            case PlayerStates.Bouncing:
                break;
            case PlayerStates.Falling:
                break;
            case PlayerStates.Ending:
                PayerstoppedMoving();
                break;
        }
    }

    public void BoucingOnThings(float _speedValue)
    {
        m_animator.SetBool("OnLaunch 0", true);
        m_rigidbody2D.velocity = Vector3.zero;
        var direction = Vector3.Normalize(Vector3.up + Vector3.right);
        m_rigidbody2D.AddForce(direction * _speedValue, ForceMode2D.Impulse);
        if(m_particlesBouncing != null) m_particlesBouncing.Play();
    }

    private void PayerstoppedMoving()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_collider2D.enabled = false;
            m_onPlayerStoppedMoving.Raise();
            
        }
    }

}
