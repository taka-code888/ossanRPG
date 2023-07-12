using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;//生成するプレファブ
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;//シーン遷移を管理するもの
    public GameObject questBG;

    //敵に遭遇するテーブル；−１なら遭遇しない、０なら遭遇
    int[] encountTable = { -1, -1, 0, -1, 0, -1 };

    int currentStage = 0;//現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] { "迷いの森のようだ" });
    }


    IEnumerator Seaching()
    {
        //　背景を大きく
        questBG.transform.DOScale(new Vector3(2f, 2f, 2f), 2f)
            .OnComplete(() => questBG.transform.localScale
            = new Vector3(1.2f, 3.2f, 1));

        // フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent
            <SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        // 2秒間処理を待機する
        yield return new WaitForSeconds(2f);

        currentStage++;

        //進行度をUIに反映
        stageUI.UpdateUI(currentStage);

        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();
        }

        else if (encountTable[currentStage] == 0)//０なら遭遇
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }
    //Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        StartCoroutine(Seaching());
        DialogTextManager.instance.SetScenarios(new string[] { "探索中・・・" });

    }
    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] { "かまを持った、おっさんに出会った" });

        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons(); //ここ！
    }

    void QuestClear()
    {
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        DialogTextManager.instance.SetScenarios(new string[] { "クリアー！！" });
        //クエストクリアと表示する
        //街に戻るボタンのみ表示する
        stageUI.ShowClearText();

        //sceneTransitionManager.LoadTo("Town");//シーン遷移
    }
}
