using UnityEngine;

public class Hazi03_4 : MonoBehaviour
{
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] float speed = 1;

    // Update is called once per frame
    void Update()
    {
        float dist1 = Vector3.Distance(transform.position, target1.position);
        float dist2 = Vector3.Distance(transform.position, target2.position);
        Vector3 target;
        if (dist1 > dist2) target = target2.position;
        else target = target1.position;

        transform.position= Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
