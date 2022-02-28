using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//requires the object this script is attatched to to have a CharacterController component before running
[RequireComponent(typeof(CharacterController))]
//adds this script as a standard component in Unity allowing me to use it for more than one object in the scene
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    //create variables that I can then change dirrectly in the Unity scene editor wihtout having to revisit this code especcially useful in testing different values
    public float speed = 6.0f;
    public float gravity = -9.8f;

    //this next piece gets the object's CharacterController which will allow me to give the player movement
    private CharacterController charController;

    //happens once at the biginning of the game
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }
    //happens ever frame
    void Update()
    {
        //sets the deltaX to whether a WS key was pressed
        //deltaZ to AD
        //The Input.GetAxis("Horizontal") acesses certain the Horizontal variable in the unity editor
        //W for positive and S for negative are the default keys
        //The vertical is the same except for D being positive and A being negative
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //creates a vector3 which is set to our horizontal and vertical motions of deltaX and deltaZ
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //clamps the movement by the speed
        //this is to ensure when the player moves diagonally which would be the combination of both horizontal and vertical motions
        //the diagonal speed is not greater than the set speed
        movement = Vector3.ClampMagnitude(movement, speed);

        //sets the vector3's y value did not do it earlier because we do not want the clamp to affect gravity
        movement.y = gravity;

        //stops computer speed from affecting player speed
        movement *= Time.deltaTime;
        //we have allready creaated the movement here it is executed
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
