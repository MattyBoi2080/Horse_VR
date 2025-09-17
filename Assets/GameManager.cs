using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreInText;
    [SerializeField] private TextMeshProUGUI scoreMissText;
    [SerializeField] private TextMeshProUGUI statusText;

    [Header("Counters")]
    [SerializeField] private int ballsIn = 0;
    [SerializeField] private int ballsNotIn = 0;

    [Header("HORSE Settings")]
    [SerializeField] private string[] horseSteps = new string[] { "H", "HO", "HOR", "HORS", "HORSE" };
    [SerializeField] private int maxMissesToLose = 5;

    [Header("Ball Reset (optional)")]
    [SerializeField] private Transform ballSpawn;
    [SerializeField] private Rigidbody ballRb;

    public bool IsGameOver { get; private set; } = false;

    public GameObject Ball;
    public GameObject Net;
    public TextMeshPro ScoreBoard;
    int PlayerScore = 0;

    void Start()
    {
        UpdateUI();
        if (statusText) statusText.text = "";

        Ball = GetComponent<GameObject>();
        Net = GetComponent<GameObject>();
    }

    void Update()
    {
        Debug.Log("Score: " + PlayerScore);
        ScoreBoard.text = "Score: " + PlayerScore.ToString();
        scoreInText.text = "In: " + PlayerScore.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore++;
    }

    public void RegisterScore()
    {
        if (IsGameOver) return;
        ballsIn++;
        UpdateUI();
        ResetBallIfAssigned();
    }

    public void RegisterMiss()
    {
        if (IsGameOver) return;
        ballsNotIn++;
        UpdateUI();

        if (ballsNotIn >= maxMissesToLose)
        {
            IsGameOver = true;
            if (statusText)
                statusText.text = $"You Lose! High Score: {ballsIn}";
        }

        ResetBallIfAssigned();
    }

    private void UpdateUI()
    {
        if (scoreInText) scoreInText.text = $"In: {ballsIn}";

        string letters = "";
        if (ballsNotIn > 0)
        {
            int idx = Mathf.Clamp(ballsNotIn - 1, 0, horseSteps.Length - 1);
            letters = horseSteps[idx];
        }
        if (scoreMissText) scoreMissText.text = $"Miss: {letters}";
    }

    private void ResetBallIfAssigned()
    {
        if (ballRb != null && ballSpawn != null)
        {
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            ballRb.transform.position = ballSpawn.position;
            ballRb.transform.rotation = ballSpawn.rotation;
        }
    }
}




