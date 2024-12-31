using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public playersat damge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("miniboss"))
        {
            minibossnoastar minibossheath;
            minibossheath = collision.gameObject.GetComponent<minibossnoastar>();
            minibossheath.takedamage(damge.attack);
        }
       else if (collision.CompareTag("enemy2"))
        {
            enemynoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<enemynoastar>();
            enemyheath.takedamage(damge.attack);

        }
        else if(collision.CompareTag("bat"))
        {
            enemybatnoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<enemybatnoastar>();
            enemyheath.takedamage(damge.attack);
        }
        else if (collision.CompareTag("worn"))
        {
            shottingnoastar enemyheath;
            enemyheath = collision.gameObject.GetComponent<shottingnoastar>();
            enemyheath.takedamage(damge.attack);
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
