using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpeedMoving : MonoBehaviour
{
    public Button buttonToClick; // Ŭ���ϴ� ��ư
    public Image lightImage; // ���<->������ �̹��� (��ư�� �� Ŭ���Ǿ����� Ȯ���ϴ� �뵵)
    public GameObject upperCube; // �� ť��
    public GameObject lowerCube; // �Ʒ� ť��
    public float speed = 0.1f; // lowerCube�� �̵� �ӵ�
    public float distance = -0.3f; // upperCube�� lowerCube ������ �Ÿ�

    private bool isRed = false; // lightImage �� ��ȭ ����
    private Vector3 initialLowerCubePosition; // �ʱ� �Ʒ� ť�� ��ġ
    private bool isLowerCubeMoved = false; // �Ʒ� ť�� ������ ����

    void Start()
    {
        buttonToClick.onClick.AddListener(HandleButtonClick);
        initialLowerCubePosition = lowerCube.transform.position;
    }

    void Update()
    {
        if (isLowerCubeMoved)
        {
            Vector3 targetPosition = new Vector3(lowerCube.transform.position.x, upperCube.transform.position.y + distance, lowerCube.transform.position.z);

            // lowerCube�� ��ǥ ��ġ�� speed �ӵ��� �̵�
            lowerCube.transform.position = Vector3.MoveTowards(lowerCube.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void HandleButtonClick()
    {
        // isRed ������ ���� ���� toggle
        lightImage.color = isRed ? Color.white : Color.red;
        isRed = !isRed;

        // lowerCube �̵� ���� ���
        isLowerCubeMoved = !isLowerCubeMoved;
    }
}
