using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectileEffect : MonoBehaviour
{
    public GameObject firePoint; // The point from which the projectile will be spawned
    public GameObject projectilePrefab; // The projectile prefab to be spawned
    public float fireRate = 1f; // The rate at which the projectile is fired
    public Camera mainCamera; // Reference to the main camera
    public HUDManager HUDManager;
    
    public AudioSource laserSound;

    private float timeToFire = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire && HUDManager.shotsLeft > 0) // Left Mouse Button
        {
            timeToFire = Time.time + 1 / fireRate;
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        if (firePoint != null && projectilePrefab != null && mainCamera != null)
        {
            // Perform a raycast from the camera to the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3 targetPoint; // The point where the projectile will be spawned
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(1000); // Arbitrary large distance
            }

            // Calculate the direction from the fire point to the target point
            Vector3 direction = targetPoint - firePoint.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Instantiate the projectile and set its rotation
            Instantiate(projectilePrefab, firePoint.transform.position, rotation);
            
            //play lasersound
            laserSound.Play();
        }
        else
        {
            Debug.LogError("Fire Point, Projectile Prefab, or Main Camera is not assigned.");
        }
    }
}