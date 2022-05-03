using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    GameObject plank;
    [SerializeField]
    GameObject[] buttons;
    [SerializeField]
    AudioSource source;
    [SerializeField]
    AudioClip tone1, tone2, tone3;
    [SerializeField]
    Animator musicBoxAnimator, fadeAnimator;
    [SerializeField]
    Material white, green, red;

    int[] pattern = new int[] { 1, 1, 3, 3, 2, 1, 3 };
    int patternStep = 0;

    bool playedPattern = false, pressed1 = false, pressed2 = false, pressed3 = false;

    void Update()
    {
        if (!playedPattern && pressed1 && pressed2 && pressed3)
            PlayPattern();
    }

    public void DidTone(AudioClip tone)
    {
        if (!musicBoxAnimator.GetBool("Hide"))
        {
            int toneNum;
            if (tone == tone1)
            {
                toneNum = 1;
                pressed1 = true;
            }
            else if (tone == tone2)
            {
                toneNum = 2;
                pressed2 = true;
            }
            else
            {
                toneNum = 3;
                pressed3 = true;
            }

            if (pressed1 && pressed2 && pressed3)
            {
                if (pattern[patternStep++] != toneNum)
                {
                    patternStep = 0;
                    StartCoroutine(PlayPattern());
                }
                else if (patternStep >= pattern.Length)
                    StartCoroutine(SwitchScene());
            }
        }
    }

    IEnumerator PlayPattern()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].GetComponent<MeshRenderer>().material = red;
        musicBoxAnimator.SetBool("Hide", true);
        yield return new WaitForSeconds(1);
        for (var i = 0; i < pattern.Length; i++)
        {
            switch (pattern[i])
            {
                case 1:
                    source.PlayOneShot(tone1);
                    break;
                case 2:
                    source.PlayOneShot(tone2);
                    break;
                case 3:
                    source.PlayOneShot(tone3);
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
        playedPattern = true;
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].GetComponent<MeshRenderer>().material = white;
        yield return new WaitForSeconds(1);
        musicBoxAnimator.SetBool("Hide", false);
    }

    IEnumerator SwitchScene()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].GetComponent<MeshRenderer>().material = green;
        yield return new WaitForSeconds(1);
        musicBoxAnimator.SetBool("Hide", true);
        yield return new WaitForSeconds(1);
        GameObject o = Instantiate(plank);
        o.transform.SetPositionAndRotation(fadeAnimator.transform.parent.parent.position, fadeAnimator.transform.parent.parent.rotation);
        yield return new WaitForSeconds(1);
        fadeAnimator.SetBool("Faded", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Flags.GetNextScene);
    }
}
