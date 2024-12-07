using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public RotateToMouse rotateToMouse;

    int selectedPrefab = 0;

    public List<GameObject> Effects = new List<GameObject>();
    private GameObject effectToSpawn;
    private float timeToFire = 0;
    private Text prefabName;

    void Start()
    {
        effectToSpawn = Effects[0]; // Default Effect
        //prefabName = GameObject.Find("PrefabName").GetComponent<Text>(); // Prefab Name On Screen
    }

    void Update()
    {
        // Shoot Effect
        if (Input.GetMouseButtonDown(1) && Time.time >= timeToFire) // Left Mouse Button
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate; // Fire Rate
            SpawnEffects();
        }

        // Prefab Name On Screen
        /*if (Effects.Length > 0 && selectedPrefab >= 0 && selectedPrefab < Effects.Length)
        {
            prefabName.text = Effects[selectedPrefab].name;
        }
        */
    }

    void SpawnEffects()
    {
        if (firePoint != null)
        {
            GameObject effectInstance = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                effectInstance.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}