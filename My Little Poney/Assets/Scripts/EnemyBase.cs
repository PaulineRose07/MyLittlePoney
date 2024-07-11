using System.Collections;
using UnityEngine;


public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float m_minRandomSpeed = 1f;
    [SerializeField] private float m_maxRandomSpeed = 5f;
    private float m_randomSpeed;
    [Header("--- Enemy Info To Equilibrate ---")]
    [SerializeField] private float m_speedOfBounce = 15f;
    //[SerializeField] private float m_timeForDisabling = 10f;
    [SerializeField] private float m_waitForDisablingAfterEffects = .2f;
    [SerializeField] private float m_enemyMinLifeSpan;
    [SerializeField] private float m_enemyMaxLifeSpan;
    private float m_randomLife;
    [Space(12)]
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [Header("--- Effects Links ---")]
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private AudioClip m_onCollisionSound;
    [SerializeField] private ParticleSystem m_particleWhenTouched;
    [Header("--- Events ---")]
    public GameEvent m_onCollisionWithPlayer;

    private void Start()
    {
        m_randomSpeed = Random.Range(m_minRandomSpeed, m_maxRandomSpeed);
        m_randomLife = Random.Range(m_enemyMinLifeSpan, m_enemyMaxLifeSpan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_onCollisionWithPlayer.Raise();
        collision.TryGetComponent<PlayerMovement>(out PlayerMovement _player);
        _player.BoucingOnThings(m_speedOfBounce);
        StartCoroutine(JuiceWhenCollision());
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(transform.right * m_randomSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Invoke("DisableAfterAFewSeconds", m_randomLife);
    }
    private void DisableAfterAFewSeconds()
    {
        gameObject.SetActive(false);
        m_spriteRenderer.enabled = true;
    }

    IEnumerator JuiceWhenCollision()
    {
        EffectsOfEnemies();
        yield return new WaitForSeconds(m_waitForDisablingAfterEffects);
        DisableAfterAFewSeconds();
    }

    private void EffectsOfEnemies()
    {
        m_spriteRenderer.enabled = false;
        m_particleWhenTouched.Play();
        m_audioSource.PlayOneShot(m_onCollisionSound);
    }
}
