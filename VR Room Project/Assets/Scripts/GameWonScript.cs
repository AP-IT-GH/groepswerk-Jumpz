using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWonScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public void Setup(string winner, int score)
    {
        gameObject.SetActive(true);
        pointsText.text = $"{winner} won with {score.ToString()} score";
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
