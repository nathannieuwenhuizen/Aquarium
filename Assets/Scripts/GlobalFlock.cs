using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// The global flock spawns the agents and makes the list for it.
/// </summary>
public class GlobalFlock : MonoBehaviour {
    [SerializeField]
    private GameObject agent;
    [SerializeField]
    private int numberOfAgents = 10;

    List<GameObject> agents = new List<GameObject>();

    [SerializeField]
    private float size;

    void Start()
    {

        //Spawning of the agents.
        for (int i = 0; i < numberOfAgents; i++)
        {
            //Spawn position made random.
            Vector3 spawnPosition = new Vector3(-size + Random.value * 2 * size,
                                                -size + Random.value * 2 * size,
                                                -size + Random.value * 2 * size);
            //Makes the object and adds it to the list.
            GameObject tempAgent = Instantiate(agent, spawnPosition, Quaternion.identity) as GameObject;
            tempAgent.GetComponent<Agent>().GlobalFlock = this;
            agents.Add(tempAgent);
        }
    }
    //Public list for the agent class to call for.
    public List<GameObject> Agents {
        get { return agents; }
    }
}
