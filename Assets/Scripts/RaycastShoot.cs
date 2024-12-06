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
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    public GameObject ImpactEffect;
    //private AudioSource gunAudio;
    private LineRenderer laserLine;
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
        laserLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        //fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                Debug.Log("Hit: " + hit.collider.name); // Add this line to debug hit detection
                EnemyDamage enemyDamage = hit.collider.GetComponent<EnemyDamage>();
                if (enemyDamage != null)
                {
                    enemyDamage.TakeDamage(gunDamage);
                }
                
                Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();
        laserLine.enabled = true;

        // Instantiate and play the muzzle flash
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, gunEnd.position, gunEnd.rotation);
        ParticleSystem ps = muzzleFlash.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        yield return shotDuration;

        laserLine.enabled = false;

        // Destroy the muzzle flash after the shot duration
        Destroy(muzzleFlash);
    }
}