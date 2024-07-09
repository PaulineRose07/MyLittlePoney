using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    [SerializeField] PoolSystem m_pool;
    [SerializeField] private float m_spawningDelay;
    private float m_timerOfSpawn;
    [SerializeField] private int m_minOffsetOfSpawn;
    [SerializeField] private int m_maxOffsetOfSpawn;
    [SerializeField] private int m_amountOfSpawns;
    


    // Start is called before the first frame update
    void Start()
    {
        m_timerOfSpawn =  m_spawningDelay;
    }

    // Update is called once per frame
    void Update()
    {
        m_timerOfSpawn -= Time.deltaTime;
        if(m_timerOfSpawn <= 0)
        {
            for(int i = 0; i < m_amountOfSpawns; i++) 
            {
                BasicEnemySpawn();
            }
            m_timerOfSpawn = m_spawningDelay;
        }
    }

    [ContextMenu("Test Spawn")]
    private void BasicEnemySpawn()
    {
        var offsetMin = m_player.transform.position + Vector3.right * m_minOffsetOfSpawn;
        var offetMax = m_player.transform.position + Vector3.right * m_maxOffsetOfSpawn;
        var randomPositionX = Random.Range(offsetMin.x, offetMax.x);
        GameObject instance = m_pool.GetFirstAvalailableEnemyInPool();
        instance.transform.position = new Vector3(randomPositionX, 0,0);
        instance.SetActive(true);
    }
}
