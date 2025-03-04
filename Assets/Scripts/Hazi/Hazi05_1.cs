using UnityEngine;
using System.Collections.Generic;

public class Hazi05_1 : MonoBehaviour
{
    [SerializeField] int arrayFill2Length=10;
    public int[] arrayFill2;

    [SerializeField] int arrayFill3Length = 10;
    public int[] arrayFill3;

    [SerializeField] List<int> inputList4 = new List<int> {1,2,3,4,5,6,7,8 } ;
    public List<int> outputList4;

    [SerializeField] string[] array5_1;
    [SerializeField] string[] array5_2;
    public string[] output5;

    [SerializeField] string inputStr6;
    public int output6;

    [SerializeField] int inputFibNum;
    public List<int>  outputFib;

    public int[] lotto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outputList4 = RemoveEvery2nd(inputList4);
        output5 = MergeArray(array5_1, array5_2);
        lotto = Lotto();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnValidate()
    {
        arrayFill2= ArrayFill2(arrayFill2Length);
        arrayFill3 = ArrayFill3(arrayFill3Length);
        output6 = CountDiffChar(inputStr6);
        outputFib = Fib(inputFibNum);
    }


    int[] ArrayFill2(int length)
    {
        int[] array = new int[length];
        int count = 0;
        for (int i = 1; count < length; i++)
        {
            if (i%4!=0 && i%5!=0)
            {
                array[count]= i;
                count += 1;
            }
        }
        return array;
    }

    int[] ArrayFill3(int max)
    {
        int count = 0;
        for (int i = 0; i <= max; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
               count += 1;
            }
        }

        int[] array = new int[count];
        count = 0;
        for (int i = 1; i <= max; i++)
        {
            if (i % 4 != 0 && i % 5 != 0)
            {
                array[count] = i;
                count++;
            }
        }
        return array;
    }

    List<int> RemoveEvery2nd(List<int> list)
    {
        int length = list.Count;
        List<int> temp=new List<int> { };
        for (int i = 0; i < length; i+=2)
        {
            temp.Add(list[i]);
        }
        return temp;
    }

    string[] MergeArray (string[] arr1, string[] arr2 )
    {
        int length = arr1.Length+ arr2.Length;
        string[] newarr = new string[length];
        int j=0;
        for (int i = 0; i < arr1.Length; i++)
        {
            newarr[j] = arr1[i];
            j++;
        }
        for (int i = 0; i < arr2.Length; i++)
        {
            newarr[j] = arr2[i];
            j++;
        }

        return newarr;
    }

    int CountDiffChar(string inputString)
    {
        List<char> list = new List<char> { };
        
        for (int i = 0; i < inputString.Length; i++)
        {
            if (list.Contains(inputString[i])==false)
            {
                list.Add(inputString[i]);
            }
        }
        return list.Count;
    }

    List<int> Fib(int n)
    {
        List<int> list= new List<int>{0,1};

        for (int i = 2; i < n; i++)
        {
            list.Add(list[i - 1] + list[i - 2]);
        }

        return list;
    }

    int[] Lotto() {

        int[] myFive=new int[5];
        List<int> nums = new List<int>{ };
        //int count = 0;
        for (int i = 1; i <= 90; i++)
        {
            nums.Add(i);
        }


        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(1, nums[^1]);
            nums.Remove(random);
            myFive[i] = random;
        }

        return myFive;

        
    }
}
