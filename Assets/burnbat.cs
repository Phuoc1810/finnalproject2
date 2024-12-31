using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnbat : MonoBehaviour
{
    public bool chay;
    public float cooldown;
    public float firetime;
    public int count = 0;
    public GameObject fire;
    private void Update()
    {
        burnon();
    }
    public void burnon()
    {
        if (chay && count <= 5)
        {
            fire.SetActive(true);
            cooldown += Time.deltaTime;
            if (cooldown >= firetime)
            {
                cooldown = 0;
                enemybatnoastar enemyheath;
                enemyheath = this.gameObject.GetComponent<enemybatnoastar>();
                enemyheath.takedamagefire(1);
                count++;
            }
        }
        else if (count > 5)
        {
            fire.SetActive(false);
            chay = false;
            count = 0;
        }
    }
}
