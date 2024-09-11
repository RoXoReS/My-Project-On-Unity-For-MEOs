using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    float DistanceView;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    float SpeedBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer();
    }

    void CheckPlayer()
    {
        float DistancePlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (DistancePlayer <= DistanceView)
        {
            Vector3 DirectionPlayer = (Player.transform.position - transform.position).normalized;
            Ray ray = new Ray(transform.position, DirectionPlayer);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, DistancePlayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    GameObject tempBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
                    tempBullet.GetComponent<Rigidbody>().velocity = DirectionPlayer * SpeedBullet;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * DistanceView);
    }
}
