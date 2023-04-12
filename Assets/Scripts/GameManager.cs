using TMPro;
using UnityEngine;
using UnityEngine.UI;


[DefaultExecutionOrder(-1)]

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

   
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI CoinCount;
    public Button retryButton;
    public Button exitButton;
    public AudioClip GameOver_sound;
    public AudioClip Coin_sound;

    public int points = 0;
    public string ZeroPoints  = "00000" ;


    public GameObject character1;
    public GameObject character2;
    public Spawner spawner;

    public float score;

    private int selectedCharacter = 1;

    public void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void Start()
    {
        LoadSelectedCharacter(); // загружаем выбранный персонаж

        spawner = FindObjectOfType<Spawner>();
        NewGame();
    }

    // метод, который сохраняет номер выбранного персонажа
    public void SaveSelectedCharacter(int characterNumber)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterNumber);
        selectedCharacter = characterNumber;
    }

    // метод, который загружает номер выбранного персонажа
    public void LoadSelectedCharacter()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 1);
        SetSelectedCharacter(selectedCharacter);
    }

    // метод, который устанавливает выбранный персонаж
    private void SetSelectedCharacter(int characterNumber)
    {
        if (characterNumber == 1)
        {
            character1.SetActive(true);
            character2.SetActive(false);
        }
        else if (characterNumber == 2)
        {
            character1.SetActive(false);
            character2.SetActive(true);
        }
    }

    // метод, который будет вызываться при нажатии на кнопку выбора первого персонажа
    public void OnSelectCharacter1()
    {
        SaveSelectedCharacter(1);
        SetSelectedCharacter(1);
    }

    // метод, который будет вызываться при нажатии на кнопку выбора второго персонажа
    public void OnSelectCharacter2()
    {
        SaveSelectedCharacter(2);
        SetSelectedCharacter(2);
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        points = 0;
        CoinCount.text = ZeroPoints;
        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;
        exitButton.gameObject.SetActive(false);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        exitButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        Time.timeScale = 0;

        AudioSource.PlayClipAtPoint(GameOver_sound, Camera.main.transform.position);
    }


    public void GetCoin()
    {
        
        points ++;
        CoinCount.text = points.ToString();
        CoinCount.text = Mathf.FloorToInt(points).ToString("D5");
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(Coin_sound);
    }




    public void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

}
