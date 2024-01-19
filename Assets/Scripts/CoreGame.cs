using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoreGame : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText; // Question text
    [SerializeField] QuestionSO question; // Reference to the current question
    
    [Header("Buttons")]
    [SerializeField] GameObject[] answerButtons; // Answer buttons
   

    [Header("Score")]
    [SerializeField] private ScoreKeeper scoreKeeper;

    [Header("Images")]
    [SerializeField] Image backGround; // Background image

    [Header("Menus")]
    [SerializeField] GameObject optionsMenu;
    [SerializeField] KeyCode keyCode1 = KeyCode.Escape;
    [SerializeField] private string menuName;

    [Header("Timer")]
    [SerializeField] Timer timer;



    void Start()
    {
        UpdateUI();
               
    }

    private void Update()
    {
        CheckKeys();
    }

    // Called when the player selects an answer
    public void OnAnswerSelect(int index)
    {
        question.SetSelectedChoiceIndex(index); // Set the index of the selected choice
                
        int selectScore = question.GetSelectedChoiceScore();
        
        scoreKeeper.AddScore(selectScore);
               
        QuestionSO nextQuestion = question.GetNextQuestion(); // Get the next question

        if (nextQuestion != null)
        {
            question = nextQuestion; // Set the next question as the current question
            UpdateUI(); // Update the interface with the new question
        }
        else
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.OnEndGame();
            GameOver();
            
        }
        
    }

    // Update the interface based on the current question
    private void UpdateUI()
    {
        backGround.sprite = question.GetBackground(); // Set the background image of the new question
        questionText.text = question.GetQuestion();  // Set the text of the new question
       
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Set the text of the answer buttons based on the choices of the new question
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetChoices(i);

        }
        
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        timer.enabled = false;
    }
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        timer.enabled = true;
    }

    public void CheckKeys()
    {
        if (Input.GetKeyDown(keyCode1))
        {
            if (!optionsMenu.activeSelf)
            {
                OpenOptions();
            }
            else
            {
                CloseOptions();
            }
        }
            
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menuName);
    }
    public void GameOver()
    {
        // Encontrar o objeto EndScreen na cena atual
        EndScreen endScreen = FindObjectOfType<EndScreen>();

        if (endScreen != null && scoreKeeper != null)
        {
            // Define a pontuação final na EndScreen
            endScreen.SetFinalScore(scoreKeeper.GetCurrentScore());
        }

        
    }

   
}
