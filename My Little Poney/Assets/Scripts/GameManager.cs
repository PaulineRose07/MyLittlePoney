using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float m_speedMeterRanger;
    [SerializeField] uiManager m_uiManager;
    [SerializeField] GameObject m_player;
    [SerializeField] private int m_score;
    [SerializeField] private int m_distance;
    [SerializeField] private float m_speedOfRange;

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
}
