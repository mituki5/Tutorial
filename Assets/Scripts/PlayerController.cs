using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//食べ物プレハブ（あとで複製）
    [SerializeField] private Text scoreText;
    [SerializeField] private Text winText;
    public int score = 0;//スコア。ほんとはよくないけどPublicにします。
    //[SerializeField] Text scoreText;//スコア表示用Text

    private void Start()
    {
        SetCountText();
        winText.text = "";
        //SetCountText(0);//初期化
        }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput 
                * Time.deltaTime * speed);
        if(transform.position.x < -xRange) {
            transform.position = new Vector3(   -xRange, 
                                                transform.position.y,
                                                transform.position.z);
        }
        if(xRange < transform.position.x ) {
            transform.position = new Vector3(   xRange,
                                                transform.position.y,
                                                transform.position.z);
        }
        //スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space)) {
            //ここで食べ物を複製する（この使い方、というかメソッド名覚えて！）
            Instantiate(    projectilePrefab, 
                            transform.position,
                            projectilePrefab.transform.rotation);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            score = score + 1;
            SetCountText();
        }
    }
    
    public void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString();
        if (score >= 6)
        {
            winText.text = "You Win!";
        }
    }

    //内部的なscoreをUI更新させる
    //public void SetCountText(int point)
    //{
    //    score += point;//動物からもらったpointを自分のスコアに加算する
    //    scoreText.text = "Score" + score.ToString();//【重要】UI更新
    //}
}
