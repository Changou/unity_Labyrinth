using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActionTurn : MonoBehaviour
{
    Rigidbody2D rigid;
    public int frontOrBackMove; //왼, 오른쪽 움직임
    public int upOrdownMove;    //위, 아래 움직임
    int temp;                   //움직임값 임시 저장
    public int rayturn;         //raycast방향
    RaycastHit2D rayhit;
    public float speed;           //몬스터 속도

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {   
        rigid.velocity = new Vector2(frontOrBackMove * speed, upOrdownMove * speed);

        if (frontOrBackMove != 0)   
        {
            Debug.DrawRay(rigid.position, (rayturn < 0 ? Vector3.left : Vector3.right) * 0.5f, new Color(0, 1, 0));
            rayhit = Physics2D.Raycast(rigid.position, (rayturn < 0 ? Vector3.left : Vector3.right) * 0.5f, 0.5f, LayerMask.GetMask("Platform"));
        }
        else
        {
            Debug.DrawRay(rigid.position, (rayturn < 0 ? Vector3.down : Vector3.up) * 0.5f, new Color(0, 1, 0));
            rayhit = Physics2D.Raycast(rigid.position, (rayturn < 0 ? Vector3.down : Vector3.up) * 0.5f, 0.5f, LayerMask.GetMask("Platform"));
        }

        if (rayhit.collider != null)
        {
            if(frontOrBackMove != 0)
            {
                temp = frontOrBackMove;
                frontOrBackMove = 0;
                StartCoroutine(TurnMoveUD());
            }
            else
            {
                temp = upOrdownMove;
                upOrdownMove = 0;
                rayturn *= -1;
                StartCoroutine(TurnMoveLR());
            }
        }
        
        IEnumerator TurnMoveUD()    //위, 아래로 방향 전환
        {
            yield return new WaitForSeconds(2.0f);
            upOrdownMove = temp;
        }

        IEnumerator TurnMoveLR()    //왼, 오른쪽으로 방향 전환
        {
            yield return new WaitForSeconds(2.0f);
            frontOrBackMove = temp;
            frontOrBackMove *= -1;
        }

        
    }
    
}
