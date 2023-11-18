using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActionTurn : MonoBehaviour
{
    Rigidbody2D rigid;
    public int frontOrBackMove; //��, ������ ������
    public int upOrdownMove;    //��, �Ʒ� ������
    int temp;                   //�����Ӱ� �ӽ� ����
    public int rayturn;         //raycast����
    RaycastHit2D rayhit;
    public float speed;           //���� �ӵ�

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
        
        IEnumerator TurnMoveUD()    //��, �Ʒ��� ���� ��ȯ
        {
            yield return new WaitForSeconds(2.0f);
            upOrdownMove = temp;
        }

        IEnumerator TurnMoveLR()    //��, ���������� ���� ��ȯ
        {
            yield return new WaitForSeconds(2.0f);
            frontOrBackMove = temp;
            frontOrBackMove *= -1;
        }

        
    }
    
}
