using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float m_speedMeterRanger;
    [SerializeField] uiManager m_uiManager;
    [SerializeField] GameObject m_player;
    [SerializeField] private int m_score;
    [SerializeField] private int m_distance;
    [SerializeField] private float m_speedOfRange;
    [SerializeField] FloatsScriptable m_amountOfEnemyBounce;
    [SerializeField] FloatsScriptable m_AngleOfLaunchData;
    [SerializeField] FloatsScriptable m_speedData;
    [SerializeField] private FloatsScriptable m_maxAmountOfBoost;
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
        //Update the score depending of the distance
    }

    public void UpdateDistance()
    {
        // something goes here
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

    /*public void ChangeAngleOfLaunch(float _angleFromSlider)
    {
        m_AngleOfLaunchData.m_information = _angleFromSlider;
        
    }*/

    public void ChangeAngleWithSlider()
    {
        m_AngleOfLaunchData.m_information = m_sliderLaunchingPlayer.value;
    }

    public void ChangeSpeedWithSlider()
    {
        m_speedData.m_information = m_animationCurve.Evaluate(m_sliderLaunchingPlayer.value);
    }

    /*public void ChangeSpeedOfLaunch(float _speedFromSlider)
    {
        //_speedFromSlider = m_slider.value;

        m_speedData.SetValue(m_animationCurve.Evaluate(_speedFromSlider));
    }*/
}
