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
        talkData.Add(1000, new string[] { "복리후생x 포괄임금제, 4대보험x 숙식미제공 주휴수당x 시급300원 24시간 풀근무 개발자 구해요" , "나는 류동균이다."});
        talkData.Add(1100, new string[] { "전공자면 나정도는 해야지." , "반갑다 감자들아" });
        talkData.Add(1200, new string[] { "나는 천재다." , "나는 문장원입니다." });
    }
    
    public string GetData(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
