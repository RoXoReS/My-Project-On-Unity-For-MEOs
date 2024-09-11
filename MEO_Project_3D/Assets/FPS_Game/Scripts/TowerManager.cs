using System.Collections;
using System.Collections.Generic;
using TravisGameAssets;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [Header("Характеристики Всех Башен")]
    public string TowerName;
    public int TowerIndex;
    public int TowerPrice;
    public int Damage;
    public int DamageRadius;
    public int FireRate;
    public int FireSpeed;
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected Transform FirePoint;
    public int Level;
    [Space]
    [Header("Свойства для кода")]
    [SerializeField] protected LayerMask EnemyLayer;
    [SerializeField] protected Animator anim;
    protected Transform currentTarget;
    protected float nextTimeToFire = 0f;
    
    void Start()
    {
        InvokeRepeating("FindTarget", 0f, 1f); // Ищите врага каждые 1 секунду
    }

    void Update()
    {
        if (currentTarget != null)
        {
            LookToEnemy(currentTarget);
            FireAtEnemy();
        }
    }

    void FindTarget()
    {
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, DamageRadius, EnemyLayer);
        Transform bossTarget = null;
        Transform regularTarget = null;

        foreach (var enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Boss"))
            {
                bossTarget = enemy.transform;
                break;
            }
            else
            {
                if (regularTarget == null)
                {
                    regularTarget = enemy.transform;
                }
            }
        }

        currentTarget = bossTarget != null ? bossTarget : regularTarget;
    }

    public virtual void FireAtEnemy()
    {
        
    }

    void LookToEnemy(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 1000f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DamageRadius);
    }
}
