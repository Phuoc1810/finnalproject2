
using UnityEngine;
using UnityEngine.SceneManagement;

public class help_setting : MonoBehaviour
{
   public GameObject panel1;
   public GameObject panel2;
   public GameObject panel3;
    public void back1()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }
    public void back2()
    {
        panel3.SetActive(false);
        panel2.SetActive(true);
    }
    public void next1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void next2()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
