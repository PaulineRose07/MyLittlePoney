using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    [Header("--- Basic Enemy Pool ---")]
    [SerializeField] private List<GameObject> m_poolOfBasicEnemy = new List<GameObject>();
    [SerializeField] private int m_amountOfBasicEnemiesInPool;
    [SerializeField] private GameObject m_basicEnemyPrefab;
    [SerializeField] private Transform m_basicTransform;
    [Space(16)]
    [Header("--- Basic Enemy Pool ---")]
    [SerializeField] private List<GameObject> m_poolOfFlyingEnemy = new List<GameObject>();
    [SerializeField] private int m_amountOfFlyingEnemiesInPool;
    [SerializeField] private GameObject m_flyingEnemyPrefab;
    [SerializeField] private Transform m_flyingTransfom;
    [Header("--- Star Pool ---")]
    [SerializeField] private List<GameObject> m_poolOfStar = new List<GameObject>();
    [SerializeField] private int m_amountOfStarsInPool;
    [SerializeField] private GameObject m_starPrefab;
    [SerializeField] private Transform m_starTransform;
    [Header("--- Fruits Pool ---")]
    [SerializeField] private List<GameObject> m_poolOfFruits = new List<GameObject>();
    [SerializeField] private int m_amountOfFruitsInPool;
    [SerializeField] private GameObject m_fruitsPrefab;
    [SerializeField] private Transform m_fruitsTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_amountOfBasicEnemiesInPool; i++)
        {
            var instance = Instantiate(m_basicEnemyPrefab, m_basicTransform);
            instance.gameObject.SetActive(false);
            m_poolOfBasicEnemy.Add(instance);
        }

        for(int i = 0; i < m_amountOfFlyingEnemiesInPool; i++)
        {
            var instance = Instantiate(m_flyingEnemyPrefab, m_flyingTransfom);
            instance.gameObject.SetActive(false);
            m_poolOfFlyingEnemy.Add(instance);
        }
        
        for(int i = 0; i <m_amountOfStarsInPool; i++)
        {
            var instance = Instantiate(m_starPrefab, m_starTransform);
            instance.gameObject.SetActive(false);
            m_poolOfStar.Add(instance);
        }

        for(int i = 0; i < m_amountOfFruitsInPool; i++)
        {
            var instance = Instantiate(m_fruitsPrefab, m_fruitsTransform);
            instance.gameObject.SetActive(false);
            m_poolOfFruits.Add(instance);
        }
    }


    public GameObject GetFirstAvailableBasket()
    {
        for(int i = 0; i < m_poolOfFruits.Count; i++)
        {
            if (m_poolOfFruits[i].activeSelf == false) return m_poolOfFruits[i];
        }

        var instance = Instantiate(m_fruitsPrefab, m_fruitsTransform);
        instance.gameObject.SetActive(false);
        m_poolOfFruits.Add(instance);
        return instance;
    }
    public GameObject GetFirstAvailableStar()
    {
        for(int i = 0; i < m_poolOfStar.Count; i++)
        {
            if (m_poolOfStar[i].activeSelf == false) return m_poolOfStar[i];
        }

        var instance = Instantiate(m_starPrefab, m_starTransform);
        instance.gameObject.SetActive(false);
        m_poolOfStar.Add(instance);
        return instance;
    }
    public GameObject GetFirstAvailableFlyingEnemyInPool()
    {
        for(int i = 0; i < m_poolOfFlyingEnemy.Count; i++)
        {
            if (m_poolOfFlyingEnemy[i].activeSelf == false) return m_poolOfFlyingEnemy[i];
        }

        var instance = Instantiate(m_flyingEnemyPrefab, m_flyingTransfom);
        instance.gameObject.SetActive(false);
        m_poolOfFlyingEnemy.Add(instance);
        return instance;
    }
    public GameObject GetFirstAvalailableBasicEnemyInPool()
    {
        for (int i = 0; i < m_poolOfBasicEnemy.Count; i++)
        {
            if (m_poolOfBasicEnemy[i].activeSelf == false) return m_poolOfBasicEnemy[i];
        }

        GameObject instanceNewEnemy = Instantiate(m_basicEnemyPrefab, m_basicTransform);
        instanceNewEnemy.gameObject.SetActive(false);
        m_poolOfBasicEnemy.Add(instanceNewEnemy);
        return instanceNewEnemy;
    }



}
