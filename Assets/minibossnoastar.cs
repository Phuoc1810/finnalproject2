using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minibossnoastar : MonoBehaviour
{
    public float health;
    public GameObject chest_Perfab;

    private Animator anim;
    public Transform enemymove;
    public miniboss boss;
    public GameObject Point;

    private void Start()
    {
        Point = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        chest_Perfab.SetActive(false);
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
        

        if (health < 0)
        {
            anim.SetTrigger("die");
            StartCoroutine(ChestAppear());

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
        Point.GetComponent<playersat>().point += 2;
        Destroy(gameObject);
    }
    public void ngangchuyendong()
    {
        boss.speed = 3;
        
    }
    private IEnumerator ChestAppear()
    {
        yield return new WaitForSeconds(2);
        chest_Perfab.SetActive(true);
    }
}
