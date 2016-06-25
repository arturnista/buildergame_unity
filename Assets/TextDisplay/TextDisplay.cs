using UnityEngine;
using System.Collections;

public class TextDisplay : MonoBehaviour {

	public GameObject textDisplay;
	public string textToForce;

	private GameObject textCreated;
	private string text;

	void Awake(){
		text = FindText();
	}

	string FindText(){
		if(textToForce != ""){
			return textToForce;
		}
		Work w = GetComponent<Work>();
		if(w){
			return w.type.ToString();
		}
		House h = GetComponent<House>();
		if(h){
			return "House";
		}
		return "No text found!";
	}

	void OnMouseEnter () {
		textCreated = Instantiate(textDisplay) as GameObject;

		textCreated.transform.parent = transform;

		textCreated.transform.localPosition = Vector3.zero;

		Vector3 scl = textCreated.transform.localScale;
		scl.x = 10 / transform.localScale.x;
		scl.y = 10 / transform.localScale.z;
		textCreated.transform.localScale = scl;

		textCreated.GetComponent<TextMesh>().text = text;
	}

	void OnMouseExit () {
		Destroy(textCreated);
	}
}
