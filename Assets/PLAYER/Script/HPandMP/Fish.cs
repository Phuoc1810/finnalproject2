using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    public static Fish instance;

    [Header("Fish setting")]
    public int maxFish = 5; //chua toi da 5 con ca
    public int currentFish = 0; //so luong ca hien tai
    public int manaAmount = 20; //luong mana hoi phuc

    [Header("UI Elements")]
    public Text fishCountText; //text hien thi so luong ca
    private playersat playerStats; //tham chieu den chi so player

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<playersat>(); //lau sprite palyerstat

        //cap nhta UI
        UpdataUI();
    }
    public void AddFish()
    {
        if(currentFish < maxFish)
        {
            currentFish++;
            UpdataUI();
        }
        else
        {
            Debug.Log("Da dat gioi han dua hau");
        }
    }
    public void UseFish()
    {
        if (currentFish > 0 && playerStats.currentmp < playerStats.maxmp) ;
        {
            currentFish--;
            playerStats.currentmp += manaAmount;

            //dam bao mana khon vuot qua max mana
            if(playerStats.currentmp > playerStats.maxmp)
            {
                playerStats.currentmp = playerStats.maxmp;
            }
            UpdataUI();
        }
    }
    public void UpdataUI()
    {
        if(fishCountText != null)
        {
            fishCountText.text = currentFish.ToString();
        }
    }
}
