using UnityEngine;

public class SpaceShipController : MonoBehaviour
{

    [SerializeField] float angulerSpeed = 90;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float accel = 10;
    [SerializeField] float drag = 0.5f;

    [SerializeField] Projectile projectile;
        

    Vector3 velocity;

    void Update()
    {

        //Shoot--------------------
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.SetStartVelocity(velocity);
        }


        float rotationInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -rotationInput * angulerSpeed * Time.deltaTime);

        transform.position += velocity * Time.deltaTime;


    }

    void FixedUpdate()
    {




        //Accel handling-------------------

        float movementInput = Input.GetAxisRaw("Vertical");

        if (movementInput < 0) movementInput = 0;
        Vector3 accelVector = transform.up * movementInput * this.accel;
        velocity += accelVector * Time.fixedDeltaTime;
        Vector3 dragVector = velocity * drag;
        velocity -= dragVector * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

    }
}
