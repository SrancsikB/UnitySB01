using UnityEngine;

public class ArrayTry : MonoBehaviour

    
{
    [SerializeField] int[] intArray;
    [SerializeField] int length = 10;
    [SerializeField] float avg;
    [SerializeField] string[] word;
    [SerializeField] string[] newWord;

    private void OnValidate()
    {
        avg = MyAvg(intArray);
        newWord = MyStrRev(word);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int a = 0;
        int[] intArray = new int[10];

        a = intArray[1];
        intArray[2] = 33;

        a = intArray[0];
        a = intArray[9];
        a = intArray[^1]; //Utolsó
        int length = intArray.Length; //Elemszám

        a = intArray[intArray.Length - 1]; //Utolsó

        string[] stringArray = new string[] { "AAA", "BBB", "CCC" };
        string[] stringArray2 = { "AAA", "BBB", "CCC" };


    }

    private void Awake()
    {
       intArray = new int[length];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i]= i+1;
        }

        Debug.Log(MyAvg(intArray));

    }


    float MyAvg(int[] intArray)
    {
        float temp = 0;
        for (int i = 0; i < intArray.Length; i++)
        {
            temp += intArray[i];
        }
        return temp / intArray.Length;
    }


    string[] MyStrRev(string[] word)
    {
        string[] newWord = new string[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            newWord[i] = word[^(i + 1)]; ;
        }
        return newWord;
    }


    string[] MyStrRevSet(string[] word)
    {
        string[] newWord = new string[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            newWord[length - i - 1] = word[^(i+1)];
        }
        return newWord;
    }


}
