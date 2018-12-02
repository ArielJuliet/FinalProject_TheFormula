using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
	public Text winText;
    public Text endText;

   private Rigidbody2D rb2d;
    private int count;
    private float timer = 0;
    private bool haswon = false;

 void Start ()
  {
      rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText ();

   }

 void FixedUpdate()
 {
        timer = timer + Time.deltaTime;
        if (timer >= 10 && haswon == false)
        {
            endText.text = "Sorry! Your formula isn't complete!";
           // GameLoader.AddScore(count);
            StartCoroutine(ByeAfterDelay(2));

        }
        float moveHorizontal = Input.GetAxis ("Horizontal");
       float moveVertical = Input.GetAxis ("Vertical");
       Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
     rb2d.AddForce (movement * speed);
        if (Input.GetKey("escape"))
     Application.Quit();

 }


    void OnTriggerEnter2D(Collider2D other) 
   {

 if (other.gameObject.CompareTag ("Pickup"))

  {
			other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
    }
}
	void SetCountText ()

	{
	countText.text = "Count:" + count.ToString ();
		if (count >= 3)

		{
            haswon = true;
           winText.text = "Your Formula is complete!";
            //GameLoader.AddScore(count);
            ByeAfterDelay(2);
	}
}

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
      //  GameLoader.gameOn = false;
    }

}