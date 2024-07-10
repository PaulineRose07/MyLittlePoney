using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    [Header("--- In Game Links ---")]
    [SerializeField] GameObject m_player;
    [SerializeField] PoolSystem m_pool;
    [Header("--- Balancing Info")]
    [SerializeField] private int m_minOffsetOfSpawnX;
    [SerializeField] private int m_maxOffsetOfSpawnX;
    [SerializeField] private int m_amountOfSpawns;
    [SerializeField] private float m_baseSpawnY = 1.48f;
    [SerializeField] private float m_spawningDelay;
    private float m_timerOfSpawn;



    // Start is called before the first frame update
    void Start()
    {
        m_timerOfSpawn = m_spawningDelay;
    }

    // Update is called once per frame
    void Update()
    {
        m_timerOfSpawn -= Time.deltaTime;
        if (m_timerOfSpawn <= 0)
        {
            for (int i = 0; i < m_amountOfSpawns; i++)
            {
                Spawn();
            }
            m_timerOfSpawn = m_spawningDelay;
        }
    }

    [ContextMenu("Test Spawn")]
    private void Spawn()
    {
        var offsetMin = m_player.transform.position + Vector3.right * m_minOffsetOfSpawnX;
        var offetMax = m_player.transform.position + Vector3.right * m_maxOffsetOfSpawnX;
        var randomPositionX = Random.Range(offsetMin.x, offetMax.x);
        GameObject instance = m_pool.GetFirstAvailableBasket();
        instance.transform.position = new Vector3(randomPositionX, m_baseSpawnY, 0);
        instance.SetActive(true);
    }
}
