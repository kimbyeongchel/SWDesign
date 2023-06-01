using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private string currentProblem;
    private Dictionary<string, int> quiz = new Dictionary<string, int>();
    private Dictionary<string, int> select = new Dictionary<string, int>();

    void Start()
    {
        quiz.Add("정규식 '((00)*|22)*' 에 의해 인식되는 문자열은 무엇인가?\n1) 2\n2) 002\n3) 00022\n4) 220000\n5) 00220", 4);
        quiz.Add("배열 A를 쉘 정렬을 이용하여 오름차순으로 정렬하고자 한다 h가 4일 때 알고리즘의 실행 결과를 나타내시오\n배열A [0] [1] [2] [3] [4] [5] [6] [7] [8] [9]\n초기\n데이터 20 5 12 17 8 10 4 7 13 2\n", 3);
        quiz.Add("hi", 4);
        quiz.Add("hdi", 4);
        quiz.Add("hid", 4);
        quiz.Add("hias", 4);
        quiz.Add("hidg", 4);
        quiz.Add("hiew", 4);
        quiz.Add("hiq", 4);
        quiz.Add("hiee", 4);

        MakeQuiz();
        StartQuiz();
    }

    public void StartQuiz()
    {
        currentProblem = GetQuizProblem();
        UImanager.Instance.UpdateProblemText(currentProblem);
    }

    private string GetQuizProblem()
    {
        string problem = select.Keys.ElementAt(0);
        return problem;
    }

    public void AnswerSelected(int selectedAnswer)
    {
        int correctAnswer = select[currentProblem];
        if (selectedAnswer == correctAnswer)
        {
            UImanager.Instance.ShowAnswerResult(true);
            ReduceMonsterHealth(Random.Range(20, 41));
        }
        else
        {
            UImanager.Instance.ShowAnswerResult(false);
            ReducePlayerHealth(1);
        }

        select.Remove(currentProblem);
        currentProblem = GetQuizProblem();
        if (currentProblem != null)
        {
            UImanager.Instance.UpdateProblemText(currentProblem);
        }
    }

    public void MakeQuiz()
    {
        select.Clear();
        int quizCount = 5;

        List<string> quizKeys = new List<string>(quiz.Keys);

        for (int i = 0; i < quizCount; i++)
        {
            int randomIndex = Random.Range(0, quizKeys.Count);
            string problem = quizKeys[randomIndex];
            int answer = quiz[problem];

            select.Add(problem, answer);

            quizKeys.RemoveAt(randomIndex);
        }
    }

    public void ReduceMonsterHealth(int damage)
    {
        Monster.Instance.TakeDamage(damage);
        UImanager.Instance.UpdateMonsterHealthUI(Monster.Instance.health);
    }

    public void ReducePlayerHealth(int damage)
    {
        Player.Instance.TakeDamage(damage);
        UImanager.Instance.UpdatePlayerHealthUI(Player.Instance.health);
    }
}