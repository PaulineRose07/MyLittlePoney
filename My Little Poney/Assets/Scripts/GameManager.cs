
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("--- In Game Links ---")]
    [SerializeField] uiManager m_uiManager;
    [SerializeField] GameObject m_player;
    [SerializeField] SpawnRateChange m_spawnRateChange;
    [Header("--- Info ---")]
    [SerializeField] private int m_score;
    [SerializeField] public int m_distance;
    [SerializeField] private float m_speedOfRange;
    [Header("--- Scriptable Objects ---")]
    [SerializeField] FloatsScriptable m_amountOfEnemyBounce;
    [SerializeField] FloatsScriptable m_AngleOfLaunchData;
    [SerializeField] FloatsScriptable m_speedData;
    [SerializeField] FloatsScriptable m_bonusPoints;
    [SerializeField] FloatsScriptable m_maxAmountOfBoost;
    [Header("--- Links ---")]
    [SerializeField] private AnimationCurve m_animationCurve;
    [SerializeField] private Slider m_sliderLaunchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_amountOfEnemyBounce.m_information = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_distance = (int)m_player.transform.position.x;
        m_uiManager.UpdateDistance(m_distance);
        m_uiManager.UpdateScoreText(m_score);
    }

    public void UpdateScore()
    {
        m_score += (int) m_bonusPoints.m_information;
    }

    public void BonusJump()
    {
        m_amountOfEnemyBounce.m_information += m_maxAmountOfBoost.m_information;
        UpdateBoostImageInUI();
    }

    private IEnumerator SpeedMeter(float _time)
    {
        yield return new WaitForSeconds(_time);
    }

    [ContextMenu("Test")]
    public void AddToEnemyCount()
    {
        m_amountOfEnemyBounce.m_information++;
        UpdateBoostImageInUI();
        Debug.Log(m_amountOfEnemyBounce.m_information);
    }
    public void onPlayerHasJumpedUpdateBoost()
    {
        m_amountOfEnemyBounce.m_information = 0;
        UpdateBoostImageInUI();

    }


    private void UpdateBoostImageInUI()
    {
        float percentage = m_amountOfEnemyBounce.m_information / m_maxAmountOfBoost.m_information;
        m_uiManager.UpdateBoostUI(percentage);
    }
    public void ChangeAngleWithSlider()
    {
        m_AngleOfLaunchData.m_information = m_sliderLaunchingPlayer.value;
    }

    public void ChangeSpeedWithSlider()
    {
        m_speedData.m_information = m_animationCurve.Evaluate(m_sliderLaunchingPlayer.value);
    }
}
