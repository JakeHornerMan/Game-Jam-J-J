using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip chomp, death, spotted, winner;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); //find audio source component

        //get sound resources
        chomp = Resources.Load<AudioClip>("Chomp");
        death = Resources.Load<AudioClip>("Death");
        spotted = Resources.Load<AudioClip>("Spotted");
        winner = Resources.Load<AudioClip>("Winner");
    }
    // Update is called once per frame
   public static void PlaySound(string sound) //function called in other sctipts to play sound
    {
        switch (sound) 
        {
            case "chomp":
                audioSrc.PlayOneShot(chomp);
                break;
            case "Death":
                audioSrc.PlayOneShot(death);
                break;
            case "spotted":
                audioSrc.PlayOneShot(spotted);
                break;
            case "winner":
                audioSrc.PlayOneShot(winner);
                break;
        }
    }
}    
