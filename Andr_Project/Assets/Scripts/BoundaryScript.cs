using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

    public Transform PlayerPuckBoundary;
    public Transform PlayerBoundary;
    public Transform AiPuckBoundary;
    public Transform AiBoundary;

    public CircleCollider2D Player;
    public CircleCollider2D Ai;

    // Use this for initialization
    void Awake () {
        PlayerBoundary.GetChild(0).position = new Vector3(PlayerBoundary.GetChild(0).position.x, PlayerPuckBoundary.GetChild(0).position.y - Player.radius, 0);//top
        PlayerBoundary.GetChild(1).position = new Vector3(PlayerBoundary.GetChild(1).position.x, PlayerPuckBoundary.GetChild(1).position.y + Player.radius, 0);//bottom
        PlayerBoundary.GetChild(2).position = new Vector3(PlayerPuckBoundary.GetChild(2).position.x + Player.radius, PlayerBoundary.GetChild(2).position.y, 0);//left
        PlayerBoundary.GetChild(3).position = new Vector3(PlayerPuckBoundary.GetChild(3).position.x - Player.radius, PlayerBoundary.GetChild(3).position.y, 0);//right


        AiBoundary.GetChild(0).position = new Vector3(AiBoundary.GetChild(0).position.x, AiPuckBoundary.GetChild(0).position.y - Ai.radius, 0);//top
        AiBoundary.GetChild(1).position = new Vector3(AiBoundary.GetChild(1).position.x, AiPuckBoundary.GetChild(1).position.y + Ai.radius, 0);//bottom
        AiBoundary.GetChild(2).position = new Vector3(AiPuckBoundary.GetChild(2).position.x + Ai.radius, AiBoundary.GetChild(2).position.y, 0);//left
        AiBoundary.GetChild(3).position = new Vector3(AiPuckBoundary.GetChild(3).position.x - Ai.radius, AiBoundary.GetChild(3).position.y, 0);//right
    }
}
