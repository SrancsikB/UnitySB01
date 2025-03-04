using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float startHP = 100;
    [SerializeField] Behaviour disableObj;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] GameObject[] spawnOnDeath;

    float currentHP;

    private void Start()
    {
        currentHP = startHP;
    }

    public void Damage(float damage)
    {
        if (currentHP <= 0)
            return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
        }


        if (currentHP <= 0)
        {
            OnDeath();
        }


    }

    private void OnDeath()
    {
        if (disableObj!=null)
        {
            disableObj.enabled = false;
        }
        
        if (destroyOnDeath)
        {
            Destroy(gameObject);
        }

        foreach (GameObject item in spawnOnDeath)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
    }
}
