using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    private GameObject player;
    private PlayerController pc;
    //[SerializeField]�@int point;

    private void OnTriggerEnter(Collider other) 
    {
        //�X�R�A�̉��Z�H
        player = GameObject.Find("Player");//�v���C���[��������
        pc = player.GetComponent<PlayerController>();//playerController��ۑ�����
        pc.score= pc.score + 1;//Player������scoer�ɑ΂��ĉ��Z����
        pc.SetCountText();//Player�ɃX�R�A�X�V���˗�
        //pc.SetCountText(point);
        
        Destroy(gameObject);//�A�^�b�`����Ă��鎩�����g������
        Destroy(other.gameObject);//�Ԃ���������iother�j������
    }
}
