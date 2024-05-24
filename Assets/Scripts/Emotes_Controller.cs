using UnityEngine;

public class Emotes_Controller : MonoBehaviour
{
   public Emote_Controller[] emotes;
   private bool active;
   private void Start() => Activate();
   public void Activate()
   {
      foreach (Emote_Controller emote in emotes)
      {
         for (int i = 0; i < emote.transform.childCount; ++i)
         {
            emote.Activate_Numbers(active);
            emote.enabled = active;
         }
      }
      active = !active;
   }
   public void Restart()
   {
      foreach (Emote_Controller emote in GetComponentsInChildren<Emote_Controller>())
         if (emote.selected[0]|(emote.selected[1]))
            emote.Click();
   }
}