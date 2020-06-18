using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class RobotBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed; 
    private Inputs Inputs;
    private Vector2 direction;
    private void OnEnable()

    {
        Inputs = new Inputs();
        Inputs.Enable();
        Inputs.Robots.Move.performed += OnMovePerformed;
        Inputs.Robots.Move.canceled += OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)

    { 
        direction = obj.ReadValue<Vector2>();
     Debug.Log("direction");

    }
    private void OnMoveCanceled(InputAction.CallbackContext obj)

    {
        direction = Vector2.zero;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var myRigidBody = GetComponent<Rigidbody2D>();
        //direction.y = 0;
        if (myRigidBody.velocity.sqrMagnitude < maxSpeed)
        myRigidBody.AddForce(direction * speed);
    }
}
