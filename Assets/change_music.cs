using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_music : MonoBehaviour
{
    public GameObject music1;
    public GameObject music2;
    public GameObject music3;
    public GameObject musicboss;
    public GameObject musicfinalboss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Door"))
        {
            music1.SetActive(false);
            music2.SetActive(true);
        }
       else if(collision.CompareTag("cave"))
        {
            music2.SetActive(false);
            music3.SetActive(true);
        }
        else if (collision.CompareTag("room"))
        {
            music3.SetActive(false);
            musicboss.SetActive(true);
        }
        else if (collision.CompareTag("bosschest"))
        {
            musicboss.SetActive(false);
            music3.SetActive(true);
        }
        else if (collision.CompareTag("finaldoor"))
        {
            musicboss.SetActive(false);
            musicfinalboss.SetActive(true);
        }
    }
}
