using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChickenProjectile : MonoBehaviour
{
    [Header("ChickenLauncher")]
    public bool startLaunch = false;
    public GameObject chickenPrefab;
    public int torqueStrenght = 500;
    private GameObject chicken;
    private Rigidbody rbChicken;
    private ChickenAudioManager chickenAudioManager;

    public void StartLaunch()
    {
        chicken = Instantiate(chickenPrefab, transform.position, transform.rotation);
        rbChicken = chicken.transform.GetChild(0).GetComponent<Rigidbody>();
        rbChicken.AddRelativeForce(new Vector3(0, 0, PlayerMovement.instance.launchPower));
        PlayerMovement.instance.launchPower = 250f;
        rbChicken.AddTorque(transform.right * 500);
        chickenAudioManager = chicken.transform.GetChild(0).GetComponent<ChickenAudioManager>();
        chickenAudioManager.PlayClip(1); 
    }

    public IEnumerator delayBeforeShoot(SkinnedMeshRenderer meshRenderer)
    {
        yield return new WaitForSeconds(PlayerMovement.instance.delayBetweenShoot);
        meshRenderer.enabled = true;
        PlayerMovement.instance.canShoot = true;
    }
}