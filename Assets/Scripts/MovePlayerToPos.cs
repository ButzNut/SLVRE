using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToPos : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = transform.position;   
    }
}
