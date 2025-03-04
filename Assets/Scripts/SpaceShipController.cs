using UnityEngine;
using System.Collections.Generic;

public class SpaceShipController : MonoBehaviour
{
   
    [SerializeField] float angulerSpeed = 90;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float accel = 10;
    //[SerializeField] float drag = 0.5f;

    [SerializeField] Projectile[] projectiles;
        

   

    int lastProj = 0;

    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //Shoot--------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //int randomIndex = Random.Range(0, projectiles.Length);

            int i = lastProj % projectiles.Length;

            Projectile newProjectile = Instantiate(projectiles[i], transform.position, transform.rotation);
            newProjectile.SetStartVelocity(rigidBody.linearVelocity);

            lastProj += 1;
            //if (lastProj >= projectiles.Length)
            //    lastProj = 0;
        }


        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -rotationInput * angulerSpeed * Time.deltaTime);
        rigidBody.rotation = transform.rotation.eulerAngles.z;

        //transform.position += velocity * Time.deltaTime;


    }

    void FixedUpdate()
    {




        //Accel handling-------------------

        float movementInput = Input.GetAxisRaw("Vertical");

        if (movementInput < 0) movementInput = 0;
        Vector2 accelVector = transform.up * movementInput * this.accel;
        rigidBody.linearVelocity += accelVector * Time.fixedDeltaTime;

        //rigidBody.AddForce(accelVector, ForceMode2D.Force);


        /*
        Vector3 dragVector = velocity * drag;
        velocity -= dragVector * Time.fixedDeltaTime;
        
        */

        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maxSpeed);
    }
}
