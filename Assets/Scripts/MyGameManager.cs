using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    private static MyGameManager instance = null;
    [SerializeField]
    private Text _playerCounterText;
    [SerializeField]
    public Text _gameoverText;
    [SerializeField]
    public Button _lobbyButton;
    private const int _maxPlayer = 4;
    public int MaxPlayer
    {
        get => _maxPlayer;
    }
    private int _currPlayer;
    public int CurrPlayer
    {
        get => _currPlayer;
        set => _currPlayer = value;
    }
    static public MyGameManager Instance
    {
        get
        {
            if(instance == null)
            {
                print("GameManager is null");
                return null;
            }
                return instance;
        }
    }
    void Awake()
    {
        _currPlayer = 0;
        _gameoverText.gameObject.SetActive(false);
        _lobbyButton.gameObject.SetActive(false);
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _playerCounterText.text = _currPlayer + " / " + _maxPlayer;
    }
}
