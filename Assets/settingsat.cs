using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsat : MonoBehaviour
{
    public GameObject pannel;
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

                pannel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                pannel.SetActive(false);
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
