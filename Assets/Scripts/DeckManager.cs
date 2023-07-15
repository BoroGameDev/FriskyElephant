using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {
  public static DeckManager Instance { get; private set; }

  private void Awake() {
    if (Instance != null) {
      Debug.LogError("There's more than one DeckManager! " + transform + " - " + Instance);
      Destroy(gameObject);
    }

    Instance = this;
  }

  [SerializeField]
  private List<Card> Deck;
  private List<Card> Hand = new List<Card>();
  private List<Card> Discard = new List<Card>();

}
