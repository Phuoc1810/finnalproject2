using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shottingnoastar : MonoBehaviour
{
    public float maxhealth = 30;
    public float health;
    public hearbar healthbar;


    private Animator anim;
    public Transform enemymove;

    public SHOOTINGPLAYER enemy;
    public GameObject Point;

    public GameObject chest_Perfab;
    private void Start()
    {
        health = maxhealth;
        healthbar.sethealth(health, maxhealth);
        Point = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        chest_Perfab.SetActive(false);
    }

    public void takedamage(float damge)
    {
        enemy = GetComponent<SHOOTINGPLAYER>();


        if (transform.localScale.x == -1f)
            enemymove.position = new Vector2(enemymove.position.x + 0.5f, enemymove.position.y);
        if (transform.localScale.x == 1f)
            enemymove.position = new Vector2(enemymove.position.x - 0.5f, enemymove.position.y);
        anim.SetTrigger("hurt");
        health -= damge;
        healthbar.sethealth(health, maxhealth);
        enemy.speed = 0;

        if (health < 0)
        {
            anim.SetTrigger("die");
            chest_Perfab.SetActive(true);
        }
        Debug.Log("takedamge");
    }
    public void takedamagefire(float damge)
    {

        anim.SetTrigger("hurt");
        health -= damge;
        if (health <= 0)
        {


            anim.SetTrigger("die");


        }

    }
    public void die()
    {
        Point.GetComponent<playersat>().point += 1f;
        Destroy(gameObject);
    }
    public void ngangchuyendong()
    {

        enemy.speed = 2;
    }
}