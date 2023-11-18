using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour,IDragHandler,IEndDragHandler
{
    public int snapOffset = 30;
    public Puzzle puzzle;

    bool CheckSnapPuzzle()  //퍼즐 맞추기 함수
    {
        for (int i = 0; i < puzzle.PuzzlePosSet.transform.childCount; i++)
        {
            if (puzzle.PuzzlePosSet.transform.GetChild(i).childCount != 0)  //놓여진 퍼즐이 있을시
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

    public void OnEndDrag(PointerEventData eventData) //마우스에서 손을 땔시
    {
        if (!CheckSnapPuzzle()) //퍼즐을 다시 뺄 시
            transform.SetParent(puzzle.PuzzlePieceSet.transform);

        if (puzzle.clearPassword()) //다 맞추었을시
            puzzle.VisibleButton();
        else
            puzzle.EnvisibleButton();
    }
    public void OnDrag(PointerEventData eventData) //마우스 클릭중
    {
        transform.position = eventData.position;
    }
}
