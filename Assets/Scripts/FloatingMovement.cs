using UnityEngine;
using System.Collections;
/// <summary>
/// This class handles the movement of an object and rotation it is headed.
/// In this case, it is used as a player input.
/// </summary>
public class FloatingMovement : MonoBehaviour {
    [SerializeField]
    private float speed;
	[SerializeField]
	private float rotateSpeed = 3;
    [SerializeField]
    private Rigidbody rigidBody;

	void Update () {
        //rigidbody's velocity is made 0 every time.
        rigidBody.velocity = Vector3.zero;
	}
    
    //Function to move forward.
    public void Forward()
    {
        transform.Translate(Vector3.forward * speed );
    }
    //This updates the roation of the object. 
    //The y rotation is from the world space so that the object doesn't tilt on the side.
    public void Rotate(float xRotationSpeed, float yRotationSpeed)
    {
        transform.Rotate(-xRotationSpeed * rotateSpeed, 0,0);
        transform.Rotate(0, yRotationSpeed * rotateSpeed, 0, Space.World);
    }
}
