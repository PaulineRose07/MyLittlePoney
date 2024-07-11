using System.Collections;
using UnityEngine;

public class BonusBase : MonoBehaviour
{
    //[SerializeField] private FloatsScriptable m_pointsToGive;
    [Header("--- In game Links ---")]
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private AudioSource m_audioSource;
    [Header("--- Effects Links ---")]
    [SerializeField] private ParticleSystem m_particlesCollision;
    [SerializeField] private AudioClip m_audioCollision;
    [Header("--- Events ---")]
    public GameEvent m_BonusHasBeenTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_BonusHasBeenTouched.Raise();
        DisableBonus();
        //StartCoroutine(AddEffects());
    }

    private void DisableBonus()
    {
        gameObject.SetActive(false);
        m_spriteRenderer.enabled = true;
    }

    private IEnumerator AddEffects()
    {
        m_spriteRenderer.enabled = false;
        m_particlesCollision.Play();
        yield return new WaitForSeconds(.5f);
        DisableBonus();
    }

}
