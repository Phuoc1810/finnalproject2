using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject explosiveTilePerfab; // tham chieu den vien gach
    public Animator animator;
    public float tileSpawmInterval = 0.5f; // khoan thoi gian giua cac lan spawm o vuong
    public int numberOfTile = 8; // so o vuong xuat hien sau moi dot tan cong
    private Transform playerTransform; // vi tri cua nguoi choi
    public float timeStart = 2.5f; // thoi gian de boss bat dau tan cong
    private Vector3 currentDirection; // huong di chuyen cua chuoi gach

    //quan li chi so boss
    public int maxHeal = 200;
    private int currentHeal; //mau hien tai
    //public GameObject specialSkill; //ki nang dac biet

    //tham chieu den heal bar
    public Slider healSlider;

    //tham chieu den sprite nguoi choi
    private playersat playerStart;

    //bien kiem tra su dung skill dac biet
    private bool isSpecialSkillColdDown = false;
    //quan li trang thai tan cong
    private bool isAttacking = true;

    void Start()
    {
        currentHeal = maxHeal; //khoi tao mau cua boss

        if(healSlider != null )
        {
            healSlider.maxValue = maxHeal;
            healSlider.value = currentHeal;
        }

        //specialSkill.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform; // gan transform cua Player vao bien player
            playerStart = player.GetComponent<playersat>(); //lay component chi so cua player
            if(playerStart == null)
            {
                Debug.LogError("Player does not have 'playersat' component");
            }
        }
        else
        {
            Debug.LogError("Dont Find game object with tag 'Player' !");
        }
        StartAttackSequence();
    }

    public void StartAttackSequence()
    {
        Debug.Log("Attack sequence started");
        StartCoroutine(BossStart());
    }

    private IEnumerator BossStart()
    {
        yield return new WaitForSeconds(timeStart);
        //goi effect boss
        StartCoroutine(SpawmTiles());
    }

    private IEnumerator AttackPhases()
    {
        yield return new WaitForSeconds(timeStart);
        //giai doan 2 (khi mau <= 60%)
        while (currentHeal >= maxHeal * 0.6f)
        {
            yield return StartCoroutine(PhaseTwoMachanic());
        }
        //giai doan 3 (khi mau <= 30%)
        while (currentHeal  >= maxHeal * 0.3f && currentHeal > 0)
        {
            yield return StartCoroutine(PhareThreeMechanic());
        }
    }
    private IEnumerator SpawmTiles()
    {
        Debug.Log("Starting to spawn tiles...");

        while (isAttacking)
        {
            yield return new WaitForSeconds(1); // thoi gian cho tuong ung vo animation tan cong

            animator.SetTrigger("Attack1");

            // lay vi tri hien tai cua player la diem bat dau
            currentDirection = (playerTransform.position - transform.position).normalized; // huong mac dinh cua vien gach

            float spacing = 1.5f; // khoang cach giua cac vien gach
            Vector3 lastTilePosition = playerTransform.position; // vi tri ban dau la vi tri player

            for (int i = 0; i < numberOfTile; i++)
            {
                // tinh toan vi tri moi (tinh theo vi tri cuoi cùng, không phải vị trí người chơi)
                Vector3 tilePosition = lastTilePosition + currentDirection * spacing;

                // tạo viên gạch tại vị trí tính toán
                if (playerTransform != null)
                {
                    Debug.Log("Spawning tile");
                    GameObject tile = Instantiate(explosiveTilePerfab, tilePosition, Quaternion.identity);
                    tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
                }
                // cho truoc khi tao o vuong tiep theo
                yield return new WaitForSeconds(tileSpawmInterval);
            }
            animator.SetTrigger("Indle");
            yield return new WaitForSeconds(3); //dot tan con tiep theo
        }
    }

    //giai doan 2
    private IEnumerator PhaseTwoMachanic()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(1); //delay truoc khi bat dau giai doan 2
            animator.SetTrigger("Attack1");

            //spawm cac o vuong xung quanh nguoi choi
            for(int i = 0; i < numberOfTile; i++)
            {
                Vector3 ramdomOffset = Random.insideUnitCircle * 3f; //vi tri ngau nhien trong ban kinh 3 don vi xung quanh nguoi choi
                Vector3 tilePosition = playerTransform.position + ramdomOffset;

                //tao o vuong tai vi tri da tinh toan
                GameObject tile = Instantiate(explosiveTilePerfab, tilePosition, Quaternion.identity);
                tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
            }
            animator.SetTrigger("Indle");
            yield return new WaitForSeconds(3);
        }
    }

    //Giai doan 3
    private IEnumerator PhareThreeMechanic()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(1);
            animator.SetTrigger("Attack1");

            //lay toan bo san dau va xac dinh vung an toan
            Vector3 arenaCenter = transform.position; //Gia dinh boss o giua san dau
            float arenaSize = 6f; //gioi gan san dau (gia dinh 6x6)
            int safeTile = 5; //so luong o vuong an toan

            HashSet<Vector3> safeZones = new HashSet<Vector3>();
            while (safeZones.Count < safeTile)
            {
                Vector3 safePosition = arenaCenter + new Vector3(
                    Random.Range(-arenaSize, arenaSize),
                    Random.Range(-arenaSize, arenaSize),
                    0
                );
                safeZones.Add(safePosition);
            }

            //spawn o vuong tren mat dat, ngoai tru vung an toan
            for(float x = - arenaSize; x <= arenaSize; x += 1.5f)
            {
                for (float y = - arenaSize; y <= arenaSize; y += 1.5f)
                {
                    Vector3 tilePoision = arenaCenter + new Vector3(x, y, 0);
                    if (!safeZones.Contains(tilePoision))
                    {
                        GameObject tile = Instantiate(explosiveTilePerfab, tilePoision, Quaternion.identity);
                        tile.GetComponent<ExplosiveTile>().Initialize(playerTransform.position);
                    }
                }
            }
        }
        animator.SetTrigger("Indle");
        yield return new WaitForSeconds(3);
    }
    //ham giam mau cua boss
    public void TakeDamage()
    {
        if (playerStart == null) return; // dam bao playerStarts khong null
        //tinh sat thuong dua tren chi so choi cua nguoi choi
        int damage = (int)playerStart.attack;
        currentHeal -= damage; //giam mau cua boss

        StartCoroutine(ChangeColorWhenDamaged());
        Debug.Log($"Boss current health: {currentHeal}");

        if(healSlider != null)
        {
            healSlider.value = currentHeal; //cap nhat gia tri cho thanh mau
        }

        //kich hoat ki nang dac biet khi mau <= 30%
        //if(currentHeal <= maxHeal * 0.3 && !isSpecialSkillColdDown && specialSkill != null && !specialSkill.activeSelf)
        
            //StartCoroutine(ActivateSpecialSkill());
        

        //kiem tra neu mau <= 0
        if(currentHeal <= 0)
        {
            isAttacking = false;
            animator.ResetTrigger("Attack1");
            Die();
            //specialSkill.SetActive(false);
        }
    }

    //couroutine de doi mau tam thoi khi nhan sat thuong
    private IEnumerator ChangeColorWhenDamaged()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red; //chuyen sang mau do
            yield return new WaitForSeconds(0.2f); //thoi gian giu mau do
            spriteRenderer.color = Color.white;//tra ve mau goc
        }
    }

    //goi special skill
    //private IEnumerator ActivateSpecialSkill()
    //{
       // specialSkill.SetActive(true);
       // Debug.Log("special skill is active");
        //yield return new WaitForSeconds(0.4f);
       // specialSkill.SetActive(false);

        //isSpecialSkillColdDown = true;
       // yield return new WaitForSeconds(4);
       // isSpecialSkillColdDown = false;
    //}
    //xu li logic khi boss chet
    private void Die()
    {
        isAttacking = false;
        animator.ResetTrigger("Attack1");
        Debug.Log("boss defeated!");
        StopAllCoroutines(); //dung tat ca cac coroutine dang chay
        //cho doi cho den khi Die hoan thanh
        StartCoroutine(WaitForDeathAnimation());
    }
    private IEnumerator WaitForDeathAnimation()
    {
        //ngat animation tan cong de tranh xung dot
        animator.ResetTrigger("Attack1");
        //doi cho den khi aniamtion die hoan thanh
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(3);
        animator.SetTrigger("die");
        // huy doi tuong 
        Destroy(gameObject, 10);
    }
}
