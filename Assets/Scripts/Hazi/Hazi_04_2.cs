using UnityEngine;

public class Hazi_04_2 : MonoBehaviour
{
    [SerializeField] float accel = 10;
    [SerializeField] float jumpForce = 1;
    [SerializeField] Transform upperLimit;
    [SerializeField] Transform lowerLimit;
    Vector3 velocity;
    bool runGame = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitScene();
        runGame = true;
    }

    void InitScene()
    {
        transform.position = new Vector3(transform.position.x, (upperLimit.position.y + lowerLimit.position.y) / 2, transform.position.z);
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (runGame == true)
        {
            transform.position += velocity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
                velocity = Vector3.zero;
            }

            if (transform.position.y > upperLimit.position.y || transform.position.y < lowerLimit.position.y)
            {
                Debug.Log("Game over");
                InitScene();
                runGame = false;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = Vector3.zero;
                runGame = true;
            }
        }




    }

    void FixedUpdate()
    {
        Vector3 accelVector = transform.up * -1 * this.accel;
        velocity += accelVector * Time.fixedDeltaTime;

    }
}
