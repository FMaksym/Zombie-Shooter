using TMPro;
using UnityEngine;


public class ResultsAfteDeath : MonoBehaviour
{
    [Header("Score in Lose Panel")]
    [SerializeField] private TMP_Text _lastScoreText;
    [SerializeField] private TMP_Text _recordScoreText;
    [SerializeField] private TMP_Text _addCoinsText;

    [SerializeField] private int _lastScore;
    [SerializeField] private int _recordScore;
    [SerializeField] private int _amountAddCoins;

    [SerializeField] private Score Score;
    [SerializeField] private ScoreInGame ScoreInGame;

    private int coins;

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    private void Start()
    {
        _lastScore = ScoreInGame._score;
        _recordScore = Score.RecordScore;
        _amountAddCoins = _lastScore / 20;

        coins += _amountAddCoins;

        PlayerPrefs.SetInt("Coins", coins);

        _recordScoreText.text = _recordScore.ToString();
        _lastScoreText.text = _lastScore.ToString();
        _addCoinsText.text = _amountAddCoins.ToString();

        if (_lastScore > _recordScore)
        {
            _recordScoreText.text = _lastScore.ToString();
            PlayerPrefs.SetInt("Record Score", _lastScore);
        }

        //ScoreResult(_lastScore, _recordScore);
    }

    public void ScoreResult(int score, int record)
    {
        AddScoreInResult(score);
        AddRecordScoreInResult(score, record);
    }

    public void AddScoreInResult(int score)
    {
        int scoreResult = 0;

        while (scoreResult <= score)
        {
            scoreResult += 5;
            if (scoreResult > score)
            {
                scoreResult = score;
            }
            _lastScoreText.text = scoreResult.ToString();
        }
        //PlayerPrefs.SetInt("Last Score", score);
    }

    public void AddRecordScoreInResult(int score, int recordScore)
    {
        int recordScoreResult = recordScore;

        while (recordScoreResult <= score)
        {
            recordScoreResult += 5;
            if (recordScoreResult > score)
            {
                recordScoreResult = score;
            }
            _recordScoreText.text = recordScoreResult.ToString();
        }
        
    }
}
