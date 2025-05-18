using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  
    public TextMeshProUGUI scoreText;               
    private int score = 0;

    void Awake()
    {
        // Asegura solo una instancia
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddPoint(float pointMult)
    {
        if (pointMult == 1)
        {
            score++;
            UpdateUI();
        }
        if (pointMult == 2)
        {
            score++;
            score++;
            UpdateUI();
        }

    }
   
    private void UpdateUI()
    {
        scoreText.text = score.ToString();
    }
}
