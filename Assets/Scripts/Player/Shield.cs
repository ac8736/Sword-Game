using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerController controller;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI emergencyTMP;
    public GameObject immuneShield;
    public AudioClip shieldedsound;
    public AudioSource audiosource;
    private bool isIFramed = false;

    private bool canIFrame = true;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = shieldedsound;

    }
    private void Update()
    {
        textMeshPro.text = "Shield: " + controller.shieldPercentage + "%";
        immuneShield.SetActive(isIFramed);
        emergencyTMP.text = "Emergency Shields: " + (canIFrame || isIFramed ? "Active" : "Inactive");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Barrier") && controller.isActiveShield)
        {
            audiosource.Play();
            Destroy(other.gameObject);
        } 
        else
        {
            if (!isIFramed)
            {
                if (canIFrame)
                {
                    StartCoroutine(IFrame());
                    StartCoroutine(IFrameCD());
                }
                else
                {
                    controller.health += 20;
                }
            }
        }
    }

    IEnumerator IFrame()
    {
        isIFramed = true;
        yield return new WaitForSeconds(1);
        isIFramed = false;
    }

    IEnumerator IFrameCD()
    {
        canIFrame = false;
        yield return new WaitForSeconds(10);
        canIFrame = true;
    }
}
