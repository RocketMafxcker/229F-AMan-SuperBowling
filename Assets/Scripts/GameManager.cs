using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField] TMP_Text[] scoreText;
    int score = 0;
    GameObject[] pins;
    int turnCounter = 0;
    int sumScore = 0;
    

    Vector3[] positions;
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for(int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }
    }

    void Update()
    {
        if (turnCounter < 4)
        {
            if(ball.transform.position.y < -30)
            {
                CountPinsDown();
                ResetPins();
                if (score == 10)
                {
                    sumScore = sumScore + score;
                    scoreText[turnCounter].text = "X";
                    score = 0;
                }
                else
                {
                    sumScore = sumScore + score;
                    scoreText[turnCounter].text = score.ToString();
                    score = 0;
                }
                turnCounter++;
            } 
        }else
        {
            scoreText[turnCounter].text = sumScore.ToString();
        }
    }
    void CountPinsDown()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 5 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }
    }

    void ResetPins()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.position = positions[i];
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            pins[i].transform.rotation = Quaternion.identity;
        }

        ball.transform.position = new Vector3(0.028651f, 0.158f, -9.6f);
        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
