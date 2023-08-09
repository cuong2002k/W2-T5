using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spin : MonoBehaviour
{
    public Transform parrent;

    private int numberOfGift = 8;
    public float numberRotation;
    public float CIRCLE = 360.0f;
    private float angleOfGift;

    [Header("Animation curve")]
    public AnimationCurve curve;
    float currentTime;
    public float timeRotation;

    [Header("list item")]
    public List<Item> lstitem;

    [Header("Audio")]
    public AudioClip clip;
    private AudioSource audioSource;

    int coutLucky;
    private void Awake()
    {
        angleOfGift = CIRCLE / numberOfGift;
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).transform.eulerAngles = new Vector3(0, 0, -i * angleOfGift - 22.5f);
            parrent.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = lstitem[i].name;
            parrent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = lstitem[i].icon;
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator WheelRotation()
    {
        float startAngle = this.transform.eulerAngles.z;
        currentTime = 0;
        int indexRandom = Random.Range(1, numberOfGift);
        Debug.Log(indexRandom.ToString());
        float angleWant = (numberRotation * CIRCLE) + indexRandom * angleOfGift - startAngle;
        while (currentTime < timeRotation)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            float finalAngle = angleWant * curve.Evaluate(currentTime / timeRotation);
            this.transform.eulerAngles = new Vector3(0, 0, finalAngle + startAngle);
        }
        if (parrent.GetChild(indexRandom - 1).GetChild(2).gameObject.activeSelf == false) coutLucky++;
        this.parrent.GetChild(indexRandom - 1).GetChild(2).gameObject.SetActive(true);
        if (coutLucky == numberOfGift)
        {
            coutLucky = 0;

            for (int i = 0; i < parrent.childCount; i++)
            {
                this.parrent.GetChild(i).GetChild(2).gameObject.SetActive(false);
            }
        }

        GameManager.instance.LoadScenes(indexRandom);
    }

    IEnumerator playSound()
    {
        audioSource.PlayOneShot(clip);

        yield return new WaitForSeconds(timeRotation);

        audioSource.Stop();

    }


    [ContextMenu("Rotation")]
    private void WheelNow()
    {
        StartCoroutine(WheelRotation());
        StartCoroutine(playSound());
    }


}
