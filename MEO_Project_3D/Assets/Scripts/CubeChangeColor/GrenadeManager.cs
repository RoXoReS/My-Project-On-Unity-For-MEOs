using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{
    [SerializeField] float ExposionDelay;
    [SerializeField] float ExposionRadius;
    [SerializeField] int ExposionDamage;
    [SerializeField] LayerMask DamagableLayer;
    [SerializeField] AnimationCurve GrenadeDistance;
    [SerializeField] Vector3 InitialPosition;
    [SerializeField] Vector3 TargetPosition;
    [SerializeField] float ElapsedTime;
    [SerializeField] float TimeToEnd;
    [SerializeField] float ThrowDistance;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        //Invoke(nameof(Explode), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        AnimationThrow();
    }

    void AnimationThrow()
    {
        float et = ElapsedTime += Time.deltaTime;
        float heightMultiplier = GrenadeDistance.Evaluate(et);
        Vector3 currentPosition = Vector3.Slerp(InitialPosition, TargetPosition, et);
        currentPosition.y += heightMultiplier * ThrowDistance;
        transform.position = currentPosition;
        if (ElapsedTime < ThrowDistance)
        {
            ElapsedTime = 0f;
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExposionRadius, DamagableLayer);
        foreach (Collider item in colliders)
        {
            if (item.GetComponent<EnemyAI>() != null)
            {
                item.GetComponent<EnemyAI>().TakeDamage(ExposionDamage);
            }
        }

        Destroy(gameObject, 2f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExposionRadius);
    }
}
