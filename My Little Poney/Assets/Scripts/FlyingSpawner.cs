
using UnityEngine;

public class FlyingSpawner : MonoBehaviour
{
    [Header("--- In game Links ---")]
    [SerializeField] GameObject m_player;
    [SerializeField] PoolSystem m_pool;
    [Header("--- Balancing Info ---")]
    [SerializeField] private int m_minOffsetOfSpawnX;
    [SerializeField] private int m_maxOffsetOfSpawnX;
    [SerializeField] private int m_minOffsetY;
    [SerializeField] private int m_maxOffsetY;
    [SerializeField] private int m_amountOfSpawns;
    [SerializeField] private float m_spawningDelay;
    private float m_timerOfSpawn;
    private bool m_canSpawnFlying;



    // Start is called before the first frame update
    void Start()
    {
        m_canSpawnFlying = false;
        m_timerOfSpawn = m_spawningDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canSpawnFlying)
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
    }

    //[ContextMenu("Test Spawn")]
    private void Spawn()
    {
        Vector3 offsetMinX = m_player.transform.position + Vector3.right * m_minOffsetOfSpawnX;
        Vector3 offetMaxX = m_player.transform.position + Vector3.right * m_maxOffsetOfSpawnX;
        float randomPositionX = Random.Range(offsetMinX.x, offetMaxX.x);

        Vector3 offsetMinY = m_player.transform.position + Vector3.up * m_minOffsetY;
        Vector3 offsetMaxY = m_player.transform.position + Vector3.up * m_maxOffsetY;
        float randomPositionY = Random.Range(offsetMinY.y, offsetMaxY.y);

        GameObject instance = m_pool.GetFirstAvailableFlyingEnemyInPool();
        instance.transform.position = new Vector3(randomPositionX, randomPositionY, 0);
        instance.SetActive(true);
    }

    public void EnemyCanSpawn()
    {
        m_canSpawnFlying = true;
        m_timerOfSpawn = 0.2f;
    }
}
