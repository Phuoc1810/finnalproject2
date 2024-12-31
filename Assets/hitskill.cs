using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hitskill : MonoBehaviour
{
    public playersat damge;
    public int phantram;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("miniboss"))
        {
           
            phantram = Random.Range(1, 10);
            burnminiboss burnfire;
            burnfire = collision.gameObject.GetComponent<burnminiboss>();
            minibossnoastar minibossheath;
            minibossheath = collision.gameObject.GetComponent<minibossnoastar>();
            minibossheath.takedamage(damge.skill);
            if (phantram == 1 || phantram == 2 || phantram == 3 || phantram == 4)
                burnfire.chay = true;
        }
        if (collision.CompareTag("enemy2"))
        {
            phantram = Random.Range(1, 10);
            burn burnfire;
            burnfire = collision.gameObject.GetComponent<burn>();
            enemynoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<enemynoastar>();
            enemyheath.takedamage(damge.skill);
            if (phantram == 1 || phantram == 2 || phantram == 3 || phantram == 4)
                burnfire.chay = true;
        }
        if (collision.CompareTag("bat"))
        {
            phantram = Random.Range(1, 10);
            burnbat burnfire;
            burnfire = collision.gameObject.GetComponent<burnbat>();
            enemybatnoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<enemybatnoastar>();
            enemyheath.takedamage(damge.skill);
            if (phantram == 1 || phantram == 2 || phantram == 3 || phantram == 4)
                burnfire.chay = true;
        }
        if (collision.CompareTag("worn"))
        {
            
            shottingnoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<shottingnoastar>();
            enemyheath.takedamage(damge.skill);
            
        }
        //tan cong boss 
        if (collision.CompareTag("Boss"))
        {
            BossController boss = collision.GetComponent<BossController>();
            if (boss != null)
            {
                boss.TakeDamage(); //Goi ham take damage
            }
        }
    }
}
