using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour,IDragHandler,IEndDragHandler
{
    public int snapOffset = 30;
    public Puzzle puzzle;

    bool CheckSnapPuzzle()  //���� ���߱� �Լ�
    {
        for (int i = 0; i < puzzle.PuzzlePosSet.transform.childCount; i++)
        {
            if (puzzle.PuzzlePosSet.transform.GetChild(i).childCount != 0)  //������ ������ ������
                continue;

            else if (Vector2.Distance(puzzle.PuzzlePosSet.transform.GetChild(i).position, transform.position) < snapOffset)
            {
                transform.SetParent(puzzle.PuzzlePosSet.transform.GetChild(i).transform);
                transform.localPosition = Vector3.zero;
                return true;
            }
        }
        return false; 
    }

    public void OnEndDrag(PointerEventData eventData) //���콺���� ���� ����
    {
        if (!CheckSnapPuzzle()) //������ �ٽ� �� ��
            transform.SetParent(puzzle.PuzzlePieceSet.transform);

        if (puzzle.clearPassword()) //�� ���߾�����
            puzzle.VisibleButton();
        else
            puzzle.EnvisibleButton();
    }
    public void OnDrag(PointerEventData eventData) //���콺 Ŭ����
    {
        transform.position = eventData.position;
    }
}
