using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActionUD : MonoBehaviour
{
    Rigidbody2D rigid;
    public int upOrdownMove;
    int temp;
    public int rayturn;
    public float speed;           //몬스터 속도
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        rigid.velocity = new Vector2(rigid.velocity.x, upOrdownMove * speed);

        Debug.DrawRay(rigid.position, (rayturn < 0 ? Vector3.down : Vector3.up) * 0.5f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, (rayturn < 0 ? Vector3.down : Vector3.up)* 0.5f, 0.5f,LayerMask.GetMask("Platform"));
        if(rayhit.collider != null)
        {
            temp = upOrdownMove;
            upOrdownMove = 0;
            rayturn *= -1;
            StartCoroutine(TurnMove());
        }
    }
    IEnumerator TurnMove()
    {
        yield return new WaitForSeconds(2.0f);
        upOrdownMove = temp;
        upOrdownMove *= -1;
    }
}
