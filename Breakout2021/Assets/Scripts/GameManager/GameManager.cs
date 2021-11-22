using UnityEngine;

namespace Owahu.Breakout.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int HighScore = 0;
        public int Score { get; private set; }
        public int playerStartingLife = 3;

        public static GameManager Instance;
        private int _scoreMultiplier = 1;

        [SerializeField]
        private int PlayerLife = 0;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance != null) return;
            Instance = this;
            Score = 0;
            PlayerLife = playerStartingLife;
        }

        // Update is called once per frame
        void Update()
        {
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
            Instance.HighScore += Instance.Score * Instance._scoreMultiplier;
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

        public void AddLife()
        {
            PlayerLife++;
        }
    }
}