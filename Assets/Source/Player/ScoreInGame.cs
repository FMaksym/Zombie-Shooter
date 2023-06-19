using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using TMPro;

public class ScoreInGame : MonoBehaviour
{
    [Header("Score in Game")]
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] public int _score;
    [SerializeField] private int _recordScore;

    private Score Score;

    private void Awake()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    private void FixedUpdate()
    {
        _scoreText.text = _score.ToString();
    }

    public void AddScore(int amountAddScore)
    {
        _score += amountAddScore; 
    }
}
