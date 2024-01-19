using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 7)]
    [SerializeField] string question = "Enter new question here";
    [SerializeField] string[] choices = new string[4];
    [SerializeField] int selectedChoiceIndex; // Index of the selected choice
    [SerializeField] QuestionSO[] choiceQuestion; // Array of QuestionSOs for the next questions
    [SerializeField] int[] choiceScores; // Array to hold scores for each choice
    [SerializeField] Sprite BG;


    public string GetQuestion()
    {
        return question; // Returns the text of the question
    }

    public string GetChoices(int index)
    {
        return choices[index]; // Returns the text of the choice at the specified index
    }
        
   
    // Sets the index of the selected choice
    public void SetSelectedChoiceIndex(int index)
    {
        selectedChoiceIndex = index;
    }

    public int GetSelectedChoiceIndex()
    {
        return selectedChoiceIndex; // Returns the index of the selected choice
    }

   
    // Returns the score associated with the selected choice
    public int GetSelectedChoiceScore()
    {
        if(selectedChoiceIndex >= 0 && selectedChoiceIndex < choiceScores.Length)
        {
            return choiceScores[selectedChoiceIndex];
        }
        else
        {
            Debug.LogWarning("SelectedChoiceIndex is out of bounds.");
            return 0;
        }

    }

    // Returns the next question based on player's choice
    public QuestionSO GetNextQuestion()
    {
        

        if (selectedChoiceIndex >= 0 && selectedChoiceIndex < choiceQuestion.Length)
        {
            return choiceQuestion[selectedChoiceIndex];
        }
        else
        {
            
            Debug.LogWarning("SelectedChoiceIndex is out of bounds.");
            return null;
            
        }
    }

    // Returns the background image
    public Sprite GetBackground()
    {
        return BG;
    }

   
}
