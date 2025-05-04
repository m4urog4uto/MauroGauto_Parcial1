using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraEnd : MonoBehaviour
{
    public float maxY = 6.52f;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime;
        if (transform.position.x > 23)
        {
            transform.eulerAngles = new Vector3(0, 90 + 35f, 0);
            if (transform.position.x > 58)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
