using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject m_on, m_off;

    private void Start()
    {
        if (gameObject.name == "music")
            if (PlayerPrefs.GetString("music") == "no")
            {
                m_off.SetActive(true);
                m_on.SetActive(false);
            }
            else
            {
                m_off.SetActive(false);
                m_on.SetActive(true);
            }
    }

    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "play":
                Application.LoadLevel("Play");
                break;
            case "follow":
                Application.OpenURL("https://github.com/iNatashka99");
                break;
            case "help":
                //Application.LoadLevel("Help");
                break;
            case "close":
                Application.LoadLevel("OpenScene");
                break;
            case "music":
                if (PlayerPrefs.GetString("music") != "no")
                {
                    PlayerPrefs.SetString("music", "no");
                    m_off.SetActive(true);
                    m_on.SetActive(false);
                }
                else
                {
                    PlayerPrefs.SetString("music", "yes");
                    m_off.SetActive(false);
                    m_on.SetActive(true);
                }
                break;
        }
        //if (PlayerPrefs.GetString("music") != "no")
            //GameObject.Find("SoundClick").GetComponent<AudioSource>().Play();

    }
}