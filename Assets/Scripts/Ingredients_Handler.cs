using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ingredients_Handler : MonoBehaviour
{
    public List<SpriteRenderer> Ingreds;
    public Sprite[] Emotes;
    public Sprite[] Cups;
    public Image Cup;
    private List<List<Sprite>> ingreds = new();
    private Dictionary<List<Sprite>, Sprite> cups = new();
    private void Start()
    {
        int n = 0;
        for (int i = 0; i < Emotes.Length - 1; ++i)
            for (int j = i + 1; j < Emotes.Length; ++j)
            {
                ingreds.Add(new List<Sprite>() { Emotes[i], Emotes[j] });
                cups.Add(ingreds[n], Cups[n]);
                ++n;
            }
        print(cups.Count);
    }
    public void Make_Coffee()
    {
        foreach (List<Sprite> sprite in ingreds)
            if (sprite.Contains(Ingreds[0].sprite) && (sprite.Contains(Ingreds[1].sprite)))
                Cup.sprite = cups[sprite];
    }
}
