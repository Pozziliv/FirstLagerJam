using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quests : MonoBehaviour
{
    public int _questsIndex = 0;
    private int _endIndex = 13;

    [SerializeField] private Image _darkness;
    private WaitForSeconds _darkTime = new WaitForSeconds(0.02f);
    [SerializeField] private float _alpha = 0;

    public void NextQuest()
    {
        _questsIndex++;
        if (_questsIndex == _endIndex)
            StartCoroutine(GoToLabirint());
    }

    private IEnumerator GoToLabirint()
    {
        while(_darkness.color.a < 1)
        {
            _alpha += 0.05f;
            _darkness.color = new Color(0, 0, 0, _alpha);
            yield return _darkTime;
        }
        SceneManager.LoadScene(2);
    }
}
