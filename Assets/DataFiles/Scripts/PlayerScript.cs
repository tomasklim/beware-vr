using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
  public int speed = 3;

  public bool moveForward = false;

  public int count;

  public Text ctext;

    // Start is called before the first frame update
    void Start()
    {
      Counter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
          moveForward = !moveForward;
        }

        if (moveForward) {
          transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

        if (transform.position.y < -15) {
          SceneManager.LoadScene("GameScene");
        }

    }

    public void OnTriggerEnter(Collider other) {
      if (other.gameObject.CompareTag("Present")) {
        Destroy(other.gameObject);
        count--;
        Counter();
      }

      if (count == 0 && other.gameObject.CompareTag("Tree")) {
        SceneManager.LoadScene("EndScene");
      }
    }

    public void Counter() {
      if (count > 0) {
        ctext.text = "Presents left: " + count.ToString();
      } else {
        ctext.text = "Go to a christmas tree!";
      }
    }
}
