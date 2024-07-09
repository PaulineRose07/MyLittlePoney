using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private AnimationCurve m_animationCurve;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(m_amountOfEnemyBounce);
    }

    public void ChangeAngleOfLaunch(float _angleFromSlider)
    {
        m_AngleOfLaunchData.m_information = _angleFromSlider;
        
    }

    public void ChangeSpeedOfLaunch(float _speedFromSlider)
    {
        //_speedFromSlider = m_slider.value;
        m_speedData.m_information = m_animationCurve.Evaluate(_speedFromSlider);
    }
}
