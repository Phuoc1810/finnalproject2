using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject blood;
   public void Destroyblood()
    {
        blood.SetActive(false);
    }
}
