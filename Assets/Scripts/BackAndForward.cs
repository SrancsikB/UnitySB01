using Unity.VisualScripting;
using UnityEngine;

enum MovementType {Freq,Speed }

public class BackAndForward : MonoBehaviour
{
    //[SerializeField] float Speed = 1.5f;
    [SerializeField] Vector3 P1, P2;
    [SerializeField] Transform T1, T2;
    [SerializeField] float movement=2;
    [SerializeField] MovementType movementType;

    Vector3 CurrentTarget;

    private void Start()
    {
        transform.position = P1;
        CurrentTarget = P2;
    }

    void Update()
    {
        float Speed;
        if (movementType == MovementType.Freq)
        {
            float MoveTime = 1 / movement;
            float Distance = Vector3.Distance(P1, P2);
            Speed = Distance / MoveTime;
        }
        else
            Speed = movement;



        this.transform.position = Vector3.MoveTowards(this.transform.position, CurrentTarget, Speed * Time.deltaTime);

        if (transform.position == P2)
        {
            CurrentTarget = P1;
        }
        if (transform.position == P1)
        {
            CurrentTarget = P2;
        }
    }

    private void OnDrawGizmos()
    {
        if (T1 == null || T2 == null)
        {
            return;
        }
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(P1, 0.25f);
        Gizmos.DrawWireSphere(P2, 0.25f);
        Gizmos.DrawLine(P1, P2);
    }
}
