using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrollerfinal : MonoBehaviour 
{
    public NavMeshAgent agent;
    public float range;
    private GameObject player;
    public Transform centrePoint; 
    public AudioSource patrollerAudioSource;
    private bool playerSeen = false;
    private int toggle = 0;

    private void setToggle()
    {
        toggle = 1;
    }

    private void unsetToggle()
    {
        toggle = 0;
    }

   
    // Not sure if we need this section anymore 
    // I think we were going have a large area for the colliders on the pattrollers 
    // so they could see thge player within a certain range. Have commented out for now.
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            playerSeen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            playerSeen = false;
        }
    }
    */

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        print("Getting ref to player");
        player = GameObject.Find("Player");

        // Find patroller audio source component
        patrollerAudioSource = GetComponentInChildren(typeof(AudioSource)) as AudioSource;
        print(patrollerAudioSource);
        patrollerAudioSource.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            this.playerSeen = true;
            this.patrollerAudioSource.enabled = true; // enable patroller audio when the player moves
        } else {
            this.playerSeen = false;
            this.patrollerAudioSource.enabled = false; // disable patroller audio when the player moves
        }

        if(playerSeen) // If our player has been seen, get the fecker!!
        {
            Vector3 currrentPlayerPosition = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);         
            agent.SetDestination(target: currrentPlayerPosition);
            setToggle();

        } else {
            // We want to somehow run agent.SetDestination(target: point) JUST ONCE here; 
            if (toggle == 1)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(target: point);
                    
                }
                unsetToggle();
            }
            if(agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(target: point);
                    
                }
            }  
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 100.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            //Debug.Log("Genrating random point");
            result = hit.position;
            return true;
        }

        result = randomPoint;
        return true;
    }   
}