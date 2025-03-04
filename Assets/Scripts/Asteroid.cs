using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //[NonSerialized] public Vector3 velocity;

    //private void Update()
    //{
    //    transform.position += velocity * Time.deltaTime;
    //}

    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float minDamage = 10;
    [SerializeField] float maxDamage = 20;
    [SerializeField] float minDamageSpeed = 1;
    [SerializeField] float maxDamageSpeed = 10;
    [SerializeField] float minSpeed = 1;
    [SerializeField] float maxSpeed = 2;
    [SerializeField] float damageDelay = 2;

    [SerializeField] AnimationCurve speedToDamage;

    bool enableDamage = false;

    private void Start()
    {
        Vector3 direction = Random.insideUnitCircle.normalized;
        rigidBody.linearVelocity = (direction * Random.Range(minSpeed, maxSpeed));

        Invoke(nameof(EnableDamage),damageDelay);
    }

    void EnableDamage()
    {
        enabled = true;
    }

    public void SetVeloity(Vector2 v)
    {
        rigidBody.linearVelocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enableDamage) return;
        
        if (collision.collider.TryGetComponent(out Damageable d))
        {
            float s = collision.relativeVelocity.magnitude;

            float t = Mathf.InverseLerp(minDamageSpeed, maxDamageSpeed, s);
            float damage = Mathf.Lerp(minDamage, maxDamage, t);
            //float damage = speedToDamage.Evaluate(s);

            d.Damage(damage);
        }
    }

}
