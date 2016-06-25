using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float moveSpeed;
	public bool sideScreenMove;

	private float sepLengthUp;
	private float sepLengthDown;
	private float sepLengthLeft;
	private float sepLengthRight;

	private Vector3 clickPos;
	private bool movingByClick;

	void Start () {
		sepLengthUp = Screen.height * 0.98f;
		sepLengthDown = Screen.height - sepLengthUp;

		sepLengthRight = Screen.width * 0.98f;
		sepLengthLeft = Screen.width - sepLengthRight;
	}

	void Update () {
		if(sideScreenMove && !movingByClick){
			if(Input.mousePosition.y >= sepLengthUp){
				transform.Translate(Vector3.up * moveSpeed * GameTimeController.deltaTime);
			} else if(Input.mousePosition.y <= sepLengthDown){
				transform.Translate(Vector3.down * moveSpeed * GameTimeController.deltaTime);
			}
			if(Input.mousePosition.x >= sepLengthRight){
				transform.Translate(Vector3.right * moveSpeed * GameTimeController.deltaTime);
			} else if(Input.mousePosition.x <= sepLengthLeft){
				transform.Translate(Vector3.left * moveSpeed * GameTimeController.deltaTime);
			}
		}
		if(Input.GetButtonDown("MoveCamera")){
			clickPos = Input.mousePosition;
			clickPos.x = clickPos.x - (Screen.width / 2);
			clickPos.y = clickPos.y - (Screen.height / 2);
			movingByClick = true;
		}
		if(Input.GetButton("MoveCamera")){
			Vector3 mPos = Input.mousePosition;
			mPos.x = mPos.x - (Screen.width / 2);
			mPos.y = mPos.y - (Screen.height / 2);
			Vector3 difPos = mPos - clickPos;

			float h = Mathf.Sign(difPos.x) * (Mathf.Abs(difPos.x) / (Screen.width / 2));
			float v = Mathf.Sign(difPos.y) * (Mathf.Abs(difPos.y) / (Screen.height / 2));
			print("H:" + h + " V:" + v);

			Vector3 cameraPos = transform.position;
			cameraPos.x += h * moveSpeed * GameTimeController.deltaTime;
			cameraPos.z += v * moveSpeed * GameTimeController.deltaTime;
			transform.position = cameraPos;

		}
		if(Input.GetButtonUp("MoveCamera")){
			movingByClick = false;
		}
	}
}
