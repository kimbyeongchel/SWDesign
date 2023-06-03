using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public Dictionary<string, int> problem = new Dictionary<string, int>();
    public Dictionary<string, int> selectedProblems = new Dictionary<string, int>();
    public List<string> problemKeys = new List<string>();

    public void AddProblem()
    {
        problem.Add("�� ���� ũ�Ⱑ ������ ���� ��, Hufman �˰��� ���� ���� Ʈ���� ���̸� x, �ּ� ���� ����� y��� ����. x + y�� ���� ���ΰ�?\n\n���� ũ��: 2, 4, 7, 8, 12", 76);
        problem.Add("2-3-4 Ʈ������ \"q = ���� ����� �� / ��ü ��� ��\"�� ���ǵȴ�. ���� ���, depth�� 2�̸� ��Ʈ ��尡 2-����� ���, q = 2 / 3 �̴�. depth�� 3�� 2-3-4 Ʈ������ q�� �ִ밪�� ���ΰ�?(���ںи������ �������� ex.12 = 1/2)", 1621);
        problem.Add("���� �� �ؽ�Ʈ ���Ͽ��� �ܾ��� �󵵼��� �����ϱ⿡ ���� ������ ������ �����ΰ�?\n1) HashMap<String, Integer>\n2) TreeMap<String, Integer>\n3) ArrayList<String>\n4) PriorityQueue<String>\n5) HashSet<String, Integer>\r\n", 1);
        problem.Add("�迭�� �� ������ �̿��Ͽ� ������������ �����ϰ��� �Ѵ�. h = 4�϶�, �����?\n�ʱⰪ [0] [1] [2] [3] [4] [5] [6] [7] [8] [9]\n \t\t\t\t20  5 12 17  8  10  4   7 13  2\n([2], [6], [8] ���� ������� �ۼ�)", 41220);
        problem.Add("Ű ���� �Էµ� �� �����Ǵ� Ʈ���� �׸�����(level ������ ������� ����)\n8->9->10->1->2", 921018);
        problem.Add("���� ���� Ű�� ���� �ؽ� �Լ� ���� ���� ����� �ּҰ� �Ʒ��� �ִ�. ��� Ž�� �Ÿ���?\n�ؽ���      A:1 B:1 C:2 D:2 E:3 F:2\n�����ּ� A:1 B:2 C:3 D:4 E:5 F:6\n(ex.1/2 = 12)", 83);
        problem.Add("���� �� ���� ���� �ؽ� �Լ��� �̿��Ͽ� �ؽ��� �����ϴ� �˰����� ��� �����Ͻÿ�\n1) Linear probing\n2) Separate chaining\n3) Quadratic probing\n4) Double hashing\n5) Cuckoo hashing", 45);
        problem.Add("�Ʒ� ���Ͽ� ���� NFA�� �̵����� ���� ���϶�\n((A|B)|C*))", 12);
        problem.Add("���� AABCA�� ���� DFA�� �ۼ��ϰ� (��), (��)�� �����ÿ�(1,2 -> 12)\n\rA A B C A\nA 1 2 2 1 5\nB 0 0 �� 0 0\nC 0 �� 0 4 0", 30);
        problem.Add("���� �� �÷����� contains() �ð����⵵�� ���� ���� ����?(�ڹ�)\n1) List\n2) Set\n3) TreeMap\n4) ArrayList\n5) TreeSet", 2);
    }

    public void SelectRandomProblems(int count)
    {
        selectedProblems.Clear();

        List<string> keing = new List<string>(problem.Keys);

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, keing.Count);
            string selectedProblem = keing[randomIndex];
            int selectedAnswer = problem[selectedProblem];

            selectedProblems.Add(selectedProblem, selectedAnswer);
            keing.RemoveAt(randomIndex);
        }
                
        foreach(string prob in selectedProblems.Keys)
        {
            problemKeys.Add(prob);
        }

    }
}
