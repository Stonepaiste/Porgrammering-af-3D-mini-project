using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f; // Distance the player can see
    public GameObject mainCameraObject; // Reference to the main camera GameObject
    private Camera fpsCam; // Reference to the first person camera component

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (fpsCam != null)
        {
            Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)); // Origin of the raycast
            Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green); // Draw the raycast
        }
    }
}
