using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    [SerializeField] Transform Target;

    [SerializeField] float range = 5;

    void Update()
    {
        //Vector3 TargetP = Target.position;
        //Vector3 SelfP = this.transform.position;

        //Vector3 dir = (TargetP - SelfP).normalized;

        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance <range)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, Target.position, Speed * Time.deltaTime);

        }

        Vector3 dir = Target.position - transform.position;

        if (dir!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
