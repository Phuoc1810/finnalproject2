using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    public float speed;
    public float lineOfSite=2f;
    public int count=0;
    public Transform player;
    public Rigidbody rb;
    public Animator anim;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        Vector2 target = new Vector2(player.position.x - 0.7f, player.position.y);
        
        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {
            count += 1;
            if (count == 1)
            {
                lineOfSite *= 2;
            }
            anim.SetTrigger("WALK");
            transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
        else
            anim.SetTrigger("INDEL");
      
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
