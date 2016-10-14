using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// The agent class is on the entity that will flock in the group.
/// It uses three methods of rules.
/// -The cohesion
/// -The speration 
/// -The allignment
/// </summary>
public class Agent : MonoBehaviour {
    //Variables that can be tweaked in the editor.
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float detectionDistance;

    //Th variables needed for the flocking calculations.
    private Vector3 seperationVector, cohesionVector, myPosition,neigbourPosition, myDirection;
    private float averageSpeed, distance;
    private int neighbourCount;

    //Rigidbody and globalFlock.
    private Rigidbody rigidBody;
    private GlobalFlock globalFlock;


    void Start()
    {
        //rigidbody declared and speed random declared.
        rigidBody = GetComponent<Rigidbody>();
        speed = Random.Range(maxSpeed / 10, maxSpeed);
    }
    void Update()
    {
        //Flocking rules called at random times.
        if(Random.Range(0,100) > 60)
            ApplyRules();

        //Rigidbody s velocity made 0 so it doesnt bump out of its position.
        rigidBody.velocity = Vector3.zero;

        //Moving forward.
        transform.Translate(0, 0, Time.deltaTime * speed);
    }


    /// <summary>
    /// The function that applies the flocking rules to the object.
    /// </summary>
    void ApplyRules()
    {
        //Variables delcared zero.
        neighbourCount = 0;
        averageSpeed = 0;
        cohesionVector = seperationVector = Vector3.zero;

        //Position of the agent is delcared for optimization.
        myPosition = transform.position;


        //Checks eacht agent in its flocking group.
        foreach(GameObject neighbour in globalFlock.Agents)
        {
            //not the agent itself.
            if(neighbour != this.gameObject)
            {
                //Calculates the distance between the agent and neigbour.
                neigbourPosition = neighbour.transform.position;
                distance = Vector3.Distance(neigbourPosition,myPosition);
                if(distance < detectionDistance)
                {
                    //Cohesion vector adds up with the neighbours position.
                    cohesionVector += neigbourPosition;
                    neighbourCount++;

                    //Checks the distance on a clooser range.
                    if(distance < detectionDistance/2)
                    {
                        //Seperation vector adds up with the distance of the neighbour and the agent.
                        seperationVector += myPosition - neigbourPosition;
                    }
                    //Average speed adds up.
                    averageSpeed += neighbour.GetComponent<Agent>().Speed;
                }
            }
        }

        //If a neighbour is detected, the cohesion- and seperation vector is devided by the neighbourcount.
        if(neighbourCount > 0)
        {
            cohesionVector = cohesionVector / neighbourCount + (globalFlock.transform.position - myPosition);
            speed = averageSpeed / neighbourCount;
        }
        //The direction is calculated for the agent it wants to go to.
        myDirection = cohesionVector + seperationVector - myPosition;
        //Rotation is edited based on slerp towards the direction the agent wants to go to.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myDirection), rotationSpeed * Time.deltaTime);
    }
    
    public float Speed
    {
        get { return speed; }
    }
    public GlobalFlock GlobalFlock
    {
        set { globalFlock = value; }
    }
}
