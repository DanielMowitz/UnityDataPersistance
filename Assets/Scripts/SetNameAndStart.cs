using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SetNameAndStart : MonoBehaviour
{
	 public TextMeshProUGUI PName;
	 public Button StartButton;

	 // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    void StartGame()
	 {
			PlayerName.Instance.PName = PName.text;
			SceneManager.LoadScene(1);
	 }
}
