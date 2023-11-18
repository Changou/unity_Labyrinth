using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float Speed;

    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject; 
    
    public bool yourDied;
    public bool flag;
    public GameObject inputK;
    public GameObject inputH;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    ContainerManager playerUI;
    OverManager overM;

    void Awake()
    {
        SoundManager.instance.PlayBGM("Main");
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerUI = FindObjectOfType<ContainerManager>();
        overM = FindObjectOfType<OverManager>();
        inputH.SetActive(false);
        inputK.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        //Check Horizontal Move
        if (hDown && !flag)
        {
            isHorizonMove = true;
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Animation
        if (rigid.velocity.normalized.x == 0 && rigid.velocity.normalized.y == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", true);

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h ==-1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
    }

    void FixedUpdate()
    {
        if (yourDied && flag == false)  //체력이 다 떨어졌을 시
        {
            flag = true;
            NextGameOverSecne();
        }
        else if (flag)
        {
            //키를 눌러도 캐릭터가 움직이지 않음
        }
        else
        {
            //Move
            Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
            rigid.velocity = moveVec * Speed;

            //Ray
            Debug.DrawRay(rigid.position, dirVec * 0.5f, new Color(0,1,0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.5f, LayerMask.GetMask("Item"));

            if (rayHit.collider != null)
            {
                scanObject = rayHit.collider.gameObject;
                if (scanObject.name.Equals("Key"))
                    inputK.SetActive(true);

                else if (scanObject.name.Equals("Hint"))
                    inputH.SetActive(true);
            }
            else
            {
                scanObject = null;
                inputK.SetActive(false);
                inputH.SetActive(false);
            }
        }
    }

    public void RigidConsFree() //캐릭터 고정 해제
    {
        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void PositionReset() //캐릭터 위치 리셋
    {
        rigid.position = new Vector2(-0.5f, -0.5f);
    }
    public void WakeUp() //캐릭터 모습 원위치
    {
        anim.SetBool("isOver", false);
    }

    void NextGameOverSecne()     //Game Over
    {
        SoundManager.instance.StopAllBGM();
        SoundManager.instance.PlaySE("Death");
        // Change Layer
        gameObject.layer = 11;
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        playerUI.Envisivle();
        anim.SetBool("isOver", true);
        overM.GameOverView();
    }

    void OnCollisionEnter2D(Collision2D collision) //몬스터와 부딪힐 시
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnDamaged();
        }
    }

    void OnDamaged()    //대미지를 입을 시
    {
        playerUI.DecreaseHp(1);
        
        if (playerUI.currentHp <= 0) //체력이 0이 될 시
            yourDied = true;

        else
        {
            SoundManager.instance.PlaySE("Damaged");
            // Change Layer
            gameObject.layer = 11;

            //View Alpha
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            //Animation
            anim.SetTrigger("doDamaged");
            Invoke("OffDamaged", 2);        //2초뒤에 실행
        }
    }

    void OffDamaged() //무적시간 설정
    {
        gameObject.layer = 10;  //레이어 설정
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}