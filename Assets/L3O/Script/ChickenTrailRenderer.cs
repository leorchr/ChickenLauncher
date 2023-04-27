using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenTrailRenderer : MonoBehaviour
{
    private Vector3 previousPosition;
    private Vector3 direction;
    public Transform trailRenderer;

    private void Update()
    {
        if(previousPosition != Vector3.zero)
        {
            direction = transform.position - previousPosition;
            trailRenderer.position += direction;
            previousPosition = transform.position;
        }
        else
        {
            previousPosition = transform.position;
        }
    }
}
