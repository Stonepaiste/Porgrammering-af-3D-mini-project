using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour

{
    public GameObject player;
    public NavMeshAgent myAgent;
    public GameObject currentTarget;
    

    public int range; // if player is within this range, enemy will follow
    public int tetherRange; // if player goes out of range, enemy will return to this range
    public Vector3 startPosition; // where the enemy starts
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("distanceCheck", 0, 0.5f);
        startPosition = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTarget != null)
        {
            myAgent.SetDestination(currentTarget.transform.position);
        }
        else if (myAgent.destination != startPosition)
        {
            myAgent.SetDestination(startPosition);
        }
    }
    
    public void distanceCheck()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist<range)
        {
            currentTarget = player;
        }
        else if (dist>tetherRange)
        {
            currentTarget = null;
        }
    
    }
}


