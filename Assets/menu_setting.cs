using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_setting : MonoBehaviour
{
   public void play()
    {
        SceneManager.LoadScene(0);
    }
    public void help()
    {
        SceneManager.LoadScene(8);
    }    
}
