using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    //[SerializeField]　int point;

    private void OnTriggerEnter(Collider other) 
    {
        //スコアの加算？
        player = GameObject.Find("Player");//プレイヤーを見つける
        pc = player.GetComponent<PlayerController>();//playerControllerを保存する
        pc.score= pc.score + 1;//Playerが持つscoerに対して加算する
        pc.SetCountText();//Playerにスコア更新を依頼
        //pc.SetCountText(point);
        
        Destroy(gameObject);//アタッチされている自分自身を消す
        Destroy(other.gameObject);//ぶつかった相手（other）を消す
    }
}
