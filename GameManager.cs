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
        quiz.Add("���Խ� '((00)*|22)*' �� ���� �νĵǴ� ���ڿ��� �����ΰ�?\n1) 2\n2) 002\n3) 00022\n4) 220000\n5) 00220", 4);
        quiz.Add("�迭 A�� �� ������ �̿��Ͽ� ������������ �����ϰ��� �Ѵ� h�� 4�� �� �˰����� ���� ����� ��Ÿ���ÿ�\n�迭A [0] [1] [2] [3] [4] [5] [6] [7] [8] [9]\n�ʱ�\n������ 20 5 12 17 8 10 4 7 13 2\n", 3);
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