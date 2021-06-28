using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScript : MonoBehaviour
{
    public int index;
    public GameManager gm;
    public float VideoTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.SceneChange(index);

        }
        StartCoroutine(StartGame(VideoTime));
    }
    IEnumerator StartGame(float A)
    {
        yield return new WaitForSeconds(A);
        gm.SceneChange(index);

    }
}