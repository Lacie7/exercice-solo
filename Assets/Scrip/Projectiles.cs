using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour

    
{
    [SerializeField] private float speed;

    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
       
        var RobotGameObject = GameObject.FindWithTag("Player");
        var Projectiles = RobotGameObject.GetComponent<Projectiles>();
        RobotBehaviourScript.onDeath.AddListener(Die);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector3
        {
            x = speed * Time.fixedDeltaTime,
            y = 0,
            z = 0
        };
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}