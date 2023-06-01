using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Slider playerHealthSlider; // 플레이어 체력을 나타낼 슬라이더
    public Text remainingQuizText; // 남은 문제 수를 나타낼 텍스트
    public Text monsterHealthText; // 몬스터 체력을 나타낼 텍스트
    public Text quizProblemText; // 퀴즈 문제를 나타낼 텍스트

    private static UImanager m_instance;

    public static UImanager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UImanager>();
            }
            return m_instance;
        }
    }

    public void ShowAnswerResult(bool isCorrect)
    {
        // 정답 결과에 따른 처리 로직
        // 예시로 정답 여부에 따라 텍스트와 색상을 변경하는 로직을 구현
        if (isCorrect)
        {
            // 정답이 맞으면 문제 텍스트의 색상을 변경
            quizProblemText.color = Color.green;
        }
        else
        {
            // 정답이 틀리면 문제 텍스트의 색상을 변경
            quizProblemText.color = Color.red;
        }
    }

    public void UpdatePlayerHealthUI(float healthRatio)
    {
        playerHealthSlider.value = healthRatio;
    }

    public void UpdateRemainingQuizUI(int remainingQuizCount)
    {
        remainingQuizText.text = "Remaining Quiz: " + remainingQuizCount.ToString();
    }

    public void UpdateMonsterHealthUI(float monsterHealth)
    {
        monsterHealthText.text = "Monster Health: " + monsterHealth.ToString();
    }

    public void UpdateProblemText(string quizProblem)
    {
        quizProblemText.text = quizProblem;

        // 문제가 바뀔 때마다 문제 텍스트의 색상을 초기화
        quizProblemText.color = Color.white;
    }
}