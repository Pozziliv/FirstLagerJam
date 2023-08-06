using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public int _questsIndex = 0;

    public void NextQuest()
    {
        _questsIndex++;
    }
}
