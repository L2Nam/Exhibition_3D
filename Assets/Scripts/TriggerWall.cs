using TMPro;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    public GameObject player;

    public System.Random ran = new System.Random();

    public static int test;
    void Start()
    {
        Questions Questions = player.GetComponent<Questions>();
    }

    void OnTriggerEnter(Collider player)
    {

        if (player.gameObject.tag == "Player")
        {
            int index = ran.Next(Questions.QNo.Count);
            test = Questions.QNo[index];
            Questions.QNo.RemoveAt(index);
            QAControl.questionText = Questions.Question[test];
            print(Questions.QAns[test]);
            Destroy(gameObject);
        }
    }
}