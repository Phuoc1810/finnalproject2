using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minibossnoastar : MonoBehaviour
{
    public float maxhealth = 50;
    public float health;
    public hearbar healthbar;
    public GameObject chest_Perfab;
    public GameObject wall;

    private Animator anim;
    public Transform enemymove;
    public miniboss boss;
    public GameObject Point;

    public GameObject room;
    public GameObject lockDoor;
    public GameObject unlockDoor;
    public GameObject funtionWall;

    private void Start()
    {

        health = maxhealth;
        healthbar.sethealth(health, maxhealth);
        Point = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        chest_Perfab.SetActive(false);
        wall.SetActive(true);
    }

    public void takedamage(float damge)
    {
        

        boss = GetComponent<miniboss>();
        if (transform.localScale.x == -1f)
            enemymove.position = new Vector2(enemymove.position.x + 0.5f, enemymove.position.y);
        if (transform.localScale.x == 1f)
            enemymove.position = new Vector2(enemymove.position.x - 0.5f, enemymove.position.y);
        anim.SetTrigger("hurt");
        health -= damge;
        boss.speed = 0;
        healthbar.sethealth(health, maxhealth);

        if (health < 0)
        {
            
            anim.SetTrigger("die");
           
      

        }
        Debug.Log("takedamge");
    }
    public void takedamagefire(float damge)
    {

        anim.SetTrigger("hurt");
        if (health <= 0)
        {
            anim.SetTrigger("die");
        }

    }
    public void die()
    {
        room.SetActive(false);
        Destroy(lockDoor);
        unlockDoor.SetActive(true);
        funtionWall.SetActive(false);
       
        chest_Perfab.SetActive(true);
        wall.SetActive(false);
        Point.GetComponent<playersat>().point += 2;
        Destroy(gameObject);
    }
    public void ngangchuyendong()
    {
        boss.speed = 3;
        
    }
    
}
