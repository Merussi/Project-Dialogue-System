using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    //ScoreKeeper scoreKeeper;
    [SerializeField] private string menuName;
    [SerializeField] Button exitToMenu;

    private void Awake()
    {
       // scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        
       // ShowFinalScore();
        
    }

    // public void ShowFinalScore()
    // {
    //     finalScore.text = "Seu aproveitamento foi de " + scoreKeeper.GetCurrentScore() + " pontos.";

    // }
    public void SetFinalScore(int score)
    {
        finalScore.text = "Seu aproveitamento foi de " + score + " pontos.";
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menuName);
    }
}
