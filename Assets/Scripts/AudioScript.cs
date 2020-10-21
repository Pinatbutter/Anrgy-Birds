using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public GameObject StandardShot;
    public GameObject BombShot;
    public GameObject BombFuse;
    public GameObject BombExplode;
    public GameObject BackgroundMusic;
    public GameObject WinSoundEffect;
    public GameObject LooseSoundEffect;


    public void PlayBackground()
    {
        Instantiate(BackgroundMusic);
    }
    public void PlayStandardShot()
    {
        StartCoroutine("Standard");
    }

    private IEnumerator Standard()
    {
        GameObject sound = Instantiate(StandardShot);
        yield return new WaitForSeconds(1);
        Destroy(sound);
    }

    public void PlayBombShot()
    {
        StartCoroutine("Bomb");
    }

    private IEnumerator Bomb()
    {
        GameObject shot = Instantiate(BombShot);
        yield return new WaitForSeconds(1);
        Destroy(shot);

        GameObject fuse = Instantiate(BombFuse);
        yield return new WaitForSeconds(4);
        Destroy(fuse);

        GameObject explode = Instantiate(BombExplode);
        yield return new WaitForSeconds(2);
        Destroy(explode);
    }

    public void PlayYouWin()
    {
        StartCoroutine("YouWin");
    }
    private IEnumerator YouWin()
    {
        GameObject sound = Instantiate(WinSoundEffect);
        yield return new WaitForSeconds(3);
        Destroy(sound);
    }
    public void PlayRestart()
    {
        StartCoroutine("YouLost");
    }
    private IEnumerator YouLost()
    {
        GameObject sound = Instantiate(LooseSoundEffect);
        yield return new WaitForSeconds(4);
        Destroy(sound);
    }
}
