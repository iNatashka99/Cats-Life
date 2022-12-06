using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomMap : MonoBehaviour
{
    public int n, del, gl, me,mi;
    public Tilemap til1, til2, til3, til4;
    public TileBase block, glass_block, meal, mint;
    Vector3Int pos;

    // Start is called before the first frame update
    void Start()
    {
        int[,] mas = new int[n, n];
        bool[,] isVisited = new bool[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                mas[i, j] = 0;
            }
        }
        for (int i = 0; i < n; i+=2)
        {
            for (int j = 0; j < n; j++)
            {
                mas[i, j] = 1;
            }
        }
        for (int i = 0; i < n; i += 2)
        {
            for (int j = 0; j < n; j++)
            {
                mas[j, i] = 1;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                isVisited[j, i] = false;
            }
        }
        isVisited[1, 1] = true;
        for (int i = 1; i < n; i+=2)
        {
            for (int j = 1; j < n; j+=2)
            {
                NextSide(i, j, mas, isVisited,n);
            }
        }

        for (int k = 0; k < del; k++)
        {
            int i = n/2;
            int j = n/2;
            while (mas[i, j] == 0)
            {
                i = Random.Range(1, n);
                j = Random.Range(1, n);
            }
            mas[i, j] = 0;
        }
        for (int k = 0; k < gl; k++)
        {
            int i = n / 2;
            int j = n / 2;
            while (mas[i, j] == 0)
            {
                i = Random.Range(1, n);
                j = Random.Range(1, n);
            }
            mas[i, j] = 2;
        }
        for (int k = 0; k < me; k++)
        {
            int i = n / 2;
            int j = n / 2;
            while (mas[i, j] != 0)
            {
                i = Random.Range(1, n);
                j = Random.Range(1, n);
            }
            mas[i, j] = 3;
        }
        for (int k = 0; k < mi; k++)
        {
            int i = n / 2;
            int j = n / 2;
            while (mas[i, j] != 0)
            {
                i = Random.Range(1, n);
                j = Random.Range(1, n);
            }
            mas[i, j] = 4;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mas[i,j]==1)
                {
                    pos = new Vector3Int(-n / 2 + i, -n / 2 + j, 0);
                    til1.SetTile(pos, block);
                }
                if (mas[i, j] == 2)
                {
                    pos = new Vector3Int(-n / 2 + i, -n / 2 + j, 0);
                    til2.SetTile(pos, glass_block);
                }
                if (mas[i, j] == 3)
                {
                    pos = new Vector3Int(-n / 2 + i, -n / 2 + j, 0);
                    til3.SetTile(pos, meal);
                }
                if (mas[i, j] == 4)
                {
                    pos = new Vector3Int(-n / 2 + i, -n / 2 + j, 0);
                    til4.SetTile(pos, mint);
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            pos = new Vector3Int(-n / 2 + i, n / 2 , 0);
            til1.SetTile(pos, block);
        }
        for (int i = 0; i < n+1; i++)
        {
            pos = new Vector3Int(n / 2 , -n / 2+i, 0);
            til1.SetTile(pos, block);
        }
    }

    public void NextSide(int i, int j, int[,] mas, bool[,] isVisited,int n)
    {
        Vector2Int x = new Vector2Int(0, 0);
        isVisited[i, j] = true;
        bool fl = false;
        string str = "";
        if ((i-2>=0)&&(!isVisited[i-2,j]))
        {
            str += 1;
            fl = true;
        }
        else if ((i + 2 < n)&& (!isVisited[i + 2, j]))
        {
            str += 2;
            fl = true;
        }
        if ((j - 2 >= 0) && (!isVisited[i, j - 2]))
        {
            str += 3;
            fl = true;
        }
        else if ((j + 2 < n) && (!isVisited[i, j + 2]))
        {
            str += 4;
            fl = true;
        }
        if (fl)
        {
                char r = str[Random.Range(0, str.Length)];
                if (r == '1')
                {
                    x = new Vector2Int(i - 2, j);
                }
                else if (r == '4')
                {
                    x = new Vector2Int(i, j + 2);
                }
                else if (r == '2')
                {
                    x = new Vector2Int(i + 2, j);
                }
                else if (r == '3')
                {
                    x = new Vector2Int(i, j - 2);
                }
            mas[Mathf.Abs(x.x + i) / 2, Mathf.Abs(x.y + j) / 2] = 0;
            NextSide(x.x, x.y, mas, isVisited, n);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
