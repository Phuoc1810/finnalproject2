using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public GameObject pannelwin;
    public void backtomenu()
    {
        Time.timeScale = 1;
        pannelwin.SetActive(false);
        SceneManager.LoadScene(7);
        Time.timeScale = 1;
    }
}
