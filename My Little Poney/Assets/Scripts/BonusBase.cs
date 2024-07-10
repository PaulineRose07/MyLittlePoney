using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBase : MonoBehaviour
{
    [SerializeField] private FloatsScriptable m_pointsToGive;
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private ParticleSystem m_particleSystem;
    public GameEvent m_bonusHasBeenTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_bonusHasBeenTouched.Raise();
    }

    private void DisableBonus()
    {
        gameObject.SetActive(false);
        m_spriteRenderer.enabled = true;
    }

    private IEnumerator AddEffects()
    {
        m_spriteRenderer.enabled = false;
        m_particleSystem.Play();
        yield return new WaitForSeconds(.5f);
        DisableBonus();

    }

}
