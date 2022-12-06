using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    Hunger hung;
    public int fl = 0;
    // Start is called before the first frame update
    void Start()
    {
        hung = GameObject.FindObjectOfType<Hunger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fl!=0)
        {
            int k = 0;
            string str = gameObject.GetComponent<Text>().text;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == '❤')
                    k++;
            if ((k > 0)&&(k+fl<=7))
                k+=fl;
            str = "";
            for (int i = 0; i < k; i++)
                str += "❤";
            gameObject.GetComponent<Text>().text = str;
            if (k==0)
            {
                Application.LoadLevel("OpenScene");
            }
            fl = 0;
        }
    }
}
