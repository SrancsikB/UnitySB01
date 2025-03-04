using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damage=10;
    [SerializeField] bool destroyOnDamage;

    void OnTriggerEnter(Collider other)
    {
        TryDamage(other);
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        TryDamage(other);
    }


    private void TryDamage(Component other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.Damage(damage);
            if (destroyOnDamage)
            {
                Destroy(gameObject);
            }
        }
    }

}
