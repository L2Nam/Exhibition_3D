using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QAControl : MonoBehaviour
{
    public GameObject broken;
    public GameObject player;
    public GameObject soundGame;
    public TextMeshProUGUI question;

    public static string questionText;
    int WallNos = PuzzleControl.WallNos;
    public GameObject WallsAndTrigger;
    public GameObject Finish;

    int countTrue = 1;

    void Start()
    {
        int k = 1;
        for (; k <= WallNos; k++)
        {
            Instantiate(WallsAndTrigger, new Vector3(2.002823f, -3.093146F, k * 24.22034f), Quaternion.identity);
        }
        float a = k * 24.22034f - 10;
        Instantiate(Finish, new Vector3(0f, 0F, a), Quaternion.identity);
        MovePlayer();
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "answer wall")
                {
                    GameObject wall = hit.collider.gameObject;
                    string check = wall.name;
                    Questions Questions = player.GetComponent<Questions>();
                    Vector3 wallPosition = wall.transform.position;

                    if (Questions.QAns[TriggerWall.test] == check.Substring(0, 1))
                    {
                        ScoreScript.scoreValue += 100;
                        GameObject fractured = Instantiate(broken, wallPosition, Quaternion.Euler(90f, 90f, 0f));
                        Destroy(wall);

                        Rigidbody[] particles = fractured.GetComponentsInChildren<Rigidbody>();
                        foreach (var body in particles)
                        {
                            body.AddExplosionForce(500, wallPosition, 2);
                            body.mass = 0.001f;
                        }
                        PlayAudio("Right");
                        countTrue++;
                        player.transform.DOMove(new Vector3(wallPosition.x, 0.5f, wallPosition.z), 1.7f).SetEase(Ease.OutCubic).OnComplete(MovePlayer);
                    }
                    else
                    {
                        Debug.Log("wrong");
                        ScoreScript.scoreValue -= 50;
                        StartCoroutine(ShakeObject(0.2f, 0.1f, wall, wallPosition));
                        PlayAudio("Error");
                    }
                }
            }
        }
    }

    private void PlayAudio(string sound1)
    {
        Transform sound = soundGame.transform.Find(sound1);
        AudioSource audioSource = sound.GetComponent<AudioSource>();
        audioSource.Play();
    }

    private IEnumerator ShakeObject(float duration, float magnitude, GameObject wall, Vector3 wallPosition)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            wall.transform.position = new Vector3(wallPosition.x + x, wallPosition.y + y, wallPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = wallPosition;
    }

    public void MovePlayer()
    {
        float targetZ = countTrue * 24.22034f - 10f;
        player.transform.DOMove(new Vector3(0f, 0.5f, targetZ), 3f)
            .SetEase(Ease.OutCubic).OnComplete(()=>
            {
                PlayAudio("Question_Pop");
                question.text = questionText;
            });
    }
}
