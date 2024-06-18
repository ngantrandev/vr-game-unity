using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class QuizQuestion
{
    public string Question { get; set; }
    public string AnswerA { get; set; }
    public string AnswerB { get; set; }
    public string AnswerC { get; set; }
    public string AnswerD { get; set; }
    public string CorrectAnswer { get; set; }
}

public class QuizReader
{
    public static List<QuizQuestion> ReadQuizFromFile()
    {
        List<QuizQuestion> quiz = new List<QuizQuestion>();
        try
        {
            string[] lines = GameManager.Instance.GetResourceFile<TextAsset>("exam").text.Split("\n");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Q:"))
                {
                    QuizQuestion question = new QuizQuestion();
                    question.Question = lines[i].Substring(3);
                    question.AnswerA = lines[i + 1];
                    question.AnswerB = lines[i + 2];
                    question.AnswerC = lines[i + 3];
                    question.AnswerD = lines[i + 4];
                    question.CorrectAnswer = lines[i + 5];
                    quiz.Add(question);
                    i += 5;
                }
            }
        }
        catch (Exception ex)
        {
            //Console.WriteLine("An error occurred while reading the file: " + ex.Message);
            //Debug.WriteLine("Lỗi nè: "+ex.Message);
        }

        return quiz;
    }
}
