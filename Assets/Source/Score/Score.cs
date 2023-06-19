using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _lastScore;
    private int _recordScore;

    public int LastScore
    {
        get => _lastScore;
        set { }
    }

    public int RecordScore
    {
        get => _recordScore;
        set
        {
            if (_lastScore > _recordScore)
            {
                _recordScore = _lastScore;
                PlayerPrefs.SetInt("Record Score", _lastScore);
            }
        }
    }

    private void Start()
    {
        _recordScore = PlayerPrefs.GetInt("Record Score");
    }
}
