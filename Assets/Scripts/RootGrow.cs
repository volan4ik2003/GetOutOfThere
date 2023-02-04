using AllIn1SpriteShader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RootGrow : MonoBehaviour
{
    public GameObject Roots;
    private float fade_value = 1;

    private void Start()
    {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        Roots.GetComponent<Renderer>().sharedMaterial.SetFloat("_FadeAmount", fade_value);
        yield return new WaitForSeconds(0.1f);
        fade_value -= 0.01f;
        StartCoroutine(Grow());
    }
}
