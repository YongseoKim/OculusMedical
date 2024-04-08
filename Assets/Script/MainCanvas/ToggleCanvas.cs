using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch; // Left controller
    public GameObject canvasGameObject; // Canvas GameObject
    public GameObject xrRig; // Player base point for canvas coordinates
    public Canvas canvasComponent; // Canvas component
    public float canvasDistanceForward = 0.6f;
    public float height = 1.3f; // Canvas�� ����, ���� ������ ����

    private bool isCanvasVisible = false; // Canvas visibility state
    private bool wasXButtonPressed = false; // Previous state of the X button

    void Start()
    {
        canvasGameObject.SetActive(false); // Canvas�� ������ �� ��Ȱ��ȭ
    }

    void Update()
    {
        // Check for X button toggle
        if (OVRInput.GetDown(OVRInput.Button.One, leftController)) // Check if X button is pressed
        {
            ToggleMainCanvas();
        }
    }

    private void ToggleMainCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvasGameObject.SetActive(isCanvasVisible);

        // Update position only when canvas is activated
        if (isCanvasVisible && xrRig != null)
        {
            Vector3 canvasPosition = xrRig.transform.position + xrRig.transform.forward * canvasDistanceForward;
            canvasPosition.y = height; // Set Y axis to public height variable
            canvasGameObject.transform.position = canvasPosition;
        }
    }
}
