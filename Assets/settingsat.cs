using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsat : MonoBehaviour
{
    public GameObject pannel;
    public float lineOfSite = 2f;
   
    public Transform player;
    public bool check = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }
    private void Update()
    {

        float distancefromplayer = Vector2.Distance(player.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {

            if (Input.GetKeyDown(KeyCode.E) && check==false)
            {

                pannel.SetActive(true);
                Time.timeScale = 0;
                check = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && check == true)
            {
                pannel.SetActive(false);
                Time.timeScale = 1;
                check = false;
            }

        }
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
