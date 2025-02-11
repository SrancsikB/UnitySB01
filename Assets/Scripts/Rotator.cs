using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] float angluarSpeed = 360;
    [SerializeField] Vector3 axis = Vector3.up;
    [SerializeField] Space space;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, angluarSpeed * Time.deltaTime, space);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 transformedAxis = axis;

        if (space==Space.Self)
        {
            //transformedAxis = transform.InverseTransformVector(axis); //local to global
            transformedAxis = transform.TransformVector(axis); //global to local
        }

        Gizmos.DrawLine(transform.position - transformedAxis, transform.position + transformedAxis);
    }
}
