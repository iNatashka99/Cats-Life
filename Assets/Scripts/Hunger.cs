using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public int time;
    int k=10;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        k = 0;
        string str = gameObject.GetComponent<Text>().text;
        for (int i = 0; i < str.Length; i++)
            if (str[i] == '█')
                k++;
        if (k <= 3)
            gameObject.GetComponent<Text>().color = Color.red;
        else if (k <= 6)
            gameObject.GetComponent<Text>().color = Color.yellow;
        else
            gameObject.GetComponent<Text>().color = Color.green;
        time++;
        if (time>100)
        {
            time = 0;
            if (k>0)
                k--;
            if (k == 0)
            {
                GameObject.FindObjectOfType<Lifes>().fl = -1;
                k = 10;
            }
            str = "";
            for (int i = 0; i < k; i++)
                str += "█ ";
            gameObject.GetComponent<Text>().text = str;
        }
        
    }
}
