using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLock : MonoBehaviour
{
    public GameObject nightBorne; //tham chieu den enemy
    public GameObject lockDoor;
    public GameObject unlockDoor;
    // Start is called before the first frame update
    void Start()
    {
        nightBorne.SetActive(false);
        lockDoor.SetActive(false);
        unlockDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(NightBorne());
        }
    }

    private IEnumerator NightBorne()
    {
        yield return new WaitForSeconds(1);
        lockDoor.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        nightBorne.SetActive(true);
    }
    private IEnumerator FuntionHide()
    {
        yield return new WaitForSeconds(4);
        Destroy(lockDoor);
        unlockDoor.SetActive(false);
    }
}
