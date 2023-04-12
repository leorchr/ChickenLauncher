using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Windows;

public class ChickenMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 deplacement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + deplacement);
    }
}
