using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float m_speedOfBounce = 15f;
    [SerializeField] private float m_timeForDisabling = 10f;
    [SerializeField] private ParticleSystem m_particleWhenTouched;
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] private AudioClip m_onCollisionSound;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    private float m_waitForDisablingAfterEffects = .2f;

    public GameEvent m_onCollisionWithPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_onCollisionWithPlayer.Raise();
        collision.TryGetComponent<PlayerMovement>(out PlayerMovement _player);
        _player.BoucingOnThings(m_speedOfBounce);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Invoke("DisableAfterAFewSeconds", m_timeForDisabling);
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
