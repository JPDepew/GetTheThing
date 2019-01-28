using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMaster : MonoBehaviour
{
    public Text score;

    void Start()
    {
        if (Data.Instance != null)
        {
            float finalScore = Data.Instance.numberOfObjects;
            string scoreText = "Final Score: ";
            if (finalScore == 0)
            {
                scoreText = "This is actually impressive. Score: ";
            }
            else if (finalScore < 9)
            {
                scoreText = "Why are you even trying? Score: ";
            }
            else if (finalScore < 15)
            {
                scoreText = "Um, what was that? Score: ";
            }
            else if(finalScore < 25)
            {
                scoreText = "I wasn't going to say anything, but this is pretty bad. Score: ";
            }
            else if(finalScore < 35)
            {
                scoreText = "Final score (Not very good): ";
            }
            else if(finalScore > 55 && finalScore < 100)
            {
                scoreText = "You're not half bad! Score: ";
            }
            else if(finalScore >= 100)
            {
                scoreText = "I bow to you, human. Score: ";
            }
            score.text = scoreText + finalScore.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Data.Instance.numberOfObjects = 0;
            SceneManager.LoadScene(1);
        }
    }
}
