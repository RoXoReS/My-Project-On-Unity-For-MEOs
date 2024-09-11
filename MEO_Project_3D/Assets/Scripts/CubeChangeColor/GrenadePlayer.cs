using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePlayer : MonoBehaviour
{
    [SerializeField] GameObject GrenadePref;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrowGrenade();
    }

    void ThrowGrenade()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(GrenadePref, transform.position, Quaternion.identity);
        }
    }
}
