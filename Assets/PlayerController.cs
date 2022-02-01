using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 6.0f;

    private int ItemCount;

    private Vector3 Player_pos; //�v���C���[�̃|�W�V����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎��
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputY + Camera.main.transform.right * inputX;

        moveForward *= speed;

        if (moveForward.magnitude > 0.01f) //�x�N�g���̒�����0.01f���傫���ꍇ�Ƀv���C���[�̌�����ς��鏈��������(0�ł͓���Ȃ��̂Łj
        {
            this.transform.Translate(moveForward * Time.deltaTime * speed);
            Quaternion targetRotation = Quaternion.LookRotation(moveForward);  //�x�N�g���̏���Quaternion.LookRotation�Ɉ����n����]�ʂ��擾���v���C���[����]������
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }

        Player_pos = transform.position; //�v���C���[�̈ʒu���X�V
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            ItemCount++;
            Destroy(other.gameObject);
            // 取得したアイテムの数をConsoleに表示する
            Debug.Log("取ったアイテムの数:" + ItemCount);
        }

        if (other.gameObject.tag == "bridge" && ItemCount > 0)
        {
            ItemCount--;
            other.transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
