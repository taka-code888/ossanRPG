using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

//敵を管理するもの（ステータス/クリック検出）
public class EnemyManager : MonoBehaviour
{
    //関数登録
    Action tapAction;//クリックされたときに実行した関数（外部から設定したい


    public new string name;
    public int hp;
    public int at;
    public GameObject hitEffect;

    //　攻撃する
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
        //player.Damage(at);
    }

    //　ダメージを受ける
    public int Damage(int damage)
    {
        Instantiate(hitEffect, this.transform, false);
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }

        return damage;
        //Debug.Log("EnemyのHPは" + hp);
    }

    //　tapActionに関数を登録する関数を作る
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
       Debug.Log("クリックされた");
       tapAction();
    }
}
