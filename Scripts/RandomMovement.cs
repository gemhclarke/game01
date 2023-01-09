using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour 
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    private bool agentActive = true;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Awake()
    {
        //GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        print(agent + " RandomMovement.cs subscribing to GameState events");
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    
    void Update()
    {
        if (agentActive)
        {
            if(agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                    //agent.
                    
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

    private void OnGameStateChanged(GameState newGameState)
    {
        print("GameState changed to " + newGameState + " for " + this);
        if (newGameState == GameState.Paused)
        {
            this.agentActive = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else if (newGameState == GameState.GamePlay)
        {
            this.agentActive = true;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}