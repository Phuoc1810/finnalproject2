
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    Animator ani;
    bool trigger;
    public int combo;
    public int combonumber;
    public bool attacking;
    
    public float rollboost = 2f;
    public float rolltime;
    public float Rolltime;
    bool rollonce = false;


    public float combotiming;

    public float combotempo;
    [SerializeField] private float rspeed;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    Animator anim;
    public static player _instance;

    public string namescene;
    public string lastscene;
    public Transform attackpoint;
    
    private float attacktime=.25f;
    private float attackcouter=.25f;
    private bool isattacking= false;

    [SerializeField] private GameObject panel_UIPlayer;
    [SerializeField] private GameObject Canvas_HealBar;

    //am thanh tan cong
    public AudioClip attackSound;
    public AudioClip attackSound2;
    public AudioClip attackSound3;

    //tham chieu den Watermelon
    public Watermelon watermelon;
    public Fish fish;
    // Start is called before the first frame update
    public Slider sliderstamina;
    public float stamina = 1;
    public float count = 0;
    
    void Start()
    {
        combonumber = 2;
        
        combo = 1;
        combotiming = 2f;
        combotempo = combotiming;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        panel_UIPlayer.SetActive(true);
        Canvas_HealBar.SetActive(true);
        //singleton: 1 chay xuyen suot 1 game;
        // khong xoa nv khi chuyen scene
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(panel_UIPlayer);
            Destroy(gameObject);
            Destroy(Canvas_HealBar);
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(panel_UIPlayer);
        DontDestroyOnLoad(Canvas_HealBar);  
    }

    // Update is called once per frame
    void Update()
    {
        
        if(stamina<1 && rollonce==false && attacking==false)
        {
            if(count<=0 && stamina <=0 )
            {
                stamina -= 2f;
                count += 1;
            }
            stamina += Time.deltaTime;
            if(stamina>0)
            {
                count = 0;
            }
        }
        sliderstamina.value = stamina;
        Comboskill2();
        Comboskill1();
        Combo();
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        //khuyen khich dung rigidbody de di chuyen
        anim.SetFloat("lastmoveX", moveX);
        anim.SetFloat("lastmoveY", moveY);

        if(Input.GetKeyDown(KeyCode.Space) && rolltime <= 0 && stamina > 0 && rollonce == false)
        {
            anim.SetBool("roll", true);
            stamina -= 0.3f;
            speed += rollboost;
            rolltime = Rolltime;
            rollonce = true;
           
        }

        else if(rolltime<=0&&rollonce==true)
        {
            anim.SetBool("roll", false);
            speed -= rollboost;
            rollonce = false;
            
        }

        else
        {
            rolltime -= Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        rb.velocity = new Vector2(moveX, moveY) * rspeed;

        else
          rb.velocity = new Vector2(moveX, moveY) * speed;
        
        if (moveX >= 0.1 || moveX <= -0.1 || moveY >= 0.1 || moveY <= -0.1)
        {
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(watermelon != null)
            {
                watermelon.UseWatermelon();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (fish != null)
            {
                fish.UseFish();
            }
        }
    }
    public void Combo()
    {
        //giam combo tempo theo thoi gian khung hinh time.deltatime;
        combotempo -= Time.deltaTime;
        //neu co lenh tan cong thi moi thuc hien combo
        if (Input.GetKeyDown(KeyCode.J) && combotempo < 0 && stamina > 0)
        {
            //bat trang thai tan cong
            attacking = true;
            stamina -= 0.2f;
            //kich hoat animation tan conng

            anim.SetTrigger("attack" + combo);
            //combotempo=combotiming
            combotempo = combotiming;
        }
        //neu chua het thoi gian de kich hoat combo
        else if (Input.GetKeyDown(KeyCode.J) && combotempo > 0 && stamina > 0)
        {
            // bat trang thai tan cong
            attacking = true;
            stamina -= 0.2f;
            //tang gia tri bien dem compo ktr xem vuot bien dem chua
            combo += 1;

            //neu da dat gioi hang combo thi set combonumber=1
            if (combo > combonumber)
            {
                combo = 1;
            }
            //show ra animation tan cong
           
            anim.SetTrigger("attack" + combo);
            //thiet lap lai gia tri combotiming
            combotempo = combotiming;
        }
        //neu nhu k co lenh tan cong nao dc thuc hien thi trang thai tan cong tat
        else if (combotempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
        }
        //neu combo tempo <0 thi reset gia tri combo ve 1 de thuc hien combo
        if (combotempo < 0)
        {
            combo = 1;
        }

    }
    public void Comboskill1()
    {
        //giam combo tempo theo thoi gian khung hinh time.deltatime;
        combotempo -= Time.deltaTime;

        //lay sprite playersat de truy cap chi so mana
        playersat stats = GetComponent<playersat>();
        if(stats == null) return;

        float healCost = 5; //luong hp tieu ton cho ki nang 1

        //neu co lenh tan cong thi moi thuc hien combo
        if (Input.GetKeyDown(KeyCode.K) && combotempo < 0 && stats.currenthp >= healCost && stamina > 0) //kiem tra va kich hoat ki nang neu co du mana
        {
            //tru hp
            stamina -= 0.2f;
            stats.currenthp -= healCost;
            //bat trang thai tan cong
            attacking = true;
            //kich hoat animation tan conng

            anim.SetTrigger("blood" + combo);
            //combotempo=combotiming
            combotempo = combotiming;
        }
        //neu chua het thoi gian de kich hoat combo
        else if (Input.GetKeyDown(KeyCode.K) && combotempo > 0 && stats.currenthp >= healCost && stamina > 0)
        {
            //tru hp
            stamina -= 0.2f;
            stats.currenthp -= healCost;
            // bat trang thai tan cong
            attacking = true;

            //tang gia tri bien dem compo ktr xem vuot bien dem chua
            combo += 1;

            //neu da dat gioi hang combo thi set combonumber=1
            if (combo > combonumber)
            {
                combo = 1;
            }
            //show ra animation tan cong

            anim.SetTrigger("blood" + combo);
            //thiet lap lai gia tri combotiming
            combotempo = combotiming;
        }
        //neu nhu k co lenh tan cong nao dc thuc hien thi trang thai tan cong tat
        else if (combotempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
        }
        //neu combo tempo <0 thi reset gia tri combo ve 1 de thuc hien combo
        if (combotempo < 0)
        {
            combo = 1;
        }

    }
    public void Comboskill2()
    {
        //giam combo tempo theo thoi gian khung hinh time.deltatime;
        combotempo -= Time.deltaTime-0;

        //lay sprite playersat de truy cap chi so mana
        playersat starts = GetComponent<playersat>();

        float manaCost = 20;
        //neu co lenh tan cong thi moi thuc hien combo
        if (Input.GetKeyDown(KeyCode.L) && combotempo < 0 && starts.currentmp >= manaCost && stamina > 0)
        {
            //tru mana
            stamina -= 0.2f;
            starts.currentmp -= manaCost;
            //bat trang thai tan cong
            attacking = true;
            //kich hoat animation tan conng

            anim.SetTrigger("fire" + combo);
            //combotempo=combotiming
            combotempo = combotiming;
        }
        //neu chua het thoi gian de kich hoat combo
        else if (Input.GetKeyDown(KeyCode.L) && combotempo > 0 && starts.currentmp >= manaCost && stamina > 0)
        {
            //tru mana
            stamina -= 0.2f;
            starts.currentmp -= manaCost;
            // bat trang thai tan cong
            attacking = true;

            //tang gia tri bien dem compo ktr xem vuot bien dem chua
            combo += 1;

            //neu da dat gioi hang combo thi set combonumber=1
            if (combo > combonumber)
            {
                combo = 1;
            }
            //show ra animation tan cong

            anim.SetTrigger("fire" + combo);
            //thiet lap lai gia tri combotiming
            combotempo = combotiming;
        }
        //neu nhu k co lenh tan cong nao dc thuc hien thi trang thai tan cong tat
        else if (combotempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
        }
        //neu combo tempo <0 thi reset gia tri combo ve 1 de thuc hien combo
        if (combotempo < 0)
        {
            combo = 1;
        }

    }
    public void SoundAttack1()
    {
        AudioManager.instance.PlayOneShotAudio(attackSound);
    }
    public void SoundAttack2()
    {
        AudioManager.instance.PlayOneShotAudio(attackSound2);
    }
    public void SoundAttack3()
    {
        AudioManager.instance.PlayOneShotAudio(attackSound3);
    }
}
