using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{

    public bool waitForClick = false;
    public int chapter = 0;
    public AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public AudioClip clip9;
    public AudioClip clip10;
    public AudioClip clip11;
    public AudioClip clip12;
    public AudioClip clip13;
    public AudioClip clip14;
    public AudioClip clip15;
    public AudioClip clip16;
    public AudioClip clip17;
    public AudioClip clip18;
    public AudioClip clip19;
    public AudioClip clip20;
    public AudioClip clip21;
    public AudioClip clip22;
    public AudioClip clip23;
    public AudioClip clip24;
    public AudioClip clip25;
    public AudioClip clip26;
    public AudioClip clip27;
    public AudioClip clip28;
    public AudioClip clip29;
    public AudioClip clip30;
    public AudioClip clip31;
    public AudioClip clip32;
    private string currentChapter;

    // Use this for initialization
    void Start()
    {
        waitForClick = true;
    }

    // every frame
    void Update()
    {
        if (((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Button A") || Input.anyKeyDown) && (waitForClick = true)))// if fire button pressed and waitForClick is true

            {
            chapter += 1; // increment to next chapter
            currentChapter = "chapter" + chapter.ToString(); Debug.Log("currentChapter is " + currentChapter);
            waitForClick = false; // disable wait
            StartCoroutine(currentChapter);
        }
    }


    IEnumerator chapter1()
    {
        audio.clip = clip1;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        yield return new WaitForSeconds(1);
        audio.clip = clip2;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter2()
    {
        Debug.Log("SPAWN!");
        audio.clip = clip3;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter3()
    {
        Debug.Log("SPAWN!");
        audio.clip = clip4;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter4()
    {
        audio.clip = clip5;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        yield return new WaitForSeconds(1);
        Debug.Log("SPAWN!");
        audio.clip = clip6;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter5()
    {
        audio.clip = clip7;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        waitForClick = true;
    }
    IEnumerator chapter6()
    {
        audio.clip = clip8;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip9;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter7()
    {
        audio.clip = clip10;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip11;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter8()
    {
        audio.clip = clip12;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip13;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip14;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter9()
    {
        audio.clip = clip15;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip16;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip17;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        waitForClick = true;
    }
    IEnumerator chapter10()
    {
        audio.clip = clip18;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip19;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip20;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        waitForClick = true;
    }
    IEnumerator chapter11()
    {
        audio.clip = clip21;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip22;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip23;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter12()
    {
        audio.clip = clip24;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip25;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip26;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        Debug.Log("SPAWN!");
        audio.clip = clip27;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter13()
    {
        audio.clip = clip28;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter14()
    {
        Debug.Log("SPAWN!");
        audio.clip = clip29;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        //spawn stack
        waitForClick = true;
    }
    IEnumerator chapter15()
    {
        audio.clip = clip30;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
    IEnumerator chapter16()
    {
        audio.clip = clip31;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        yield return new WaitForSeconds(1);
        audio.clip = clip32;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        waitForClick = true;
    }
}