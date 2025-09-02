using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    //prefab for instantiading apples
    public GameObject applePrefab;
    //speed at which apple tree moves
    public float speed = 1f;
    //Distance where AppleTree will change directions
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.2f;
    // seconds between Apples instantiations
    public float appleDropdelay = 1f;
    void Start() 
    {
        //start dropping apples
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject Apple = Instantiate<GameObject>(applePrefab);
        Apple.transform.position = transform.position;
        Invoke("DropeApple", appleDropdelay);
    }


















    // Update is called once per frame
    void Update()
    {
        //basic Movements
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime; //measure of the number of seconds since the last frame
        transform.position = pos;
        
        //Changing Directions
        //handling hitting the edges of the screen
        if (pos.x <-leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x >leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }else if (Random.value < changeDirChance)
        {
            speed *= -1; //change direction
        }
    }
    private void FixedUpdate()
    {
        //runs at a fixed interval, independent of frame rate (50-60 fps)
        if (Random.value < changeDirChance)
        {
            speed += -1; //Change direction
        }
    }
}
