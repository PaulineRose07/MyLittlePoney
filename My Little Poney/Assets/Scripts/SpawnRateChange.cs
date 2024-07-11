using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRateChange : MonoBehaviour
{
    [SerializeField] GameManager m_gameManager;
    [Header("Distance Parcourue")]
    [SerializeField] int m_firstChange = 100;
    [SerializeField] int m_secondChange = 200;
    [Header("Unicorn Spawn rate")]
    [SerializeField] BasicEnemySpawner m_basicEnemySpawner;
    [SerializeField] float m_newSpawningTimeForUnicorns;
    [SerializeField] float m_secondSpawningTimeForUnicorns;

    [Header("Clouds Spawn rate")]
    [SerializeField] FlyingSpawner m_flyingSpawner;
    [SerializeField] float m_newSpawningTimeForClouds;
    [SerializeField] float m_secondSpawningTimeForClouds;

    private bool m_isFirstUpdated;
    private bool m_isSecondUpdated;

    private void Start()
    {
        m_isFirstUpdated = false;
        m_isSecondUpdated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gameManager.m_distance >= m_firstChange && !m_isFirstUpdated)
        {
            m_basicEnemySpawner.UpdateSpawner(m_newSpawningTimeForUnicorns);
            m_flyingSpawner.UpdateSpawner(m_newSpawningTimeForClouds);
            m_isFirstUpdated = true;
        }
        if(m_gameManager.m_distance >= m_secondChange && !m_isSecondUpdated)
        {
            m_basicEnemySpawner.UpdateSpawner(m_secondSpawningTimeForUnicorns);
            m_flyingSpawner.UpdateSpawner(m_newSpawningTimeForClouds);
            m_isSecondUpdated = true;
        }
    }


}
