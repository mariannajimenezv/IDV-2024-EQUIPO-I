using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreService
{
    public int winScore = 10;
    private int score = 0;

    private void Awake()
    {
        ServiceLocator.Register<IScoreService>(this);
    }

    public void AddPoint()
    {
        score++;
        Debug.Log($"Score: {score}/{winScore}");

        if (HasWon())
        {
            GameManager.Instance.WinLevel();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public bool HasWon()
    {
        return score >= winScore;
    }
}
