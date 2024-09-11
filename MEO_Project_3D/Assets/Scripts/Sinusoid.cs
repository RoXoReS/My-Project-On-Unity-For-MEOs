using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinusoid : MonoBehaviour
{
    [SerializeField] private AnimationCurve MoveAnimation;
    [SerializeField] private float Duration;
    [SerializeField] private float Distance;
    [SerializeField] private float TimeElapsed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeElapsed < Distance)
        {
            TimeElapsed += Time.deltaTime;
            float t = TimeElapsed / Distance;
            float CurrentPos = MoveAnimation.Evaluate(t);
            transform.position = new Vector3(0,0,transform.position.z + CurrentPos * Time.deltaTime);
        }
        else
        {
            TimeElapsed = 0;
        }
    }
}
