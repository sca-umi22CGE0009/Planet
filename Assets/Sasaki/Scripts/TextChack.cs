using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// u.sasaki
/// </summary>
public class TextChack : MonoBehaviour
{
    [SerializeField, Header("storyText")] private GameObject story;

    [SerializeField, Header("allText")] private GameObject allText;

    [SerializeField, Header("SceneChanger")] private GameObject SceneChanger;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            story.gameObject.SetActive(false);
            allText.gameObject.SetActive(true);
            SceneChanger.gameObject.SetActive(true);
        }
    }
}
