using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // シングルトン
    // ゲーム内に１つしか存在しない物（音を管理する物とか）
    // 利用場所：シーン間でのデータ共有/オブジェクト共有
    // 書き方
  public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   　//--シングルトン終わり--

    public AudioSource audioSourceBGM; //BGMのスピーカー
    public AudioClip[] audioClipsBGM;　//BGMの素材
    //（0:Titele, 1:Town 2:Quest, 3:Battle）

    public AudioSource audioSourceSE; //SEスピーカー
    public AudioClip[] audioClipSE; //鳴らす素材

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();
        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }
        audioSourceBGM.Play();
    }

    public void PlaySE(int index)
    {
        if (index == 2)
        {
            audioSourceSE.volume = 0.2f;
        }
        else
        {
            audioSourceSE.volume = 1f;
        }

        audioSourceSE.PlayOneShot(audioClipSE[index]);
        //SEを一度だけ鳴らす
    }
}
