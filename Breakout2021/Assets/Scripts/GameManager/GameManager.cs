using System;
using UnityEngine;

namespace Owahu.Breakout.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int HighScore = 0;
        public int Score { get; private set; }
        public int playerStartingLife = 3;
        public int BallsInGame { get; set; }

        public static GameManager Instance;
        private int _scoreMultiplier = 1;
        public int temporaryScoreMultiplier = 0;
        public GameObject ballPrefab;

        [SerializeField] private int PlayerLife = 0;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance != null) return;
            Instance = this;
            Score = 0;
            PlayerLife = playerStartingLife;
            BallsInGame = GameObject.FindGameObjectsWithTag("Ball").Length;
        }

        public static void AddScore(int score)
        {
            Instance.Score += score;
        }

        public void AddScoreMultiplier()
        {
            Instance._scoreMultiplier += 1;
        }

        public void AddScoreToHighScore()
        {
            var score = Instance.Score * Instance._scoreMultiplier;
            if (temporaryScoreMultiplier > 0)
            {
                score *= temporaryScoreMultiplier;
            }

            Instance.HighScore += score;
            Instance.Score = 0;
            Instance._scoreMultiplier = 1;
        }

        public void RemoveLife()
        {
            Instance.PlayerLife--;
            if (Instance.PlayerLife <= 0)
            {
                // TODO: GameOver
            }
        }

        private void FixedUpdate()
        {
            if (Instance.PlayerLife > 0 && Instance.BallsInGame < 1)
            {
                Instantiate(ballPrefab);
                Instance.BallsInGame += 1;
            }

            if (Instance.PlayerLife <= 0)
            {
                ShowGameOverScreen();
            }
        }

        private void ShowGameOverScreen()
        {
        }

        public void AddLife()
        {
            PlayerLife++;
        }

        public bool OnlyOneBallInGame()
        {
            return BallsInGame == 1;
        }
    }
}