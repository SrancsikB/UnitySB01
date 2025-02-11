using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Vector3 offset;
    [SerializeField] float angspeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = TargetPosP - transform.position;

        Quaternion targetRot = Quaternion.LookRotation(dir);
        float angle = angspeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, angle);


    }

    private void OnDrawGizmos()
    {
        if (Target == null)
        {
            return;
        }

        

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(TargetPosP, Vector3.one * 0.5f);

    }

    Vector3 TargetPos()
    {
        return Target.position + Target.TransformVector(offset); //global to local
    }
    Vector3 TargetPosP => Target.position + Target.TransformVector(offset);
    

}
