using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    [SerializeField] private GameObject cameraPosition;
    private Transform cameraUp;
    private Transform cameraDown;
    private Transform cameraLeft;
    private Transform cameraRight;
    private int actualPosition = 0;


    private Vector3 targetPosition;
    private Quaternion targetRotation;

    [SerializeField] private Texture2D cursorSprite;


    void Start () {
        //Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.Auto);

        cameraDown = cameraPosition.transform.GetChild(0).transform;
        cameraLeft = cameraPosition.transform.GetChild(1).transform;
        cameraRight = cameraPosition.transform.GetChild(2).transform;
        cameraUp = cameraPosition.transform.GetChild(3).transform;

    }
	
	
	void Update () {

        if (Input.GetButtonDown("RotateLeftCamera")) {
            switch (actualPosition) {
                case 0:
                    actualPosition = 3;
                    targetPosition = cameraLeft.position;
                    targetRotation = cameraLeft.rotation;
                    break;
                case 1:
                    actualPosition = 0;
                    targetPosition = cameraDown.position;
                    targetRotation = cameraDown.rotation;
                    break;
                case 2:
                    actualPosition = 1;
                    targetPosition = cameraRight.position;
                    targetRotation = cameraRight.rotation;
                    break;
                case 3:
                    actualPosition = 2;
                    targetPosition = cameraUp.position;
                    targetRotation = cameraUp.rotation;
                    break;


            }

            StartCoroutine(ChangeCameraPosition());
        }else if (Input.GetButtonDown("RotateRightCamera")) {
            switch (actualPosition) {
                case 0:
                    actualPosition = 1;
                    targetPosition = cameraRight.position;
                    targetRotation = cameraRight.rotation;
                    break;
                case 1:
                    actualPosition = 2;
                    targetPosition = cameraUp.position;
                    targetRotation = cameraUp.rotation;
                    break;
                case 2:
                    actualPosition = 3;
                    targetPosition = cameraLeft.position;
                    targetRotation = cameraLeft.rotation;
                    break;
                case 3:
                    actualPosition = 0;
                    targetPosition = cameraDown.position;
                    targetRotation = cameraDown.rotation;
                    break;

            }
            StartCoroutine(ChangeCameraPosition());
        }


    }

    IEnumerator ChangeCameraPosition() {

        for (float i = 0; i <= 1; i = 0.05f) {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPosition, i);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation, i);
            yield return new WaitForSeconds(.015f);
        }

    }
}
