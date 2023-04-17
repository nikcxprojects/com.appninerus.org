using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private float count;
    private GameObject _gameRef;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject best;

    [Space(10)]
    [SerializeField] GameObject pause;
    [SerializeField] GameObject gameover;

    [Space(10)]
    [SerializeField] Text countText;
    [SerializeField] GameObject pauseGo;

    [Space(10)]
    [SerializeField] AudioSource sfxSource;

    private void Awake()
    {
        EnemyGoal.OnGoalAction += () =>
        {
            count += 50;
            countText.text = $"SCORE {count}";
        };

        Player.OnPlayerAction += () =>
        {
            count += 5;
            countText.text = $"SCORE {count}";

            sfxSource.Play();
        };

        PlayerGoal.OnGoalAction += () =>
        {
            count -= 100;
            if(count <= 0)
            {
                count = 0;
            }

            countText.text = $"SCORE {count}";
        };
    }


    private void Start()
    {
        OpenMenu();
    }

    public void SetPause(bool IsPause)
    {
        Time.timeScale = IsPause ? 0.0f : 1.0f;
        pause.SetActive(IsPause);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        pauseGo.SetActive(false);

        GameObject.Find("SFXSource").GetComponent<AudioSource>().Play();
    }

    public void OpenBest()
    {
        menu.SetActive(false);
        best.SetActive(true);
    }

    public void StartGame()
    {
        count = 0;
        countText.text = $"SCORE {count}";

        Time.timeScale = 1.0f;

        gameover.SetActive(false);
        pauseGo.SetActive(true);

        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>("level");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);
        game.SetActive(true);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1.0f;
        pause.SetActive(false);

        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        best.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);
    }
}
