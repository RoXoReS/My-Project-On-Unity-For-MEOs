using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTilePrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MoveCharacter>().Heath -= 1;
            Destroy(gameObject);
        }
    }
}
