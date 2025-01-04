using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_setting : MonoBehaviour
{
    GameObject player;
    public int count = 0;
   public void play()
    {
        SceneManager.LoadScene(0);
        count++;
        if(count>=1)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector2(12.18f, 6.7f);
        }

    }
    public void help()
    {
        SceneManager.LoadScene(8);
    }    
}
