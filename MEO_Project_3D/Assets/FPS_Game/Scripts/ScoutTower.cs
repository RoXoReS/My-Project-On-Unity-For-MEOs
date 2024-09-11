using UnityEngine;

public class ScoutTower : TowerManager
{
    public override void FireAtEnemy()
    {
        if (currentTarget != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(FirePoint.position, (currentTarget.position - FirePoint.position).normalized, out hit, DamageRadius))
            {
                if (hit.transform == currentTarget && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 0.5f / FireRate;
                    anim.SetTrigger("Fire");
                    Debug.Log("Враг Найден: " + hit.point);
                    GameObject projectile = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
                    projectile.GetComponent<Rigidbody>().velocity = (currentTarget.position - FirePoint.position).normalized * FireSpeed;
                    Destroy(projectile, 2f);
                }
            }
        }
    }
}