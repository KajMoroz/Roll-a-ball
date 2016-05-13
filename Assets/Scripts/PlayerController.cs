using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup"))
		{
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}

		if (count == 8) {
			winText.text = "You Win!";
		}
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}