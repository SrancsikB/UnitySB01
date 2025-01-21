using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float angspeed;
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        direction.Normalize();

        this.transform.position += direction * speed * Time.deltaTime;
        if (direction!=Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            float angle = angspeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, angspeed);
            
        }
        
    }
}
