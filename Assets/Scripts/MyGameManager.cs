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
    private PlayerController _playerController;
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
        _playerController = FindObjectOfType<PlayerController>();
        if (null == instance)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_currPlayer >= _maxPlayer)
        {
            _playerController.gameObject.SetActive(false);
            Instance._gameoverText.gameObject.SetActive(true);
            Instance._lobbyButton.gameObject.SetActive(true);
        }
        _playerCounterText.text = _currPlayer + " / " + _maxPlayer;
    }
}
