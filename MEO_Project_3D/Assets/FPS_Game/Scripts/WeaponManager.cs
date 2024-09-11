using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Характеристики Оружия")]
    [SerializeField, Range(0, 4)] int IndexWeapon;
    [SerializeField, Range(0, 60)] int BulletMax;
    [SerializeField, Range(0, 1000)] int Bullets;
    [SerializeField] bool InfinityBullets;
    [SerializeField, Range(0, 100)] int BulletDamage;
    [SerializeField, Range(0, 100)] float FireRate;
    [SerializeField, Range(0, 5)] float ReloadTime;
    [SerializeField, Range(0, 100)] int impactForce;
    [Header("Свойства для кода")]
    [SerializeField] Transform Camera;
    [SerializeField] ParticleSystem Flash;
    [SerializeField] ParticleSystem Impact;
    [SerializeField] GameObject ReloadText;
    [SerializeField] TextMeshProUGUI BulletText;
    [SerializeField] TextMeshProUGUI AmmoText;
    [SerializeField] Animator anim;
    private float nextTimeToFire = 0f;
    public float distance;
    RaycastHit hitInfo;
    int tempBulletmax;
    int ReloadedBullet;
    public bool CanFire;
    public bool HaveReload;
    void Start()
    {
        CanFire = true;
        HaveReload = false;
        tempBulletmax = BulletMax;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        BulletText.text = BulletMax.ToString();
        AmmoText.text = Bullets.ToString();
        
        if (CanFire == true)
        {
            WeaponFire();
            WeaponReload();
        }
    }

    void WeaponFire()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            if (BulletMax != 0)
            {
                nextTimeToFire = Time.time + 1f / FireRate;
                Flash.Play();
                anim.SetTrigger("Fire");
                RaycastHit hit;
                if (Physics.Raycast(Camera.position, Camera.forward, out hit, distance))
                {
                    if (hit.rigidbody != null)
                    {
                        hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                        if (hit.rigidbody.gameObject.CompareTag("Enemy"))
                        {
                            hit.rigidbody.gameObject.GetComponent<EnemyManager>().health -= BulletDamage;
                        }
                    }
                    ParticleSystem impacts = Instantiate(Impact, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impacts.gameObject, 2f);
                }
                if (InfinityBullets)
                {

                }
                else
                {
                    BulletMax--;
                }
            }
            
        }
    }

    void WeaponReload()
    {
        if (Input.GetKey(KeyCode.R) && BulletMax != tempBulletmax && Bullets > 0)
        {
            CanFire = false;
            if (Bullets >= tempBulletmax)
            {
                ReloadedBullet = BulletMax - tempBulletmax;
                ReloadedBullet *= -1;
            }
            else if (Bullets < tempBulletmax)
            {
                ReloadedBullet = Bullets;
            }
            BulletMax += ReloadedBullet;
            Bullets -= ReloadedBullet;
            anim.SetTrigger("Reloading");
            StartCoroutine(ReloadCoroutine(ReloadTime));
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Camera.position, Camera.forward * distance);
    }

    IEnumerator ReloadCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        CanFire = true;
    }

}

