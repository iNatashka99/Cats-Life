using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class isTrigIce : MonoBehaviour
{
    public bool fl = false;
    Vector3Int pos;
    // Start is called before the first frame update
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
            if (t > 50)
            {
                gameObject.GetComponent<Tilemap>().SetTile(pos, null);
                float x = 0;
                float y = 0;
                if (GameObject.FindObjectOfType<PlayerCntrl>().velo.x!=0)
                    x = Mathf.Sign(GameObject.FindObjectOfType<PlayerCntrl>().velo.x);
                if (GameObject.FindObjectOfType<PlayerCntrl>().velo.y != 0)
                    y = Mathf.Sign(GameObject.FindObjectOfType<PlayerCntrl>().velo.y);
                Vector3Int pos1 = pos + new Vector3Int(1*(int)x, 1 * (int)y, 0);
                gameObject.GetComponent<Tilemap>().SetTile(pos1, null);

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
                            gameObject.GetComponent<Tilemap>().SetTile(p, GameObject.FindObjectOfType<RandomMap>().glass_block);
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
