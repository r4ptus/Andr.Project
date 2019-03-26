using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Klasse um die Bewegung und die Positionierung der Schlaeger zu realisieren 
 */ 
public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb; 
    Vector2 startingPosition; /**Startposition */ 

    public Transform BoundaryHolder;

    Boundary playerBoundary; /**Spielfeldbegrenzung fuer den Spieler */

    public Collider2D PlayerCollider { get; private set; }
    public PlayerController Controller;
    public int? LockedFingerID { get; set; }

    /** Initialisierung */
    void Start()
    {

        setPlayerColour(Values.playerColour);
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
        PlayerCollider = GetComponent<Collider2D>();

        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y,
                                      BoundaryHolder.GetChild(1).position.y,
                                      BoundaryHolder.GetChild(2).position.x,
                                      BoundaryHolder.GetChild(3).position.x);
        
    }

    private void OnEnable()
    {
        Controller.Players.Add(this);
    }
    private void OnDisable()
    {
        Controller.Players.Remove(this);
    }
    /** Bewegt den Schlaeger zur angegebenen Position */
    public void MoveToPosition(Vector2 position)
    {
        Vector2 clampedMousePos = new Vector2(Mathf.Clamp(position.x, playerBoundary.Left,
                                                  playerBoundary.Right),
                                      Mathf.Clamp(position.y, playerBoundary.Down,
                                                  playerBoundary.Up));
        rb.MovePosition(clampedMousePos);
    }
    /** Setzt den Schlaeger auf die Starposition zurueck */
    public void ResetPosition()
    {
        rb.position = startingPosition;
    }
    /** Aendert die Farbe des Schlaegers */
    public void setPlayerColour(Colour colour)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        GameObject player = null;
        if( colour == Colour.Red)
        {
            player = FindObject("PlayerRed", objects);

        }
        else if (colour == Colour.Green)
        {
            player = FindObject("PlayerGreen", objects);
        }
        else if (colour == Colour.Tuerkis)
        {
            player = FindObject("PlayerTuerkis", objects);
        }
        else if (colour == Colour.Violett)
        {
            player = FindObject("PlayerViolet", objects);
        }
       
        if(player != null)
        {
            gameObject.SetActive(false);
            player.SetActive(true);
        }
        
        
        ;
    }
    /** Methode zum finden des gesuchten Gameobjects anhand des Namens auf einem Array
     * Gibt das gesuchte Gameobject oder null zurueck, falls keins gefunden wurde */
    private GameObject FindObject(string name, GameObject[] objects)
    {
        GameObject ret = null;
        for(int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name == name)
            {
                ret = objects[i];
            }
        }
        return ret;
    }

   
}