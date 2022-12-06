using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCntrl : MonoBehaviour
{
    GameObject player;
    PlayerCntrl Cntrl;
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Cntrl = GameObject.FindObjectOfType<PlayerCntrl>();
    }
    private void Update()
    {
        if (n>0)
        {
            time++;
        }
        if (time>20)
        {
            n = 0;
            time = 0;
        }
    }

    int k;
    int n = 0;
    Vector3 pos;
    private void OnMouseDown()
    {
        n++;
        if (n == 1)
        {
            k = 0;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Mathf.Abs(pos.x - player.transform.position.x) > Mathf.Abs(pos.y - player.transform.position.y))
            {
                if (Mathf.Sign(pos.x - player.transform.position.x) > 0)
                {
                    Cntrl.moveRight = true;
                }
                else
                {
                    Cntrl.moveLeft = true;
                }
            }
            else
            {
                if (Mathf.Sign(pos.y - player.transform.position.y) > 0)
                {
                    Cntrl.moveUp = true;
                }
                else
                {
                    Cntrl.moveDown = true;
                }
            }
        }
        else
        {
            Vector3 pos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if ((Mathf.Pow(pos.x-pos2.x,2f)+ Mathf.Pow(pos.y - pos2.y, 2f)<=1f)&&(time<=20))
            {
                Cntrl.Tik = true;
                n = 0;
                time = 0;
            }
        }
    }

    private void OnMouseDrag()
    {
        k++;
        if (k>20)
        {
            Cntrl.Eat = true;
            k = 0;
        }
    }
}
