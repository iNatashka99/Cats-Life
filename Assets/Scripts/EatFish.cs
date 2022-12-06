using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class EatFish : MonoBehaviour
{
    public Text text;
    public bool fl = false;
    public bool isFish = false;
    Vector3Int pos;
    // Start is called before the first frame update
    private void Start()
    {
        string str= "";
        for (int i = 0; i < 10; i++)
            str += "█ ";
        text.text = str;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pos = gameObject.GetComponent<Tilemap>().WorldToCell(collision.transform.position);
    }

    int t;
    private void Update()
    {
        if (fl)
        {
            t++;
            if (t > 30)
            {
                gameObject.GetComponent<Tilemap>().SetTile(pos, null);
                float x = 0;
                float y = 0;
                if (GameObject.FindObjectOfType<PlayerCntrl>().velo.x != 0)
                    x = Mathf.Sign(GameObject.FindObjectOfType<PlayerCntrl>().velo.x);
                if (GameObject.FindObjectOfType<PlayerCntrl>().velo.y != 0)
                    y = Mathf.Sign(GameObject.FindObjectOfType<PlayerCntrl>().velo.y);
                Vector3Int pos1 = pos + new Vector3Int(1 * (int)x, 1 * (int)y, 0);
                if (gameObject.GetComponent<Tilemap>().GetTile(pos1) != null)
                {
                    gameObject.GetComponent<Tilemap>().SetTile(pos1, null);
                    isFish = true;
                    int n = GameObject.FindObjectOfType<RandomMap>().n;
                    int[,] mas = new int[n + 1, n + 1];
                    for (int i = -n / 2; i < n / 2 + 1; i++)
                    {
                        for (int j = -n / 2; j < n / 2 + 1; j++)
                        {
                            Vector3Int p = new Vector3Int(i, j, 0);
                            if (gameObject.GetComponent<Tilemap>().GetTile(p) != null)
                                mas[i + n / 2, j + n / 2] = 1;
                            else
                                mas[i + n / 2, j + n / 2] = 0;
                        }
                    }
                    gameObject.GetComponent<Tilemap>().ClearAllTiles();
                    for (int i = -n / 2; i < n / 2 + 1; i++)
                    {
                        for (int j = -n / 2; j < n / 2 + 1; j++)
                        {
                            Vector3Int p = new Vector3Int(i, j, 0);
                            if (mas[i + n / 2, j + n / 2] == 1)
                                gameObject.GetComponent<Tilemap>().SetTile(p, GameObject.FindObjectOfType<RandomMap>().meal);
                        }
                    }
                    int k = 0;
                    GameObject.FindObjectOfType<Hunger>().time = 0;
                    string str = text.text;
                    for (int i = 0; i < str.Length; i++)
                        if (str[i] == '█')
                            k++;
                    if (k < 10)
                    {
                        str = "";
                        for (int i = 0; i < k + 1; i++)
                            str += "█ ";
                        text.text = str;
                    }
                }
                fl = false;
            }

        }
        else
        {
            t = 0;
        }
    }
}
