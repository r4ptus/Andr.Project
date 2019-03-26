using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** Skript zu Einstellungen bzueglich des Pucks und zum erkennen von Toren*/
public class PuckScript : MonoBehaviour {

    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; } //** Boolean ob ein Tor geschossen wurde */
    public float MaxSpeed; /** Maximale Geschwindigkeit der Pucks */

    public AudioManager audioManager;
    public CircleCollider2D PlayerRedCollider;
    public CircleCollider2D PlayerBlueCollider;

    private Rigidbody2D rb;

    private int distanceRed;
    private int distanceBlue;
    private bool isClipping = false;
    private bool calledOnece = false;

    /** Initialisierung */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }
    /** Trigger zum erkennen von Toren, ordnet das Tor dem richtigen Player zu */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    /** Fuegt Sound beim Spielen des Pucks hinzu */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlayPuckCollision();
    }
     /** Setzt den Puck auf die Seite, desjenigen der das Tor geschossen hat  */
    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }

    private IEnumerator IsClipping()
    {
        yield return new WaitForSecondsRealtime(2);
        if (isClipping)
        {
            if ((PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.min) && PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)) || (PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.max) && PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)))
            {
                rb.position = new Vector2(0, -1);
                rb.velocity = new Vector2(0, 0);
            }
            if ((PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.min) && PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)) || (PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.max) && PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)))
            {
                rb.position = new Vector2(0, 1);
                rb.velocity = new Vector2(0, 0);
            }
            Debug.Log("isClipping");
        }
        isClipping = false;
        calledOnece = false;
    }
     /** Limitiert die maximale Geschwindigkeit des Pucks und verhindert clipping */
    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);

        if ((PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.min) && PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)) || (PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.max) && PlayerRedCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)))
        {
            isClipping = true;
            if (!calledOnece)
            {
                StartCoroutine(IsClipping());
                calledOnece = true;
            }
        }
        if ((PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.min) && PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)) || (PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.max) && PlayerBlueCollider.bounds.Contains(GetComponent<CircleCollider2D>().bounds.center)))
        {
            isClipping = true;
            if (!calledOnece)
            {
                StartCoroutine(IsClipping());
                calledOnece = true;
            }
        }
    }
}
