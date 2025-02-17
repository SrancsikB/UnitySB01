using UnityEngine;

public class Hazi_03_5 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 startPos; //NOK if transform
    [SerializeField] Transform startPosT;
    [SerializeField] float distance;
    [SerializeField] int number;
    [SerializeField] bool isPrime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosT.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 movement = (target.position - startPosT.position).normalized * distance;
        Vector3 movement = (target.position - startPosT.position);
        //transform.position = startPos + movement;
        transform.position = Vector3.ClampMagnitude(startPosT.position, distance);
    }


    private void OnValidate()
    {
        isPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
    }
}
