using System;
using UnityEngine;

public enum Side
{
    Orange,
    Blue
}

public class Game : MonoBehaviour
{
    public static Game instance;

    [Serializable]
    public struct TeamData
    {
        public int Score;
        public GameObject Player;
        public GameObject ScoreContainer;
    }

    
    public GameObject Ball;
    public TeamData Orange;
    public TeamData Blue;

    public GameObject GameOverText;
    public GameObject GoalText;

    private GameObject B;
    private float nextReset = Mathf.Infinity;

    void Start()
    {
        instance = this;
        B = Instantiate(Ball);
        ResetPosition();
    }

    private void ResetPosition()
    {
        GameOverText.SetActive(false);
        GoalText.SetActive(false);
        var ballBody = B.GetComponent<Rigidbody2D>();
        ballBody.position = Vector2.zero;
        ballBody.velocity = Vector2.zero;
        ballBody.bodyType = RigidbodyType2D.Dynamic;
        Orange.Player.GetComponent<Rigidbody2D>().position = Vector2.zero + Vector2.left * 3;
        Blue.Player.GetComponent<Rigidbody2D>().position = Vector2.zero + Vector2.right * 3;
    }

    private void FreezePosition()
    {
        B.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        B.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Update()
    {
        nextReset -= Time.deltaTime;
        if (nextReset < 0)
        {
            ResetPosition();
            nextReset = Mathf.Infinity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var instance = Instantiate(Ball);
        }
    }

    public void RecordGoal(Side side)
    {
        Side scored = Side.Blue;
        if (side == Side.Orange)
        {
            FreezePosition();
            Blue.Score++;
            if (Blue.ScoreContainer.transform.childCount > Blue.Score - 1)
            {
                Blue.ScoreContainer.transform.GetChild(Blue.Score - 1).gameObject.SetActive(true);
            }
        }
        if (side == Side.Blue)
        {
            FreezePosition();
            Orange.Score++;
            if (Orange.ScoreContainer.transform.childCount > Orange.Score - 1)
            {
                Orange.ScoreContainer.transform.GetChild(Orange.Score - 1).gameObject.SetActive(true);
            }
            scored = Side.Orange;
        }
        if (Orange.Score < 5 && Blue.Score < 5)
        {
            GoalText.SetActive(true);
            GoalText.GetComponent<TextMesh>().text = "But !\n" + scored.ToString() + " marque !";
        }
        else
        {
            GoalText.SetActive(false);
            GameOverText.SetActive(true);
            GameOverText.GetComponent<TextMesh>().text = "Fin de partie !\n" + scored.ToString() + " gagne !";
            Blue.Score = 0;
            Orange.Score = 0;
            foreach (Transform s in Orange.ScoreContainer.transform) s.gameObject.SetActive(false);
            foreach (Transform s in Blue.ScoreContainer.transform) s.gameObject.SetActive(false);
        }
        nextReset = 3f;
    }
}
