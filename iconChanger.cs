using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iconChanger : MonoBehaviour {

    public float fadeOutTime = 0.3f;
    private int x = 0;


	void Start () {
        StartCoroutine(FadeOut(GetComponent<SpriteRenderer>()));
    }

    IEnumerator FadeOut (SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while(tmpColor.a > 0)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;
            yield return null;
        }

        _sprite.color = tmpColor;
    }

    IEnumerator FadeIn(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while (tmpColor.a < 1)
        {
            tmpColor.a += Time.deltaTime / fadeOutTime;
            _sprite.color = tmpColor;

            if (tmpColor.a >= 1f)
                tmpColor.a = 1.0f;
            yield return null;
        }

        _sprite.color = tmpColor;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) //Change the spellPrefab pointer in order to change spell. 
        {
            if (x > 0)
            {
                x -= 1;
                StartCoroutine(FadeOut(GetComponent<SpriteRenderer>()));
            }
            else
            {
                x += 1;
                StartCoroutine(FadeIn(GetComponent<SpriteRenderer>()));
            }
        }
    }
}
