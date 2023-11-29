using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageBubble : MonoBehaviour
{
    [SerializeField] GameObject playerCar; //to reference the car player object
    [SerializeField] Color32 hasPackageColor1 = new Color32 (255,52,52,255); //first color for bubble shake can swap into
    [SerializeField] Color32 hasPackageColor2 = new Color32 (255,14,14,255); //second color for bubble shake can swap into
    [SerializeField] float shakeTimer = 1.5f; //how much time the bubble shakes
    [SerializeField] float shakeDistance = 0.15f; //controls how far the bubble can shake
    private float shakeVariable; //stores the amount of bubble shake for each frame
    private float shakeTime; //stores the current elapsed duration of the bubble shake
    SpriteRenderer spriteRenderer; //variable that stores the sprite renderer component of the package bubble game object


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //gets the SpriteRenderer component of the package bubble game object
        spriteRenderer.GetComponent<Renderer>().enabled = false;
    }

    public void shakeBubble() 
    {
        Debug.Log("You already have a package.");
        StopAllCoroutines();
        StartCoroutine(startShake());
        StartCoroutine(startColor());
    }

    private IEnumerator startColor(){

        for (int i = 0; i < 2; i++){
            spriteRenderer.color = hasPackageColor1;
            yield return new WaitForSeconds(shakeTimer/4f);
            spriteRenderer.color = hasPackageColor2;
            yield return new WaitForSeconds(shakeTimer/4f);
            Debug.Log(i);
        }
        spriteRenderer.color = new Color32 (255,255,255,255);
    }

    private IEnumerator startShake() 
    {
        shakeTime = 0f;
        while (shakeTime < shakeTimer)
        {   
            shakeTime += Time.deltaTime;
            shakeVariable = Random.Range(-0.5f,0.5f) * shakeDistance;
            yield return null;
        }
        shakeVariable = 0.0f;
    }

    void LateUpdate()
    {
        transform.position = playerCar.transform.position + new Vector3 (3 +shakeVariable, -1 +shakeVariable, 0);
    }
}