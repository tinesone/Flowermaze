using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Control : MonoBehaviour {

	Rigidbody2D rb;

	public int dmg = 20;

  public int maxHealth = 503;
  private int curHealth = 0;

  public float armor = 60;

	public float speed = 10f;

	public float y;
	public float x;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
    curHealth = maxHealth;
	}

	// Update is called once per frame
	void FixedUpdate () {
		y = Input.GetAxisRaw("Vertical") * speed;
		x = Input.GetAxisRaw("Horizontal") * speed;
		rb.velocity = new Vector2(x, y);
	}

    private void Update()
    {
      if (curHealth <= 0)
      {
        print("died");
        Invoke("remove", 0.4f);
      }
    }


    public void ApplyDamage(float damege)
    {
      damege = damege - damege * armor / 100f;
      curHealth -= (int)damege;
      print(curHealth);
    }

    void remove()
    {
      Destroy(gameObject);
    }
}
