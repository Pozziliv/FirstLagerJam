using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quests : MonoBehaviour
{
    public int _questsIndex = 0;
    private int _endIndex = 13;

    public void NextQuest()
    {
        _questsIndex++;
        if( _questsIndex == _endIndex )
            SceneManager.LoadScene(1);
    }
}
