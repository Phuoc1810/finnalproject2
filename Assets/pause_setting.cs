using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_setting : MonoBehaviour
{
   public GameObject pannelpause;
    public GameObject pannelsetting;
    public bool check = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&check==false)
        {
            pannelpause.SetActive(true);
            Time.timeScale = 0;
            check = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && check == true)
        {
            pannelpause.SetActive(false);
            Time.timeScale = 1;
            check = false;
        }
    }
    public void resume()
    {
        pannelpause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        pannelpause.SetActive(false);
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
    public void setting()
    {
        pannelpause.SetActive(false);
        pannelsetting.SetActive(true);
    }
    public void exit()
    {
        pannelsetting.SetActive(false);
        pannelpause.SetActive(true);
    }
}
