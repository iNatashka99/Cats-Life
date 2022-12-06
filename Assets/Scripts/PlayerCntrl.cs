using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCntrl : MonoBehaviour
{
    public bool moveLeft, moveRight, moveUp, moveDown, Eat, Tik;
    public float vel;
    Rigidbody2D rb;
    Animator Anim;
    bool faceLeft = true;
    public Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        velo = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velo;
        if (Input.GetKeyDown(KeyCode.A)||moveLeft)
        {
            velo = new Vector2(-vel, 0);
            Anim.SetInteger("rot", 3);
            if (!faceLeft)
            {
                faceLeft = !faceLeft;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
            moveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D)|| moveRight)
        {
            velo = new Vector2(vel, 0);
            Anim.SetInteger("rot", 3);
            if (faceLeft)
            {
                faceLeft = !faceLeft;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
            }
            moveRight = false;
        }
        if (Input.GetKeyDown(KeyCode.W)||moveUp)
        {
            velo = new Vector2(0, vel);
            Anim.SetInteger("rot", 2);
            moveUp = false;
        }
        if (Input.GetKeyDown(KeyCode.S)||moveDown)
        {
            velo = new Vector2(0, -vel);
            Anim.SetInteger("rot", 1);
            moveDown = false;
        }
        if(GameObject.FindObjectOfType<isTrigIce>().fl == false)
        {
            Anim.SetInteger("tik", 0);
        }
        if ((GameObject.FindObjectOfType<EatFish>().fl == false)&&(GameObject.FindObjectOfType<Mint>().fl == false))
        {
            Anim.SetInteger("am", 0);
        }
        if ((GameObject.FindObjectOfType<Mint>().fl == false)&& (!GameObject.FindObjectOfType<Mint>().isMint))
        {
            Anim.SetInteger("am", 0);
            Anim.SetInteger("crazy", 0);
        }
        if (Input.GetKeyDown(KeyCode.F)|| Tik)
        {
            Anim.SetInteger("tik", 1);
            GameObject.FindObjectOfType<isTrigIce>().fl = true;
            Tik = false;
        }
        if (Input.GetKeyDown(KeyCode.E)|| Eat)
        {
            Anim.SetInteger("am", 1);
            GameObject.FindObjectOfType<Mint>().fl = true;
            GameObject.FindObjectOfType<EatFish>().fl = true;
            Eat = false;
        }
        if (GameObject.FindObjectOfType<Mint>().isMint)
        {
            Anim.SetInteger("crazy", 1);
            GameObject.FindObjectOfType<Mint>().isMint = false;
        }
        if (GameObject.FindObjectOfType<EatFish>().isFish)
        {
            GameObject.FindObjectOfType<EatFish>().isFish = false;
        }
    }

}
