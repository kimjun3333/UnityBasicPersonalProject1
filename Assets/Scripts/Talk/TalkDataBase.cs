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
        talkData.Add(1000, new string[] { "복리후생x 포괄임금제, 4대보험x 숙식미제공 주휴수당x 시급300원 24시간 풀근무 개발자 구해요" , "나한테 다시 말을 걸어줘 퀘스트란다."});
        talkData.Add(1010, new string[] { "퀘스트를 클리어했단다"});
        talkData.Add(1100, new string[] { "전공자면 나정도는 해야지." , "반갑다 감자들아" });
        talkData.Add(1200, new string[] { "하이염" , "안녕하세요 반갑습니다." });
        talkData.Add(1300, new string[] { "하이염", "안녕하세요 반갑습니다." });
        talkData.Add(1400, new string[] { "젊은피 입니다.", "하이룰" });

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
