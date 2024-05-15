using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Emotes_Controller : MonoBehaviour
{
   public Emote_Controller[] emotes;
   private bool active = true;
   public void Activate()
   {
      foreach (Emote_Controller emote in emotes)
      {
         for (int i = 0; i < emote.transform.childCount; ++i)
            emote.Activate_Numbers(active);

      }
      active = !active;
   }
}