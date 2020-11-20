using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private static MySceneManager instance = null;
    private Image _alphaImg;
    public static MySceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            _alphaImg = GetComponent<Image>();
            _alphaImg.color = new Color(0f, 0f, 0f, 0f);
        }
    }

    public void LoadScene()
    {
        int currSceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (currSceneIdx < SceneManager.sceneCount)
        {
            StartCoroutine("FadeOut", currSceneIdx + 1);
        }
        else
        {
            StartCoroutine("FadeOut", 0);
        }
    }
    public IEnumerator FadeOut(int idx)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(idx);
        Color col;
        while (!op.isDone)
        {
            col = _alphaImg.color;
            col.a = op.progress;
            _alphaImg.color = col;
            yield return null;
        }
        col = _alphaImg.color;
        col.a = 0f;
        _alphaImg.color = col;
    }
}