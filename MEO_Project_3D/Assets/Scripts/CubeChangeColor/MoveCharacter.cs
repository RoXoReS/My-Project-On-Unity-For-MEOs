using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveCharacter : MonoBehaviour
{
    [SerializeField]
    [Header("Скорость")]
    [Range(0, 10)]
    private int Speed;
    public int Heath = 100;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float DirectionZ = Input.GetAxis("Horizontal");
        float DirectionX = Input.GetAxis("Vertical");
        Vector3 Move = new Vector3(DirectionX, 0, -DirectionZ);
        rb.MovePosition(rb.position + Move * Speed * Time.deltaTime);
    }
}
