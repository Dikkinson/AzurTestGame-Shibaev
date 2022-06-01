using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public static ScoreSystem i;
    
    private int _score;
    public int Score 
    { 
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
    }
    private void Awake()
    {
        Score = 0;
        if (!i)
        {
            i = this;
        }else
        {
            Destroy(gameObject);
        }
    }
}
