using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float duration = 3;

    float age;

    Vector3 velocity;
    public void SetStartVelocity(Vector3 startVelocity)
    {
        velocity = startVelocity + transform.up * speed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroy(gameObject, duration);//Ez is jó
        //Invoke("DestroySelf", duration); //Példa Invoke-ra
        //Invoke(nameof(DestroySelf), duration); //Példa invokra nameof-fal
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        age += Time.deltaTime;

        Color newC = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(newC.r, newC.g, newC.b, 1 - (age / duration));  //Elhalvanyul...
        transform.Rotate(0, 0, -180 * Time.deltaTime);

        if (age >= duration)
        {
            Destroy(gameObject);
        }
    }


}
