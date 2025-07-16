using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScrollViewController : MonoBehaviour
{
    [SerializeField] private int maxStage;
    [SerializeField] private RectTransform contentRectTransform;
    
    
    void Start()
    {
        var contentHeight = ContentHeightSize();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, contentHeight);
    }

    private float ContentHeightSize()
    {
        var contentHeight = (maxStage/6) * 110 + 60;
        if (maxStage%6 > 0)
        {
            contentHeight += 110;
        }
        return contentHeight;
    }
    
}
