
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPSTAT : MonoBehaviour
{
    public Image hp;
    

    private void Start()
    {
       var hpplayer =player._instance.GetComponent<playersat>().maxhp;
        hp.fillAmount = hpplayer / 1000;
    }
}
