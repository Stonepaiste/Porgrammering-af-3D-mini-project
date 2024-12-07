using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public GameObject mainCameraObject; // Reference to the main camera GameObject
    public GameObject muzzleFlashPrefab; // Reference to the muzzle flash prefab
    public GameObject impactEffectPrefab; // Reference to the impact effect prefab
    //public GameObject ProjectilePrefab; // Reference to the projectile prefab
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

    void Start()
    {
        if (mainCameraObject != null)
        {
            fpsCam = mainCameraObject.GetComponent<Camera>();
        }
        else
        {
            Debug.LogError("Main Camera Object is not assigned.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                Debug.Log("Hit: " + hit.collider.name); // Add this line to debug hit detection
                EnemyDamage enemyDamage = hit.collider.GetComponent<EnemyDamage>();
                if (enemyDamage != null)
                {
                    enemyDamage.TakeDamage(gunDamage);
                }
                
                Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();

        // Instantiate and play the muzzle flash
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, gunEnd.position, gunEnd.rotation);
        ParticleSystem ps = muzzleFlash.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
         
        }

        yield return shotDuration;

        // Destroy the muzzle flash after the shot duration
        Destroy(muzzleFlash);
    }
}