using System;
using TMPro;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float startHP = 100;
    [SerializeField] Behaviour disableObj;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] GameObject[] spawnOnDeath;

    public event Action HPChanged;
    public event Action Died;

    float currentHP;

    public float GetCurrentHP => currentHP;
    public float GetStartHP => startHP;

    private void Awake()
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

        HPChanged?.Invoke();

    }

 

    private void OnDeath()
    {
        if (disableObj != null)
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
        Died?.Invoke();
    }


}
