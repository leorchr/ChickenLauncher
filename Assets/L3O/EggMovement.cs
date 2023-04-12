using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EggMovement : MonoBehaviour
{
    [SerializeField] GameObject chicken;
    private Rigidbody rb;
    private float randomRotation;
    private Quaternion randomRotationQuaternion;

    [SerializeField] private GameObject particles;
    private GameObject explosion;
    private Vector3 direction;



    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;
        rb.AddRelativeForce(new Vector3(0, 250, 0));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.y < 0.1f)
        {
            direction = collision.transform.position - transform.position;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        randomRotation = Random.Range(0, 361);
        randomRotationQuaternion = Quaternion.Euler(0, randomRotation, 0);
        Instantiate(chicken, transform.position, randomRotationQuaternion);

        explosion = Instantiate(particles, transform.position, Quaternion.identity);
        explosion.transform.forward = -direction;
        Destroy(explosion, 1);
    }
}
