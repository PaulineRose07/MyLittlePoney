using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBase : MonoBehaviour
{
    [Header("--- Links ---")]
    [SerializeField] Sprite[] m_spriteClouds;
    [SerializeField] SpriteRenderer m_spriteRenderer;
    [Header("--- Balancing ---")]
    [SerializeField] private float m_speedOfBounce = 15f;
    [SerializeField] private float m_timeForDisabling = 10f;
    [SerializeField] private float m_waitForDisablingAfterEffects = .2f;
    [Header("Effects")]
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private ParticleSystem m_particleWhenTouched;
    [SerializeField] private AudioClip m_onCollisionSound;

    public GameEvent m_onCollisionWithPlayer;
    private void Awake()
    {
        m_spriteRenderer.sprite = m_spriteClouds[Random.Range(0, m_spriteClouds.Length)];
    }

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
