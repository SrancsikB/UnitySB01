using UnityEngine;

public class Hazi_06_1 : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Vector3 newGravityVector = Vector3.up;
    [SerializeField] float newGravity;

    Vector3 gravityVector = Vector3.down;
    float gravity = 9.81f;

    float distance;

    private void Start()
    {
        distance = transform.localScale.x / 2;
    }


    void Update()
    {

        foreach (GameObject item in objects)
        {
            if ((item.transform.position - transform.position).magnitude <= distance)
            {
                item.GetComponent<Rigidbody>().AddForce(newGravityVector * newGravity);
            }
            else
            {
                item.GetComponent<Rigidbody>().AddForce(gravityVector * gravity);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
