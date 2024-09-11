using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallAnim : MonoBehaviour
{
    [SerializeField] AnimationCurve MoveCurve;
    [SerializeField] float Duration;
    [SerializeField] float Distance;
    [SerializeField] float ElapsedTime;
    [SerializeField] Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AnimCurveAnim();
    }

    void AnimCurveAnim()
    {
        if (ElapsedTime < Duration)
        {
            ElapsedTime += Time.deltaTime;
            float progress = ElapsedTime / Duration;

            float currentValue = MoveCurve.Evaluate(progress);
            float newY = StartPos.y + currentValue * Distance;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        else
        {
            ElapsedTime = 0f;
        }
    }
}
