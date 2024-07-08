using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private float m_speedOfBounce = 15f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<PlayerMovement>(out PlayerMovement _player);
        _player.BoucingOnThings(m_speedOfBounce);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
