using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playersat : MonoBehaviour
{
    [Header("stat")]
    public float point = 2;
    public float maxhp = 100;
    public float currenthp = 100;

    public float maxmp = 100;
    public float currentmp = 100;

    public float defent = 5;
    public float attack = 2;
    public float skill = 2;
    [Header("lever")]
    public int level = 1;

    public float currentexp = 0;
    public float[] nextexp;
    // tg hoi phuc mana va hp
    public float hprecoverytime = 5f;
    public float mprecoverytime = 1f;
    public Animator anim;

    [Header("STAT")]
    public Image hpstat;
    public Image mpstat;
    public Image atkstat;
    public Image defstat;
    public Image skillstat;
    public TextMeshProUGUI pointstat;

    void Start()
    {
        anim = GetComponent<Animator>();
        nextexp = new float[10];
        nextexp[0] = 100;
        for (int i = 1; i < 10; i++)
        {
            nextexp[i] = Mathf.Floor(nextexp[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointstat.text = point.ToString();
        hpstat.fillAmount = maxhp / 1000;
        mpstat.fillAmount = maxmp / 1000;
        defstat.fillAmount = defent / 25;
        atkstat.fillAmount = attack / 10;
        skillstat.fillAmount = skill / 10;
        if (currenthp < maxhp)
        {
            hprecoverytime -= Time.deltaTime;
            if (hprecoverytime <= 0)
            {
                currenthp += 1;
                hprecoverytime = 5f;
            }
        }
        if (currentmp < maxmp)
        {
            mprecoverytime -= Time.deltaTime;
            if (mprecoverytime <= 0)
            {
                currentmp += 1;
                mprecoverytime = 1f;
            }
        }

    }
    void levelup()
    {
        level++;
        currentexp = 0;
        maxhp += 50;
        currenthp = maxhp;
        maxmp += 50;
        currentmp = maxmp;
        defent += 5;
        attack += 5;

    }
    public void expcong(int exp)
    {
        currentexp += exp;
        if (currentexp >= nextexp[level - 1])
        {
            levelup();
        }
    }
    public void hurtss()
    {
        anim.SetTrigger("hurt");
        var firedamge = 20;
        var playerdef = player._instance.GetComponent<playersat>().defent;//chi so phong thu cua player
        var damage = firedamge - playerdef;//can bang game
        if (damage < 0) damage = 0;
        player._instance.GetComponent<playersat>().currenthp -= damage;

    }
    public void uphp()
    {
        if (point >= 1 && maxhp < 1000)
        {
            maxhp += 100;
            point -= 1;
            currenthp = maxhp;
        }
    }
    public void upmp()
    {
        if (point >= 1 && maxmp < 1000)
        {
            maxmp += 100;
            point -= 1;
            currentmp = maxmp;
        }
    }
    public void upatk()
    {
        if (point >= 1 && attack < 10)
        {
            attack += 1;
            point -= 1;

        }
    }
    public void updef()
    {
        if (point >= 1 && defent < 25)
        {
            defent += 5;
            point -= 1;

        }
    }
    public void upskill()
    {
        if (point >= 1 && skill < 10)
        {
            skill += 1;
            point -= 1;

        }
    }
    public void downhp()
    {
        if (maxhp > 100)
        {
            maxhp -= 100;
            point += 1;
            currenthp = maxhp;
        }
    }
    public void downmp()
    {
        if (maxmp > 100)
        {
            maxmp -= 100;
            point += 1;
            currentmp = maxmp;
        }
    }
    public void downatk()
    {
        if (attack > 2)
        {
            attack -= 1;
            point += 1;

        }
    }
    public void downskill()
    {
        if (skill > 2)
        {
            skill -= 1;
            point += 1;

        }
    }
    public void downdef()
    {
        if (defent > 5)
        {
            defent -= 5;
            point += 1;

        }
    }
    public void uppoint()
    {
        point += 1;
    }

}
