using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxMovingManager : MonoBehaviour
{
    public Button buttonToClick; // Ŭ���ϴ� ��ư
    public Image lightImage; // ���<->������ �̹��� (��ư�� �� Ŭ���Ǿ����� Ȯ���ϴ� �뵵)
    public GameObject upperCube; // �� ť��
    public GameObject lowerCube; // �Ʒ� ť��

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
            // upperCube�� y ��ǥ�� ������ lowerCube�� y ��ǥ�� upperCube�� y ��ǥ + distance�� ����
            float newYPosition = upperCube.transform.position.y + distance;
            lowerCube.transform.position = new Vector3(lowerCube.transform.position.x, newYPosition, lowerCube.transform.position.z);
        }
    }

    void HandleButtonClick()
    {
        // isRed ������ ���� ���� toggle
        lightImage.color = isRed ? Color.white : Color.red;

        // isRed ���� ������Ʈ
        isRed = !isRed;

        // lowerCube ��ġ ����
        MoveLowerCube();
    }

    void MoveLowerCube()
    {
        if (isLowerCubeMoved)
        {
            // lowerCube�� ����ġ�� �̵�
            lowerCube.transform.position = initialLowerCubePosition;
            isLowerCubeMoved = false;
        }
        else
        {
            // lowerCube�� upperCube �Ʒ��� distance ��ġ�� �̵�
            float newYPosition = upperCube.transform.position.y + distance;
            lowerCube.transform.position = new Vector3(lowerCube.transform.position.x, newYPosition, lowerCube.transform.position.z);
            isLowerCubeMoved = true;
        }
    }
}
