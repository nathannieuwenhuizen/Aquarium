using UnityEngine;
using System.Collections;
/// <summary>
/// This class is responsible for the inputs the user makes in the application.
/// </summary>
public class Inputs : MonoBehaviour {
    [SerializeField]
    private FloatingMovement movement;
	
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            movement.Forward();
        }
        movement.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
