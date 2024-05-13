using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Add_Ingredient : MonoBehaviour
{
    public Vector2[] poses;
    private async void Move()
    {
        await Moving(poses[0]);
        await Moving(poses[1]);
    }
    private async Task Moving(Vector2 pose)
    {
        while ((Vector2)transform.localPosition != pose)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, pose, Time.deltaTime * 100);
            await Task.Yield();
        }

    }

    public void DiactivateEmote()
         => gameObject.SetActive(false);
    public void ActivateEmote(Vector2 pose, Sprite face)
    {
        transform.position = pose;
        GetComponent<SpriteRenderer>().sprite = face;
        Move();
    }
}
