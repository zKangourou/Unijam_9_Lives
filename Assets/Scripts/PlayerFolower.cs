using UnityEngine;
using System.Collections;

public class PlayerFolower : MonoBehaviour {

    [SerializeField] private Vector2 offset;
    private Vector3 realOffset;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        realOffset = new Vector3(offset.x, offset.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + realOffset;
	}
}
