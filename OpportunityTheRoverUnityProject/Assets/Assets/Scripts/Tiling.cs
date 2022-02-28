using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2;			// the offset so that we don't get any weird errors

	// these are used for checking if we need to instantiate stuff
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy = false;

	public bool reverseScale = false;	// used if the object is not tilable

	private float spriteHeight = 0f;		// the width of our element
	private Camera cam;
	private Transform myTransform;

	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteHeight = sRenderer.sprite.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () {
		// does it still need buddies? If not do nothing
		if (hasALeftBuddy == false || hasARightBuddy == false) {
			// calculate the cameras extend (half the width) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.height/Screen.width;

			// calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionRight = (myTransform.position.y + spriteHeight/2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.y - spriteHeight/2) + camHorizontalExtend;

			// checking if we can see the edge of the element and then calling MakeNewBuddy if we can
			if (cam.transform.position.y >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
			{
				MakeNewBuddy (1);
				hasARightBuddy = true;
			}
			else if (cam.transform.position.y <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
			{
				MakeNewBuddy (-1);
				hasALeftBuddy = true;
			}
		}
	}

	// a function that creates a buddy on the side required
	void MakeNewBuddy (int rightOrLeft) {
		// calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x, myTransform.position.y + spriteHeight * rightOrLeft, myTransform.position.z);
		// instantating our new body and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

		// if not tilable let's reverse the x size og our object to get rid of ugly seams
		//if (reverseScale == true) {
		//	newBuddy.localScale = new Vector3 (newBuddy.localScale.x, newBuddy.localScale.y * -1, newBuddy.localScale.z);
		//}

		newBuddy.parent = myTransform.parent;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
		}
		else {
			newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
		}
	}
}
