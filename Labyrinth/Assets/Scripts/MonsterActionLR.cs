using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActionLR : MonoBehaviour
{
    Rigidbody2D rigid;
    public int frontOrBackMove;
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
        rigid.velocity = new Vector2(frontOrBackMove * speed, rigid.velocity.y);

        Debug.DrawRay(rigid.position, (rayturn < 0 ? Vector3.left : Vector3.right) * 0.5f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, (rayturn < 0 ? Vector3.left : Vector3.right)* 0.6f, 0.6f,LayerMask.GetMask("Platform"));
        if(rayhit.collider != null)
        {
            temp = frontOrBackMove;
            frontOrBackMove = 0;
            rayturn *= -1;
            StartCoroutine(TurnMove());
        }
    }
    IEnumerator TurnMove()
    {
        yield return new WaitForSeconds(2.0f);
        frontOrBackMove = temp;
        frontOrBackMove *= -1;
    }
}
