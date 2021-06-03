using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public  AudioClip chomp, death, spotted, winner;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>(); //find audio source component

        //get sound resources
        chomp = Resources.Load<AudioClip>("chomp");
        death = Resources.Load<AudioClip>("death");
        spotted = Resources.Load<AudioClip>("spotted");
        winner = Resources.Load<AudioClip>("winner");
    }
    // Update is called once per frame
   public void PlaySound(string sound) //function called in other sctipts to play sound
    {
        switch (sound) 
        {
            case "chomp":
                audioSrc.PlayOneShot(chomp);
                break;
            case "death":
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
