using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image _darkness;
    private WaitForSeconds _darkTime = new WaitForSeconds(0.02f);
    [SerializeField] private float _alpha = 0;
    public bool isActivated = false;

    public IEnumerator End()
    {
        while (_darkness.color.a < 1)
        {
            _alpha += 0.05f;
            _darkness.color = new Color(0, 0, 0, _alpha);
            yield return _darkTime;
        }
        SceneManager.LoadScene(0);
    }
}
