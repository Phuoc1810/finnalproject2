using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class playermaneger : MonoBehaviour
{
    public static playermaneger _instance;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider mpSlider;
    Canvas main;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
       


        setuphpmp();
       
    }
    public void setuphpmp()
    {
        hpSlider.maxValue = move._instance.GetComponent<playersat>().maxhp;
        mpSlider.maxValue = move._instance.GetComponent<playersat>().maxmp;
        updatehpmp();

    }
  
    public void updatehpmp()
    {
        hpSlider.value = move._instance.GetComponent<playersat>().currenthp;
        mpSlider.value = move._instance.GetComponent<playersat>().currentmp;
    }
}
