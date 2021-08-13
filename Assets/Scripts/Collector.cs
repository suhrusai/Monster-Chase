using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameObject ScoreUIText;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Score = 10;
        ScoreUIText.GetComponent<Text>().text = "Score: " + GameManager.Score;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && player)
        {
            GameManager.Score += 3;
            ScoreUIText.GetComponent<Text>().text = "Score: " + GameManager.Score;
            Destroy(collision.gameObject);
        }
    }
}
