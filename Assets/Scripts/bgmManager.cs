using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager : MonoBehaviour
{
    public static bgmManager instance;

    AudioSource source;

    float timer = 1;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DestroyImmediate(gameObject);
        }    
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()
    {
        source.volume = 0.35f;
    }
    public void StopMusic()
    {
        timer = 1;
        StartCoroutine(MuteMusicSlowly());
    }
    IEnumerator MuteMusicSlowly()
    {
        yield return new WaitForSeconds(0.1f);
        timer -= 0.5f;
        source.volume = timer;
        if(timer <= 0)
        {
            yield break;
        }
        else
        {
            yield return MuteMusicSlowly();
        }
    }
}
