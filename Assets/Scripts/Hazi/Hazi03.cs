using UnityEngine;

public class Hazi03 : MonoBehaviour
{

    //1
    [SerializeField] float gizmoLength = 1;



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 transformedAxis;
        Vector3 AxisX = Vector3.right * gizmoLength;
        Vector3 AxisY = Vector3.up * gizmoLength;
        Vector3 AxisZ = Vector3.forward * gizmoLength;


        transformedAxis = transform.TransformVector(AxisX); //global to local
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position - transformedAxis, transform.position + transformedAxis);
        Gizmos.DrawSphere(transform.position + transformedAxis, 0.05f);

        transformedAxis = transform.TransformVector(AxisY); //global to local
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position - transformedAxis, transform.position + transformedAxis);
        Gizmos.DrawSphere(transform.position + transformedAxis, 0.05f);

        transformedAxis = transform.TransformVector(AxisZ); //global to local
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position - transformedAxis, transform.position + transformedAxis);
        Gizmos.DrawSphere(transform.position + transformedAxis, 0.05f);
    }



    //2
    [SerializeField] Vector2 p1, p2;
    [SerializeField] float distance;
    [SerializeField] Vector2 myVector;
    private void OnValidate()
    {
        distance = Vector2.Distance(p1, p2);
        distance = Mathf.CeilToInt(distance);
        myVector = (p2 - p1) / distance;

    }



    [SerializeField] GameObject GO_Step;
    [SerializeField] float speed = 1;
    Vector3 target;

    private void Start()
    {
        target = GO_Step.transform.position;
    }

    //
    private void Update()
    {


        //if (GO_Step.transform.position == target)
        //{
            if (Input.GetKeyDown(KeyCode.RightArrow)) target = GO_Step.transform.position + Vector3.right;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) target = GO_Step.transform.position - Vector3.right;
            if (Input.GetKeyDown(KeyCode.UpArrow)) target = GO_Step.transform.position + Vector3.forward;
            if (Input.GetKeyDown(KeyCode.DownArrow)) target = GO_Step.transform.position - Vector3.forward;
        //}
        GO_Step.transform.position = Vector3.MoveTowards(GO_Step.transform.position, target, speed * Time.deltaTime);
    }

}
