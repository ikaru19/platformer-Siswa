using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public Text textHealth;
    // Start is called before the first frame update
    void Start()
    {
        ShowHealthValue();
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealthValue();
        if (health <= 0) {
            Application.LoadLevel("GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.tag == "zombie")
        {
            health -= 5;

        }

    }

    public void ShowHealthValue() {
        string healtMessage = "Health : " + health;
        textHealth.text = healtMessage;
    }
}
