using System.Collections.Generic;
using UnityEngine;

public class Hazi02 : MonoBehaviour


{

    [SerializeField] int LoadedAmmo = 4;
    [SerializeField] int NumOfMag = 2;
    [SerializeField] int AmmoPerMag = 6;

    [SerializeField] float MinMaxP1 = 1.2f;
    [SerializeField] float MinMaxP2 = 2.3f;

    [SerializeField] float Pit1 = 3f;
    [SerializeField] float Pit2 = 5f;
    [SerializeField] float Pit3 = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (LoadedAmmo > 0)
            {
                Debug.Log("Bang!");
                LoadedAmmo--;
            }
            else
            {
                if (NumOfMag > 0)
                {
                    Debug.Log("Klikk!");
                    LoadedAmmo = AmmoPerMag;
                    NumOfMag--;
                }
                else
                {
                    Debug.Log("Empty! :(");
                }
            }

            Debug.Log("---------");
            Debug.Log("LoadedAmmo: " + LoadedAmmo);
            Debug.Log("NumOfMag: " + NumOfMag);
        }



        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 || i % 7 == 0)
                {
                    Debug.Log(i);
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            int counter = 100;
            int i = 0;
            while (counter > 0)
            {
                i++;
                if (i % 3 == 0 || i % 7 == 0)
                {
                    counter--;
                    Debug.Log(i);
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log("Min: " + MyMin(MinMaxP1, MinMaxP2));
            Debug.Log("Max: " + MyMax(MinMaxP1, MinMaxP2));
        }

        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Debug.Log("Floor: " + MyFloor(MinMaxP1));
            Debug.Log("Ceiling: " + MyCeiling(MinMaxP1));
            Debug.Log("Round: " + MyRound(MinMaxP1));
        }

        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            List    <float> list = new List<float>();
            list.Add(Pit1);
            list.Add(Pit2);
            list.Add(Pit3);
            float a = Mathf.Min(Pit1, Mathf.Min(Pit2, Pit3));
            float c = Mathf.Max(Pit1, Mathf.Max(Pit2, Pit3));

            list.Remove(a);
            list.Remove(c);
            float b = list[0];

            if (Mathf.Pow(a, 2) + Mathf.Pow(b, 2) == Mathf.Pow(c, 2))
            {
                Debug.Log("Ez az! :)");
            }
            else
            {
                Debug.Log("Ez nem az! :(");
            }
        }
    }


    float MyMin(float p1, float p2)
    {
        if (p1 > p2)
        {
            return p2;
        }
        else
        {
            return p1;
        }

    }

    float MyMax(float p1, float p2)
    {
        if (p1 < p2)
        {
            return p2;
        }
        else
        {
            return p1;
        }

    }

    float MyFloor(float p1)
    {
        int i1 = (int)p1;
        return i1;
    }

    float MyCeiling(float p1)
    {
        int i1 = (int)p1;
        return i1+1;
        //Ez hibás, ha egész a szám
    }

    float MyRound(float p1)
    {
        if (p1 % 1 >= 0.5f)
        {
            return MyCeiling(p1);
        }
        else
        {
            return MyFloor(p1);
        }
        
    }
}
