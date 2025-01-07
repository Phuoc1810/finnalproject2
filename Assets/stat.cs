using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stat : MonoBehaviour
{
    public GameObject pannel;
    public GameObject ss;
    public settingsat _instan;
    public float lineOfSite = 2f;

    public Transform stats;
    public bool check = false;
    public int count = 0;
    private void Start()
    {


        stats = GameObject.FindGameObjectWithTag("stat").transform;



    }
    private void Update()
    {

       
        float distancefromplayer = Vector2.Distance(stats.position, transform.position);
        if (distancefromplayer < lineOfSite)
        {

            if (Input.GetKeyDown(KeyCode.E) && check == false)
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
