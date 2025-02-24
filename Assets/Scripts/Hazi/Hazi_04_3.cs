using UnityEngine;

public class Hazi_04_3 : MonoBehaviour
{
    [SerializeField] int number;
    private void OnValidate()
    {
        int counter = 0;
        int i = 2;
        while (counter<number)
        {
            if (isPrime(i))
            {
                counter++;
                Debug.Log(i);
            }
            
            i++;
        }

       
    }


    bool isPrime(int number)
    {
        bool isPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        return isPrime;
    }
}
