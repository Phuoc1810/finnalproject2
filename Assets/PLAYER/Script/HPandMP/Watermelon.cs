using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watermelon : MonoBehaviour
{

    public static Watermelon instance;

    [Header("Watermelon setting")]
    public int maxWatermelon = 5; //chua toi da 5 mieng dua hau
    public int currentWatermelon = 0; //so luong dua hau hien tai
    public int healAmount = 20; //luong mau hoi phuc

    [Header("UI Elements")]
    public Text watermelonCountText; //text hien thi so luong dua hau

    private playersat playerStats; //tham chieu den chi so player

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerStats = FindObjectOfType<playersat>(); //lay sprite playersat

        //Cap nhat UI
        UpdateUI();
    }
    //tang so luong dua hau neu hhan duoc
    public void AddWatermelon()
    {
        if(currentWatermelon < maxWatermelon)
        {
            currentWatermelon++;
            UpdateUI();
            Debug.Log("Da nhan vat pham dua hau");
        }
        else
        {
            Debug.Log("Da dat gioi han dua hau");
        }
    }

    public void UseWatermelon()
    {
        if(currentWatermelon > 0 && playerStats.currenthp < playerStats.maxhp)
        {
            currentWatermelon--;
            playerStats.currenthp += healAmount;

            //dam bao mau khong vuot qua max hp
            if(playerStats.currenthp > playerStats.maxhp)
            {
                playerStats.currenthp = playerStats.maxhp;
            }

            Debug.Log("Da su dung 1 watermelon");
            UpdateUI();
        }
        else if(currentWatermelon == 0)
        {
            Debug.Log("Khong con dua hau de su dung");
        }
        else if(playerStats.currenthp >= playerStats.maxhp)
        {
            Debug.Log("Mau da day, khong can su dung");
        }
    }
    public void UpdateUI()
    {
        //cap nhat so luong dua hau tren UI
        if(watermelonCountText != null)
        {
            watermelonCountText.text = currentWatermelon.ToString();
        }
    }
}