using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraFollow : MonoBehaviour {

    // Start is called before the first frame update
    private Transform player;

    [SerializeField]
    private float minX, maxX;

    [SerializeField]
    private GameObject ScoreUIText;

    private Vector3 tempPos;
    private void Awake()
    {
        
    }


    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(ScoreIncrement());

    }
    // Update is called once per frame
    void Update() {
        if (player)   //Checks if player exists
        {
            tempPos = transform.position;
            tempPos.x = player.position.x;
            if (tempPos.x < minX)
            {
                tempPos.x = minX;
            }
            if (tempPos.x > maxX)
            {
                tempPos.x = maxX;

            }
            transform.position = tempPos;

        }

    }
    IEnumerator ScoreIncrement()
    {
        while (player != null )
        {
            yield return new WaitForSeconds(1f);
            GameManager.Score += 1;
            ScoreUIText.GetComponent<Text>().text = "Score: " + GameManager.Score;
            //Debug.Log("Score Increment with Time");
        }
    }

}
