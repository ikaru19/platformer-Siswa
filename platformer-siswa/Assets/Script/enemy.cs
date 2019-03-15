 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;

  
    public int speed;
    public int mvspeed;
    private Transform topCheck;
    private Animator anim;

    private bool dipidek = false;

    void Awake()
    {
        // Setting up references.
        topCheck = transform.Find("topCheck");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
        anim.SetInteger("speed", speed);

        dipidek = Physics2D.Linecast(transform.position, topCheck.position, 1 << LayerMask.NameToLayer("playerGround"));
        if (dipidek) {
            Debug.Log("dipidek");
            dipidek = false;
        }
    }



	void OnCollisionEnter2D(Collision2D col)
	{
        //Check collision name 
        this.mvspeed = speed;
		if (col.gameObject.tag == "batas") {
            StartCoroutine(Wait(1));
        }

        if (col.gameObject.tag == "player")
        {
            anim.SetTrigger("Attack");
            StartCoroutine(Wait(0.3f));
           
        }

        if (col.gameObject.tag == "zombie") {
            StartCoroutine(Wait(0.2f));

        }

	}

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    IEnumerator Wait(float waitLength){
        yield return new WaitForSeconds(waitLength);
        speed = 0;
        speed = mvspeed;
        speed = speed * -1;
        Flip();
    }
}
