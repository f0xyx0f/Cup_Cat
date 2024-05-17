using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Cups_Handler : MonoBehaviour
{
    GameObject cup;


    private void Start()
    {

    }
    public void Unlock_Cup(Image originCup)
    {
        foreach (Image lok in GetComponentsInChildren<Image>())
        {
            if (lok.sprite == originCup.sprite)
                cup = lok.gameObject;
            print(lok.name + lok.transform.position);
        }
        Move();
        
    }

    private async void Move()
    {
        GetComponent<ScrollRect>().enabled = false;
        while (cup.transform.position.y > 730 ||
        (cup.transform.position.y < 96))
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y -
             cup.transform.position.y);
            transform.position = Vector2.Lerp(transform.position, newPos, Time.deltaTime);
            await Task.Yield();
        }
        GetComponent<ScrollRect>().enabled = true;
        cup.GetComponent<Animator>().SetTrigger("Open");
    }
}
