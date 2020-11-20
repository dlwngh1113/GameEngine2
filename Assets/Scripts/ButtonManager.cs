using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButtonPressed()
    {
        MySceneManager.Instance.LoadScene();
    }
}