using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] TowerManager Tower;
    void Start()
    {
        Tower = GameObject.FindObjectOfType<TowerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
            other.gameObject.GetComponent<EnemyManager>().health -= Tower.Damage;
            Destroy(gameObject);
        }
    }
}
