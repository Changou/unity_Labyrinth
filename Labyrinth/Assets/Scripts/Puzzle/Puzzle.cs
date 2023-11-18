using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public GameObject PuzzlePosSet;
    public GameObject PuzzlePieceSet;
    public string puzzlePassord;
    public GameObject PuzzleBtn;
    public Text password;

    void Start()
    {
        PuzzleBtn.SetActive(false);
        puzzlePassord = "PW : ";
    }

    // Start is called before the first frame update
    public bool clearPassword()
    {
        for (int i = 0; i < PuzzlePosSet.transform.childCount; i++)
        {
            if (PuzzlePosSet.transform.GetChild(i).childCount == 0)
                return false;
        }
        return true;
    }
    

    public void Password()
    {
        for (int i = 0; i < PuzzlePosSet.transform.childCount; i++)
        {
            puzzlePassord += PuzzlePosSet.transform.GetChild(i).GetChild(0).GetChild(0).name;
        }
        password.text = puzzlePassord;
    }

    public void VisibleButton()
    {
        PuzzleBtn.SetActive(true);
    }

    public void EnvisibleButton()
    {
        PuzzleBtn.SetActive(false);
    }
}
