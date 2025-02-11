using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float angspeed;

    [SerializeField] Transform CameraTransform;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(h, 0, v);
        Vector3 direction = v * CameraTransform.forward + h * CameraTransform.right;
        direction.y = 0;
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
