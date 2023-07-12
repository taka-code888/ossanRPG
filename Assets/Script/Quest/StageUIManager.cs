using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton; //ボタンを取得
    public GameObject toTownButton; //ボタンを取得
    //public GameObject stageClearText;
    public GameObject stageClearImage; //クリア画像

    private void Start()
    {
        stageClearImage.SetActive(false);
    }


    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ :{0}", currentStage+1);
    }

    public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText()
    {
        stageClearImage.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}
