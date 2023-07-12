using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int at;

    //　攻撃する
    public int Attack(EnemyManager enemy)
    {
        int damage = enemy.Damage(at);
        return damage;
        //enemy.Damage(at);
    }

    // ダメージを受ける
    public int Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }

        return damage;

        //Debug.Log("PlayerのHPは" + hp);
    }
}
