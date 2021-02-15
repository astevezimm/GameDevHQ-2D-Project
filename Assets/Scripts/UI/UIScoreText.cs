using TMPro;
using UnityEngine;

public class UIScoreText : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private int _score;
    private int _multiplier = 1;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        EnemySpawnManager.OnEnemyDestroyed += HandleEnemyDestroyed;
        EnemySpawnManager.OnEnemyLeftScreen += HandleEnemyLeftScreen;
        GameManager.OnGameStart += () => gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HandleEnemyDestroyed()
    {
        _score += _multiplier;
        UpdateScoreText();
        _multiplier++;
    }

    private void HandleEnemyLeftScreen()
    {
        _multiplier = 1;
        UpdateScoreText();
    }

    private void UpdateScoreText() => _scoreText.text = $"Score: {_score} (X{_multiplier})";
}