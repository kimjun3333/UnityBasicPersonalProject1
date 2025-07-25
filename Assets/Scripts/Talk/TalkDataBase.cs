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
        talkData.Add(1000, new string[] { "�����Ļ�x �����ӱ���, 4�뺸��x ���Ĺ����� ���޼���x �ñ�300�� 24�ð� Ǯ�ٹ� ������ ���ؿ�" , "������ �ٽ� ���� �ɾ��� ����Ʈ����."});
        talkData.Add(1010, new string[] { "����Ʈ�� Ŭ�����ߴܴ�"});
        talkData.Add(1100, new string[] { "�����ڸ� �������� �ؾ���." , "�ݰ��� ���ڵ��" });
        talkData.Add(1200, new string[] { "���̿�" , "�ȳ��ϼ��� �ݰ����ϴ�." });
        talkData.Add(1300, new string[] { "���̿�", "�ȳ��ϼ��� �ݰ����ϴ�." });
        talkData.Add(1400, new string[] { "������ �Դϴ�.", "���̷�" });

    }
    
    public string GetData(int id, int talkIndex)
    {
        if(talkData.ContainsKey(id) && talkIndex < talkData[id].Length)
        {
            return talkData[id][talkIndex];
        }


        return null;
    }
}
