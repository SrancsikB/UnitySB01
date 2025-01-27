using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    [SerializeField] Transform Target;

    void Update()
    {
        //Vector3 TargetP = Target.position;
        //Vector3 SelfP = this.transform.position;

        //Vector3 dir = (TargetP - SelfP).normalized;

        this.transform.position = Vector3.MoveTowards(this.transform.position, Target.position, Speed * Time.deltaTime);

        Vector3 dir = Target.position - transform.position;

        if (dir!=Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
        
    }
}
