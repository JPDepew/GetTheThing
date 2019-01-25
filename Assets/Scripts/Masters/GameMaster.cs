using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public Text timer;
    public GameObject[] pickups;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 30;
        StartCoroutine(TurnTextRedTimer());
        StartCoroutine(InstantiateObjects());
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = time.ToString("F2");
    }

    IEnumerator TurnTextRedTimer()
    {
        yield return new WaitForSeconds(27);
        timer.color = Color.red;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

    IEnumerator InstantiateObjects()
    {
        while (true)
        {
            int index = Random.Range(0, pickups.Length - 1);
            float xPos = Random.Range(-6.5f, 6.5f);
            float zPos = Random.Range(-4.3f, 4.3f);
            Vector3 position = new Vector3(xPos, 2, zPos);
            Instantiate(pickups[index], position, transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }
}
