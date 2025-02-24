using UnityEngine;

public class Hazi_04_1 : MonoBehaviour
{

    [SerializeField] float accel = 10;

    Vector3 velocity;

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            velocity = Vector3.zero;
        }
            
    }

    void FixedUpdate()
    {
               
        Vector3 accelVector = transform.up * -1 * this.accel;
        velocity += accelVector * Time.fixedDeltaTime;
               

    }
}
