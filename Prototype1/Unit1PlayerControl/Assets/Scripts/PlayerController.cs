using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement tuning (editable in spector)
    public float speed = 5.0f;
    public float turnSpeed;

    //Input System action exposed in inspector for binding (WASD/Arrow keys)
    public InputAction MoveAction;

    //Current input value (x=left and right, y=forward and backwards), kept for private internal use
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enables move action so it starts reading input
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Read the 2d vector from the move action
        moveInput = MoveAction.ReadValue <Vector2>();


        //Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        //Rotate Vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);   
    }
}
