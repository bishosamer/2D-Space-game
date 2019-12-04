using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    

public class BallFall : MonoBehaviour {
   // public Text scoreT;
	Vector2 mouse,ball,move,rod;
	public float mul,rodforce;
	public Rigidbody2D rb ;
    //int streak,sc;

    public AudioClip CoinHit;
    public AudioSource CoinHit_Source;
    public AudioClip RocketBoost;
    public AudioSource RocketBoost_Source;

    public GameObject[] coins;
    void Start () {
        //streak = sc = 0;

        CoinHit_Source.clip = CoinHit;
        RocketBoost_Source.clip = RocketBoost;
	}

    void FixedUpdate()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ball = transform.position;
        move = -ball + mouse;
        move /= move.magnitude;
     //   sc++;
        //sc = 0;
        //sc = 200 * streak;
      //  scoreT.text = sc.ToString();
       
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(move * mul * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag == "boost")
        {
            // TODO: e3mel partilces ya 5awal
            // we camera shake 
            //Play Thruster stronger particles
            Destroy(col.collider.gameObject);
            RocketBoost_Source.Play();
            //CameraShaker.Instance.ShakeOnce(3f, 4f, .1f, 2f);
            StartCoroutine(SpeedBoost(ScrollUV.speedDamper));
        }
        else if (col.gameObject.tag == "coin")
        {
            //streak++;
            Destroy(col.collider.gameObject);
            CoinHit_Source.Play();
        }
       // else if (col.gameObject.tag == "rip")
       // SceneManager.LoadScene("YouLose");
    }
    IEnumerator SpeedBoost(float current)
    {
        for (int i = 0; i < 100; i++)
        {
            coins = GameObject.FindGameObjectsWithTag("coin");
            foreach (GameObject coins in coins)
                if (coins.GetComponent<Rigidbody2D>().gravityScale < 130)
                    coins.GetComponent<Rigidbody2D>().gravityScale += 1;

            ScrollUV.speedDamper += 0.01f;
            yield return 5;
        }

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 100; i++)
        {
            coins = GameObject.FindGameObjectsWithTag("coin");
            foreach (GameObject coins in coins)
                if (coins.GetComponent<Rigidbody2D>().gravityScale > 30)
                    coins.GetComponent<Rigidbody2D>().gravityScale -= 1;

            ScrollUV.speedDamper -= 0.01f;
            yield return 5;
        }
    }
}