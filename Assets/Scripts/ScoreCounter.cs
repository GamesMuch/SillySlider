using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int shotCount = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate ScoreManager detected. Destroying extra instance.");
            Destroy(gameObject);
            return;
        }
        GetFinalScore();
    }
    private void Start()
    {
        
    }

    public void AddShot()
    {
        shotCount++;
    }

    public int GetScore()
    {
        return shotCount;
    }

    public void ResetScore()
    {
        shotCount = 0;

    }
    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }
    public void StartScene()
    {
        shotCount = 0;
        SceneManager.LoadScene(0);
    }
    public void GetFinalScore()
    {
        TextMeshProUGUI scoreText = FindObjectOfType<TextMeshProUGUI>();
        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + shotCount;
        }
    }
}
