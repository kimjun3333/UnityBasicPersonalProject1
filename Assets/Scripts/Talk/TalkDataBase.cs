using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDataBase : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        CallData();
    }

    private void CallData()
    {
        talkData.Add(1000, new string[] { "�����Ļ�x �����ӱ���, 4�뺸��x ���Ĺ����� ���޼���x �ñ�300�� 24�ð� Ǯ�ٹ� ������ ���ؿ�" , "���� �������̴�."});
        talkData.Add(1100, new string[] { "�����ڸ� �������� �ؾ���." , "�ݰ��� ���ڵ��" });
        talkData.Add(1200, new string[] { "���� õ���." , "���� ������Դϴ�." });
    }
    
    public string GetData(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
