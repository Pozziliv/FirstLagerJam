using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalWall : MonoBehaviour
{
    [SerializeField] private int _questIndex;
    [SerializeField] private Quests _questSystem;

    private void Update()
    {
        if (_questIndex == _questSystem._questsIndex)
        {
            Destroy(this.gameObject);
        }
    }
}
