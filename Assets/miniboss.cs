using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniboss : MonoBehaviour
{
    public float speed;
    public float lineOfSite = 2f;
    public int count = 0;
    public Transform player;
    public Rigidbody rb;
    public Animator anim;
    public float timetele=10;
    public GameObject playerposition;
    public bool move = true;

    private void Start()
    {

        playerposition = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {
            count += 1;
            if (count == 1)
            {
                lineOfSite *= 2;
            }
            anim.SetTrigger("walk");
            
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
            timetele -= Time.deltaTime;
            if (timetele <= 0)
            {
                anim.SetTrigger("tele");
                
            }
        }
        else
            anim.SetTrigger("indel");

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
    public void tele()
    {
        transform.position = playerposition.transform.position;
        timetele = 8;
    }
}
