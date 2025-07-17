using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class StageScrollViewController : MonoBehaviour
{
    [SerializeField] private int maxStage;
    [SerializeField] private RectTransform contentRectTransform;
    [SerializeField] private GameObject stagePrefab;
    private List<StageButtonController> stages;
    
    
    void Start()
    {
        var contentHeight = ContentHeightSize();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, contentHeight);
        InitStage();
    }
    
    //스테이지 클릭시 호출
    private void StartStage(int stageIndex)
    {
        //todo: 스테이지 이동
        Debug.Log($"StartStage: {stageIndex}");
    }
    //나가기 버튼 클릭
    public void OnClickQuit()
    {
        Destroy(gameObject);
    }

    //스크롤뷰 콘텐트 높이 계산
    private float ContentHeightSize()
    {
        var contentHeight = (maxStage/6) * 110 + 50;
        if (maxStage%6 > 0)
        {
            contentHeight += 110;
        }
        return contentHeight;
    }

    //스테이지 초기화
    private void InitStage()
    {
        stages = new List<StageButtonController>();
        for (int i = 0; i < maxStage; i++)
        {
            stages.Add(Instantiate(stagePrefab,contentRectTransform).GetComponent<StageButtonController>());
            stages[i].InitButton(i,Enums.StarState.Empty,true);
            stages[i].OnClickStage = StartStage;
            //todo: 스테이지 정보 저장 및 불러오기 필요
        }
    }
    
}