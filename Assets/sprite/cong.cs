
using UnityEngine;
using UnityEngine.SceneManagement;


public class cong : MonoBehaviour
{
    [SerializeField] private string fromscene;
    [SerializeField] private string toscene;



    void Start()
    {
        if (move._instance != null && move._instance.namescene == fromscene && move._instance.lastscene == toscene)
        {
            move._instance.transform.position = transform.position + Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SceneManager.LoadScene(toscene);
            move._instance.namescene = toscene;
            move._instance.lastscene = fromscene;
        }
    }
}
