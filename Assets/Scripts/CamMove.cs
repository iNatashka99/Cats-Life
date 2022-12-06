using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private Vector3 target;
    public float distance_y, distance_x;
    public float speed;
    GameObject cat;
    bool fl1 = false;
    bool fl2 = false;
    private void Start()
    {
        cat = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!fl1 && Mathf.Abs(cat.transform.position.y - transform.position.y+1) > distance_y)
        {
            fl1 = true;
            target = new Vector3(transform.position.x, cat.transform.position.y + 1*Mathf.Sign(cat.GetComponent<Rigidbody2D>().velocity.y), transform.position.z);

        }
        if (fl1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            if (Mathf.Abs(transform.position.y- target.y) < 0.05f)
                fl1 = false;
        }
        if (!fl2 && Mathf.Abs(cat.transform.position.x - transform.position.x) > distance_x)
        {
            fl2 = true;
            target = new Vector3(cat.transform.position.x + 1*Mathf.Sign(cat.GetComponent<Rigidbody2D>().velocity.x), transform.position.y, transform.position.z);

        }
        if (fl2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            if (Mathf.Abs(transform.position.x - target.x) < 0.05f)
                fl2 = false;
        }

    }
}
