using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float m_speedMeterRanger;
    [SerializeField] uiManager m_uiManager;
    [SerializeField] GameObject m_player;
    [SerializeField] private int m_score;
    [SerializeField] private int m_distance;
    [SerializeField] private float m_speedOfRange;
    [SerializeField] FloatsScriptable m_amountOfEnemyBounce;
    [SerializeField] private UnityEvent m_collisionWithPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_collisionWithPlayer.AddListener(AddToEnemyCount);
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

    private void AddToEnemyCount()
    {
        m_amountOfEnemyBounce.m_information++;
    }
}
