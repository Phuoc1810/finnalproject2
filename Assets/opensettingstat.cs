using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class opensettingstat : MonoBehaviour
{
    public GameObject panel;
   
    public float lineOfSite = 2f;
   
    public Transform player;
    
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }
    private void Update()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                panel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                panel.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
