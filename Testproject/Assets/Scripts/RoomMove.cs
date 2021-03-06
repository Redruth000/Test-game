using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChangeMax;
    public Vector2 cameraChangeMin;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    //public Text placeText;
    public TextMeshProUGUI placeTextTEST;
    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition.x = cameraChangeMin.x;
            cam.minPosition.y = cameraChangeMin.y;
            cam.maxPosition.x = cameraChangeMax.x;
            cam.maxPosition.y = cameraChangeMax.y;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeTextTEST.text = placeName;
        yield return new WaitForSeconds(3f);
        placeTextTEST.CrossFadeAlpha(0, 0.25f, false);
        yield return new WaitForSeconds(1f);
        text.SetActive(false);
    }
}
