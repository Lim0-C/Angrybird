using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonController : MonoBehaviour
{
    [SerializeField] private Image[] starImages;    //0: 중앙별, 1: 좌측별, 2: 우측별
    [SerializeField] private GameObject stars;
    [SerializeField] private Sprite[] starSprites; //0: 공별, 1: 별
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private GameObject lockImg;
    
    private int _stageIndex;
    private bool _isActive;
    private Enums.StarState _starState;

    public Action<int> OnClickStage;

    //상태 초기화
    public void InitButton(int stageIndex, Enums.StarState starState, bool isActive)
    {
        _stageIndex = stageIndex;
        _starState = starState;
        _isActive = isActive;
        var stageLevel = _stageIndex + 1;
        stageText.text = stageLevel.ToString();
        //None상태(아직 클리어하진 않은 상태)를 위해 함수 호출순서 고정
        UpdateActive();
        UpdateStarSprite();
    }
    
    
    //버튼 클릭
    public void OnClickStageButton()
    {
        OnClickStage?.Invoke(_stageIndex);
    }

    //스테이트 변경
    public void SetStarSprite(Enums.StarState starState)
    {
        _starState = starState;
        UpdateStarSprite();
    }

    //활성화 업데이트
    public void UpdateActive()
    {
        gameObject.GetComponent<Image>().color = _isActive ? Color.white : Color.gray;
        gameObject.GetComponent<Button>().interactable = _isActive;
        stars.SetActive(_isActive);
        lockImg.SetActive(!_isActive);
    }

    //별스테이트를 기반으로 별표시
    public void UpdateStarSprite()
    {
        stars.SetActive(true);
        switch (_starState)
        {
            case Enums.StarState.None:
                stars.SetActive(false);
                break;
            case Enums.StarState.Empty:
                foreach (var starImage in starImages)
                {
                    starImage.sprite = starSprites[0];
                }
                break;
            case Enums.StarState.One:
                starImages[0].sprite = starSprites[1];
                starImages[1].sprite = starSprites[0];
                starImages[2].sprite = starSprites[0];
                break;
            case Enums.StarState.Two:
                starImages[0].sprite = starSprites[1];
                starImages[1].sprite = starSprites[1];
                starImages[2].sprite = starSprites[0];
                
                break;
            case Enums.StarState.Three:
                foreach (var starImage in starImages)
                {
                    starImage.sprite = starSprites[1];
                }
                break;
        }
    }
}
