using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/** Script zur Steuerung der KI */
public class AIScript : MonoBehaviour {

    public float MaxMovementSpeed; /** maximale Geschwindigkeit */
    private Rigidbody2D rb; /** Rigidbody fuer den Schlaeger der KI */
    private Vector2 startingPosition; /**Startposition des Schlaegers*/

    public Rigidbody2D Puck; /** Rigidbody fuer den Puck */

    public Transform PlayerBoundaryHolder; 
    private Boundary playerBoundary; /**Spielfeldbegrenzung fuer den Schlaeger */

    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary; /**Begrenzung der eigenen Spielhaelfte*/

    private Vector2 targetPosition; /**Zielposition des Schlaegers */

    private bool isFirstTimeInOpponentsHalf = true;
    private float offsetXFromTarget;

    /** Initailisierung */
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;

        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y,
                              PlayerBoundaryHolder.GetChild(1).position.y,
                              PlayerBoundaryHolder.GetChild(2).position.x,
                              PlayerBoundaryHolder.GetChild(3).position.x);

        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y,
                              PuckBoundaryHolder.GetChild(1).position.y,
                              PuckBoundaryHolder.GetChild(2).position.x,
                              PuckBoundaryHolder.GetChild(3).position.x);

        MaxMovementSpeed = Values.AiSpeed;
    }
    /** Methode zur Bewegung der KI */
    private void FixedUpdate()
    {
        float movementSpeed;

        if (Puck.position.y < puckBoundary.Down)
        {
            if (isFirstTimeInOpponentsHalf)
            {
                isFirstTimeInOpponentsHalf = false;
                offsetXFromTarget = Random.Range(-1f, 1f);
            }

            movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetXFromTarget, playerBoundary.Left,
                                                    playerBoundary.Right),
                                        startingPosition.y);
        }
        else
        {
            isFirstTimeInOpponentsHalf = true;

            movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left,
                                        playerBoundary.Right),
                                        Mathf.Clamp(Puck.position.y, playerBoundary.Down,
                                        playerBoundary.Up));
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition,
                movementSpeed * Time.fixedDeltaTime));
    }
}
