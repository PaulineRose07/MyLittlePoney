using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    [SerializeField] private int m_amountOfBasicEnemiesInPool;
    [SerializeField] private List<GameObject> m_basicEnemyPool = new List<GameObject>();
    [SerializeField] private GameObject m_basicEnemyPrefab;
    [SerializeField] private Transform m_basicTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_amountOfBasicEnemiesInPool; i++)
        {
            var instance = Instantiate(m_basicEnemyPrefab, m_basicTransform);
            instance.gameObject.SetActive(false);
            m_basicEnemyPool.Add(instance);
        }
    }

    public GameObject GetFirstAvalailableEnemyInPool()
    {
        for (int i = 0; i < m_basicEnemyPool.Count; i++)
        {
            if (m_basicEnemyPool[i].activeSelf == false) return m_basicEnemyPool[i];
        }

        GameObject instanceNewEnemy = Instantiate(m_basicEnemyPrefab, m_basicTransform);
        instanceNewEnemy.gameObject.SetActive(false);
        m_basicEnemyPool.Add(instanceNewEnemy);
        return instanceNewEnemy;

    }

}
