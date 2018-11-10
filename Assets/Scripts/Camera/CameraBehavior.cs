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
    private bool isMoving = false;



    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 startPosition;
    private Quaternion startRotation;

    [SerializeField] private Texture2D cursorNormalSprite;
    [SerializeField] private Texture2D cursorClickSprite;

    //[SerializeField] private PostProcessingBehavior mainProfile;
    //[SerializeField] private PostProcessingBehavior distortProfile;



    void Start () {
        Cursor.SetCursor(cursorNormalSprite, Vector2.zero, CursorMode.Auto);

        cameraDown = cameraPosition.transform.GetChild(0).transform;
        cameraLeft = cameraPosition.transform.GetChild(1).transform;
        cameraRight = cameraPosition.transform.GetChild(2).transform;
        cameraUp = cameraPosition.transform.GetChild(3).transform;

    }
	
	
	void Update () {

        if (Input.GetButtonDown("Fire1")) {
            Cursor.SetCursor(cursorClickSprite, Vector2.zero, CursorMode.Auto);
            Invoke("SetCursorNormal", 0.2f);
        }

        if (!isMoving) {
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


    }

    IEnumerator ChangeCameraPosition() {
        isMoving = true;

        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;

        float startTime = Time.time;
        float distCovered = 0;
        float fracJourney = 0;
        // Calculate the journey length.
        float journeyLength = Vector3.Distance(gameObject.transform.position, targetPosition);

        while(fracJourney < 1f) {

            // Distance moved = time * speed.
            distCovered = (Time.time - startTime) * 200f;

            // Fraction of journey completed = current distance divided by total distance.
            fracJourney = distCovered / journeyLength;
            
            gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, fracJourney);
            gameObject.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, fracJourney);
        
            yield return new WaitForSeconds(.01f);
        }

        isMoving = false;
    }

    public void SetCursorNormal() {
        Cursor.SetCursor(cursorNormalSprite, Vector2.zero, CursorMode.Auto);
    }
}
