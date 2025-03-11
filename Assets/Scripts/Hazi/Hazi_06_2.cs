using UnityEngine;

public class Hazi_06_2 : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] float bombArea = 10;
    [SerializeField] float bombForce = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float Timer = Random.RandomRange(2, 5);
        Invoke("Bomb", Timer);
    }

    
    void Bomb()
    {
        
        foreach (GameObject item in objects)
        {
            //float distance = Vector3.Magnitude(transform.position- item.transform.position);
            //Mathf.Lerp(0, bombArea, distance);
            item.GetComponent<Rigidbody>().AddExplosionForce(bombForce, transform.position, bombArea);
            

        }
        Destroy(gameObject);
    }
}
