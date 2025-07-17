using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject stagePanelPrefab;
    [SerializeField] private RectTransform canvasTrans;
    public void OnClickStartButton()
    {
        //todo: 스테이지 목록UI 표시
        Debug.Log("스테이지 목록UI 표시");
        var stagePanel= Instantiate(stagePanelPrefab, canvasTrans);
    }

    public void OnClickSettingsButton()
    {
        //todo: 설정화면UI 표시
        Debug.Log("설정UI 표시");
    }
}