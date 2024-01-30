using UnityEngine;
using UnityEngine.EventSystems;



public class Player : MonoBehaviour
{
    public static Player Player_;
    public Vector3 _PlayerEndPanelNeed;
    public bool PlayerDie;
    public RingSiez _retune;
    #region All object

    // -----------------
    private Rigidbody2D rb;
    // PlayerVector
    #endregion
    // -----------------
    #region varyebls
    public int Dead;
    public int RingCount;
    public float Jump;
    private float JumpStorage;
    public float Speed;
    public float Water_power;
    float x;
    public bool jumpboll;
    private bool MoveLeft;
    private bool MoveRight;
    private float TimeEvent;
    private float GravityTime_;
    private float SpeedStoage;
    private Vector3 GravetyStoragr;
    public bool JumpButton;
    #endregion
    // -----------------
    #region SystemMethods
    private void Awake()
    {
        if(Player_ == null)
        {
            Player_ = this;
        }
        else
        {
            Player_ = this;
        }
        PlayerPrefs.SetFloat("Sound",1f);
    }
    private void Update()
    {
        if(this.transform.localScale == new Vector3(0.36f, 0.36f, 0.36f))
        {
            _retune = RingSiez.Big;
        }
        if (this.transform.localScale == new Vector3(0.25f, 0.25f, 0.25f))
        {
            _retune = RingSiez.Small;
        }
    }
    void Start()
    {
        _PlayerEndPanelNeed = transform.position;
        rb = GetComponent<Rigidbody2D>();
        BollControler.SavePosition(transform.position);
        RingCount = GameObject.FindGameObjectsWithTag("Ring").Length;
        Dead = 3;
        SpeedStoage = Speed;
        JumpStorage = Jump;
        GravetyStoragr = Physics2D.gravity;
    }
    void FixedUpdate()
    {
        if (JumpButton && !jumpboll)
        {
            rb.AddRelativeForce(new Vector2(rb.velocity.x, Jump), ForceMode2D.Impulse);
        }

        x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(x * Speed * Time.fixedDeltaTime, rb.velocity.y);

        if (MoveLeft)
        {
            Left();
        }

        if (MoveRight)
        {
            Right();
        }

        PlayerDie = true;
        if(Dead <= 0)
        {
            MainPanel._Mainpanel._GameOver_Panel.SetActive(true);
            GameAudio.GameAudio_.Component(false);
            Camera._Camera._Canvas.SetActive(false);
            MainPanel._Mainpanel._Push.SetActive(false);
            Time.timeScale = 0;
        }

        JumpWork();
        MoveSpeedPower();
        FlyPlayer();
    }
    #endregion
    // -----------------
    #region OnMethod
    // Boll > Enemy > Ground > Boll_speed_power
    private void OnCollisionEnter2D(Collision2D co)
    {

        if (co.collider.CompareTag("Jump") || co.collider.CompareTag("Ground")|| co.collider.CompareTag("BollBig"))
        {
            jumpboll = false; 
        }

        if (co.collider.CompareTag("Ground") || co.collider.CompareTag("BollBig") || co.collider.CompareTag("ExGround"))
        {
            if (this.transform.localScale == new Vector3(0.25f, 0.25f, 0.25f))
            {
                Jump = 6.8f;
            }

            if (this.transform.localScale == new Vector3(0.36f, 0.36f, 0.36f))
            {
                Jump = 6.7f;
            }
        }

        if (co.collider.CompareTag("Jump"))
        {
            if(JumpButton == false)
            {
                Jump = JumpStorage;
            }
        }

        if (co.collider.tag == "Enemy")
        {
            BollControler.BackPosition();
            GameAudio.GameAudio_.Component(true);
            Gravity = 0;
        }

        if (co.collider.tag =="BollBig")
        {
            BollControler.MegaSiez();
        }

        if (co.collider.tag == "SmallBoll")
        {
            jumpboll = false;
            BollControler.MegaSmall();
        }

        if (co.collider.gameObject.name == "PowerSpeed")
        {
            TimeEvent = 10;
        }

        if (co.collider.CompareTag("Jump"))
        {
            if(JumpButton == true)
            {
                Jump += 1f;
            }
        }

    }
    // Exit_Time ~ Jump > Ground/Small>Jump > Boll_Jump_Work
    private void OnCollisionExit2D(Collision2D co)
    {
        if (co.collider.tag == "Ground")
        {
            jumpboll = true;
        }

        if (co.collider.tag == "SmallBoll")
        {
            jumpboll = true;
        }

        if (co.collider.tag == "Jump")
        {
            jumpboll = true;
        }

    }
    // Water Enter All
    private void OnTriggerEnter2D(Collider2D co)
    {
        if (co.gameObject.CompareTag("Water"))
        {
            if(transform.localScale == new Vector3(0.36f,0.36f,0.36f))
            {
                Physics2D.gravity = new Vector2(0f, Water_power * Time.deltaTime);
            }  
        }
    }
    private void OnTriggerStay2D(Collider2D co)
    {
        if (co.gameObject.CompareTag("Water"))
        {
            if (transform.localScale == new Vector3(0.36f, 0.36f, 0.36f))
            {
                Physics2D.gravity = new Vector2(0f, Water_power * Time.deltaTime);
            }
            else
            {
                if (co.gameObject.CompareTag("Water"))
                {
                    Physics2D.gravity = new Vector2(0f, -9.31f);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D co)
    {
        if (co.gameObject.CompareTag("Water"))
        {
            Physics2D.gravity = new Vector2(0f, -9.31f);
        }
    }

    #endregion
    // -----------------
    #region AllMethods
    public void DethPlayer(int Number)
    {
        Dead -= Number;
    }
    public void PowerUp(int PowerUp)
    {
        Dead += PowerUp;
    }
    public void Ring(int Ring)
    {
        RingCount -= Ring;
    }
    public void jump(bool JumpOn)
    {
        JumpButton = JumpOn;
    }
    void JumpWork()
    {
        if (Input.GetKey(KeyCode.Space) && !jumpboll)
        {
            rb.AddRelativeForce(new Vector2(rb.velocity.x, Jump), ForceMode2D.Impulse);
        }
    }
    public void ButtonRight(bool Right)
    {
        MoveRight = Right;
    }
    public void ButtonLeft(bool Left)
    {
        MoveLeft = Left;
    }
    void Right()
    {
        rb.AddForce(new Vector2(Speed, rb.velocity.y));
    }
    void Left()
    {
        rb.AddForce(new Vector2(-Speed, rb.velocity.y));
    }    
    public void Destory()
    {
        Destroy(this.gameObject);
    }
    void MoveSpeedPower()
    {
        if (0 <= TimeEvent)
        {
            TimeEvent -= Time.deltaTime;
            Speed = 450f;
        }
        else
        {
            Speed = SpeedStoage;
        }
    }
    void FlyPlayer()
    {
        if (GravityTime_ >= 0)
        {
            GravityTime_ -= Time.deltaTime;
            Physics2D.gravity = new Vector2(0f, Water_power * Time.deltaTime);
            if(GravityTime_ <= 0)
            {
                Physics2D.gravity = GravetyStoragr;
            }
        }  
    }
    #endregion
    //-----------
    #region Property

    public float Gravity
    {
        set
        {
            this.GravityTime_ = value;
        }
    }

    #endregion
    public void NextLevel()
    {
        BollControler.LevelWin();
    }
}