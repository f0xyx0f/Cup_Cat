using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cups_Handler : MonoBehaviour
{
    GameObject cup;
    private void Start()
    {
        GameObject dop;
        SaveData.LoadGame();
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cup").Length; ++i)
        {
            if (SaveData.Active[i])
            {
                dop = GameObject.FindGameObjectsWithTag("Cup")[i];
                dop.GetComponent<Animator>().SetTrigger("Open");
            }
        }
    }
    public void Unlock_Cup(Image originCup)
    {
        GameObject dop;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cup").Length; ++i)
        {
            dop = GameObject.FindGameObjectsWithTag("Cup")[i];
            if (dop.GetComponent<Image>().sprite == originCup.sprite)
            {
                cup = dop;
                SaveData.Active[i] = true;
                SaveData.SaveGame();
            }
        }
        StartCoroutine(Move());

    }
    private IEnumerator Move()
    {
        GetComponent<ScrollRect>().enabled = false;
        Vector2 pos0, pos1;
        pos1 = new Vector2(0, 0.5f) * Math.Sign(-cup.transform.position.y);
        while (Math.Abs(cup.transform.position.y) > 4)
        {
            pos0 = transform.position;

            transform.position = Vector2.Lerp(pos0, pos0 + pos1, Time.deltaTime * 1000);
            yield return null;
        }
        GetComponent<ScrollRect>().enabled = true;
        cup.GetComponent<Animator>().SetTrigger("Open");
        StopAllCoroutines();
    }
}
