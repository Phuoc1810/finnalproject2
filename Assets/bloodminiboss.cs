using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodminiboss : MonoBehaviour
{
    public bool bloodstatus;
    public int count;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    private void Update()
    {
        bloodon();
    }
    public void bloodon()
    {
        if (count == 1 && bloodstatus)
            blood1.SetActive(true);
        else if (count == 2 && bloodstatus)
        {
            blood1.SetActive(false);
            blood2.SetActive(true);
        }
        else if (count == 3 && bloodstatus)
        {
            blood2.SetActive(false);
            blood3.SetActive(true);
        }
        else if (count >= 4 && bloodstatus)
        {
            blood3.SetActive(false);
            blood4.SetActive(true);
            minibossnoastar enemyheath;
            enemyheath = this.gameObject.GetComponent<minibossnoastar>();
            enemyheath.takedamagefire(8);
            count = 0;
            bloodstatus = false;
        }
    }
}
