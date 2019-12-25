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

  public int level = 0;

  private bool falling = false;

  public Text ctext;

  public AudioClip CollectClip;

  public AudioSource CollectMusicSource;

  public AudioClip FallingClip;

  public AudioSource FallingMusicSource;

    // Start is called before the first frame update
    void Start()
    {
      Counter();
      CollectMusicSource.clip = CollectClip;
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
           SceneManager.LoadScene(Application.loadedLevel);
           FallingMusicSource.Stop();
        }

        if (!falling) {
          if (transform.position.y < -3) {
            falling = true;
            FallingMusicSource.Play();
          }
        }

    }

    public void OnTriggerEnter(Collider other) {
      if (other.gameObject.CompareTag("Present")) {
        Destroy(other.gameObject);
        count--;
        CollectMusicSource.Play();
        Counter();
      }

      if (count == 0 && other.gameObject.CompareTag("Tree")) {
        if (level == 1) {
          SceneManager.LoadScene("Level1CompleteScene");
        } else {
          SceneManager.LoadScene("EndScene");
        }
      }
    }

    public void Counter() {
      if (count > 0) {
        ctext.text = "Presents left : " + count.ToString();
      } else {
        ctext.text = "Go to a Christmas Tree";
      }
    }
}
