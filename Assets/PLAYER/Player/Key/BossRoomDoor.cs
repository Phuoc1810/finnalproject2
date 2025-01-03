using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomDoor : MonoBehaviour
{
    public string TheEndDoorSceneName;

    public string bossRoomSceneName;
    public string spawm_Point_Name;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (KeyManager.instance.HasAllKeys())
            {
                if(PlayerBossSpawmManager.Instance == null)
                {
                    Debug.LogError("PlayerBossSpawmManager.Instance is Null! Make sure it exits in the scene");
                }

                PlayerBossSpawmManager.Instance.spawm_Point_Name = spawm_Point_Name;
                //reset lai key
                KeyManager.instance.ResetKey();
                StartCoroutine(LoadTHeEndDoor());
            }
        }
    }

    private IEnumerator LoadTHeEndDoor()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(TheEndDoorSceneName);
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(bossRoomSceneName);
    }
}
