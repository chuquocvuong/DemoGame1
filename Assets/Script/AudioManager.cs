using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioBackground;
    public AudioSource audioEffect;
    public AudioClip background;
    public AudioClip Jump;
    public AudioClip Coin;
    void Start()
    {
        playBackGround();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playBackGround()
    {
        audioBackground.clip = background;
        audioBackground.Play();
    }
    public void playCoin()
    {
        audioEffect.PlayOneShot(Coin);
    }
    public void playJump()
    {
        audioEffect.PlayOneShot(Jump);
    }
}
