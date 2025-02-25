using System.Collections.Generic;
using UnityEngine;

public class ListTry : MonoBehaviour
{
    void Start()
    {
        List<int> intList = new();
        for (int i = 0; i < 100; i++)
        {
            intList.Add(i + 1);
        }

        for (int i = 0; i < intList.Count; i+=2)
        {
            intList.RemoveAt(i);
        }

        List<string> strings = new() { "AAA", "BBB", "CCC" };
        strings.Remove("BBB");
        strings[0] = "XXX";
    }


}
