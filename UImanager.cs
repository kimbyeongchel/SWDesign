using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Slider playerHealthSlider; // �÷��̾� ü���� ��Ÿ�� �����̴�
    public Text remainingQuizText; // ���� ���� ���� ��Ÿ�� �ؽ�Ʈ
    public Text monsterHealthText; // ���� ü���� ��Ÿ�� �ؽ�Ʈ
    public Text quizProblemText; // ���� ������ ��Ÿ�� �ؽ�Ʈ

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
        // ���� ����� ���� ó�� ����
        // ���÷� ���� ���ο� ���� �ؽ�Ʈ�� ������ �����ϴ� ������ ����
        if (isCorrect)
        {
            // ������ ������ ���� �ؽ�Ʈ�� ������ ����
            quizProblemText.color = Color.green;
        }
        else
        {
            // ������ Ʋ���� ���� �ؽ�Ʈ�� ������ ����
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

        // ������ �ٲ� ������ ���� �ؽ�Ʈ�� ������ �ʱ�ȭ
        quizProblemText.color = Color.white;
    }
}