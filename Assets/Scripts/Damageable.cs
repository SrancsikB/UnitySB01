using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] float startHP = 100;
    [SerializeField] Behaviour disableObj;

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
            Debug.Log("Died :(");
            disableObj.enabled = false;
        }


    }
}
