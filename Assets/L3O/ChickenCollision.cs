using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollision : MonoBehaviour
{
    private bool hasTouched;

    private ChickenAudioManager audioManager;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private GameObject particles;
    private GameObject explosion;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;
    private Vector3 direction;
    [SerializeField] private GameObject eggPrefab;

    private void Start()
    {
        audioManager = gameObject.GetComponent<ChickenAudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasTouched)
        {
            audioManager.PlayClip(0);
            trailRenderer.enabled = !trailRenderer.enabled;
            direction = collision.transform.position - transform.position;
            explosion = Instantiate(particles, transform.position, Quaternion.identity);
            explosion.transform.forward = -direction;
            Destroy(explosion, 3);
            hasTouched = true;
            meshRenderer.enabled = false;
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject,3);
        }
    }
} 