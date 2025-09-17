using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotDetector : MonoBehaviour

{
    
    
    [SerializeField]
    public TextMeshProUGUI scoreInText;
    public GameObject Ball;
    public GameObject Net;
    public TextMeshPro ScoreBoard;
    public TextMeshPro ColliderDetect;
    int PlayerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        Ball = GetComponent<GameObject>();
        Net = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score: " + PlayerScore);
        ScoreBoard.text = "Score: " + PlayerScore.ToString();
        scoreInText.text = "In: " + PlayerScore.ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerScore++;
        ColliderDetect.text = other.gameObject.name;
        
    }
}
