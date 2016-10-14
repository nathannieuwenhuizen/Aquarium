using UnityEngine;
using System.Collections;
/// <summary>
/// This class makes a position get random positions at random time intervals.
/// </summary>
public class RandomPositionAtRandomInterval : MonoBehaviour {
    //Variables for the editor
    [SerializeField]
    private float minimumWaitingTime;
    [SerializeField]
    private float maximumWaitingTime;
    
    void Start () {
        //Begins the coroutine.
        StartCoroutine(Wait());
	}

    IEnumerator Wait()
    {
        GetRandomPosition();

        //Waits for a random time to be called again.
        yield return new WaitForSeconds(minimumWaitingTime + Random.value * (maximumWaitingTime-minimumWaitingTime));
        StartCoroutine(Wait());
    }

    //Makes the position random.
    void GetRandomPosition()
    {
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-2, 5), Random.Range(-10, 10));
    }
}
