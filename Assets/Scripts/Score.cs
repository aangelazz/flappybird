using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI _currentscoreText;
    [SerializeField] private TextMeshProUGUI _highscoreText;

    private int _score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentscoreText.text = _score.ToString();
        _highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        UpdateHighScore();
    }
    // Update is called once per frame

    private void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", _score);
            _highscoreText.text = _score.ToString();
        }
    }
    public void UpdateScore()
    {
        _score++;
        _currentscoreText.text = _score.ToString();
        UpdateHighScore();
    }
}
