using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevateCube : MonoBehaviour
{
    public Button clickButton; // UI ��ư
    public GameObject elevateCube; // �̵��� ���� ������Ʈ

    public float moveSpeed = 0.1f; // �̵� �ӵ�, ���� ������ ����
    public float moveDistanceLimit = 0.2f; // �̵� �Ÿ� ����, ���� ������ ����

    private bool isMoving = false; // �̵� ������ ���θ� Ȯ���ϴ� �÷���
    private float moveDistance = 0f; // ���� �̵��� �Ÿ� ����
    private float moveDirection = 1f; // �̵� ���� (1�� ����, -1�� �Ʒ���)

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        clickButton.onClick.AddListener(MoveBGameObject);
    }

    void Update()
    {
        // �̵� ������ �� �̵� ó��
        if (isMoving)
        {
            // elevateCube�� Y������ moveDirection �������� moveSpeed�� �ӵ��� �̵�
            float moveStep = moveSpeed * Time.deltaTime * moveDirection;
            elevateCube.transform.Translate(0, moveStep, 0);

            // �̵��� �Ÿ� ������Ʈ
            moveDistance += Mathf.Abs(moveStep); // �̵� �Ÿ��� ����� ���

            // �̵� �Ÿ��� moveDistanceLimit �̻��̸� �̵� ����
            if (moveDistance >= moveDistanceLimit)
            {
                isMoving = false;
                moveDistance = 0f; // ���� �̵��� ���� �Ÿ� �ʱ�ȭ
                moveDirection *= -1f; // ���� �̵� ���� ��ȯ
            }
        }
    }

    void MoveBGameObject()
    {
        if (!isMoving) // �̵� ���� �ƴ� ���� ����
        {
            moveDistance = 0f; // �̵��� �Ÿ� �ʱ�ȭ
            isMoving = true;
        }
    }
}
