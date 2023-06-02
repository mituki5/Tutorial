using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed;
    [SerializeField] private float xRange;
    [SerializeField] private GameObject projectilePrefab;//�H�ו��v���n�u�i���Ƃŕ����j
    [SerializeField] private Text scoreText;
    [SerializeField] private Text winText;
    public int score = 0;//�X�R�A�B�ق�Ƃ͂悭�Ȃ�����Public�ɂ��܂��B
    //[SerializeField] Text scoreText;//�X�R�A�\���pText

    private void Start()
    {
        SetCountText();
        winText.text = "";
        //SetCountText(0);//������
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
        //�X�y�[�X�L�[�������ꂽ��
        if(Input.GetKeyDown(KeyCode.Space)) {
            //�����ŐH�ו��𕡐�����i���̎g�����A�Ƃ��������\�b�h���o���āI�j
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

    //�����I��score��UI�X�V������
    //public void SetCountText(int point)
    //{
    //    score += point;//��������������point�������̃X�R�A�ɉ��Z����
    //    scoreText.text = "Score" + score.ToString();//�y�d�v�zUI�X�V
    //}
}
