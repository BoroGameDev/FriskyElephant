using System.Collections.Generic;
using UnityEngine;
using FriskyElephant.Cards;

public class DeckManager : MonoBehaviour {
  public static DeckManager Instance { get; private set; }

  private static System.Random RNG = new System.Random();  

  private void Awake() {
    if (Instance != null) {
      Debug.LogError("There's more than one DeckManager! " + transform + " - " + Instance);
      Destroy(gameObject);
    }

    Instance = this;
  }

  [SerializeField]
  private GameObject DeckOverlay;

  [SerializeField]
  private GameObject HandOverlay;

  [SerializeField]
  private GameObject cardVisualPrefab;

  [SerializeField]
  private bool ShuffleOnShow;

  [SerializeField]
  private List<Card> Deck;

  private List<Card> ActiveDeck;
  private List<Card> Hand = new List<Card>();
  private List<Card> Discard = new List<Card>();

  private bool showingDeck;

  private enum TurnPhase {
    Draw,
    Play,
    End,
    Enemy
  }

  private TurnPhase phase;

  private bool handDirty;

  void Start() {
    ActiveDeck = new List<Card>(Deck);
    Shuffle(ActiveDeck);
    phase = TurnPhase.Draw;
  }

  public void Update() {
    HandleTurnPhases();
    HandleHandCards();
  }

  public void HandleTurnPhases() {
    switch (this.phase) {
      case TurnPhase.Draw:
        DrawCards(5);
        phase = TurnPhase.Play;
        break;
      case TurnPhase.Play:
        // Do stuff here later...
        break;
      case TurnPhase.End:
        DiscardHand();
        phase = TurnPhase.Enemy;
        break;
      case TurnPhase.Enemy:
        print("Enemy does stuff");
        phase = TurnPhase.Draw;
        break;
    }
  }

  private void HandleHandCards() {
    if (!handDirty) { return; }

    foreach (Transform child in HandOverlay.transform) {
      GameObject.Destroy(child.gameObject);
    }

    foreach (Card card in Hand) {
      GameObject cardGO = Instantiate(cardVisualPrefab, HandOverlay.transform);
      CardVisualUI visual = cardGO.GetComponent<CardVisualUI>();
      visual.Init(card);
    }

    handDirty = false;
  }

  public void DrawCards(int num) {
    int remaining = num;

    if (num > this.ActiveDeck.Count) {
      remaining = num - this.ActiveDeck.Count;
      print($"Deck has: {this.ActiveDeck.Count}\ndrawing: {num}\nremaining: {remaining}");

      for (int i = 0; i < this.ActiveDeck.Count; i++) {
        Card card = this.ActiveDeck[0];
        this.ActiveDeck.RemoveAt(0);
        this.Hand.Add(card);
      }

      this.ActiveDeck = new List<Card>(this.Discard);
      this.Discard.Clear();
      Shuffle(this.ActiveDeck);
    }

    for (int i = 0; i < remaining; i++) {
      Card card = this.ActiveDeck[0];
      this.ActiveDeck.RemoveAt(0);
      this.Hand.Add(card);
    }

    handDirty = true;
  }

  public void DiscardCard(Card card) {
    this.Hand.Remove(card);
    this.Discard.Add(card);
    handDirty = true;
  }

  public void DiscardHand() {
    foreach(Card card in this.Hand) {
      this.Discard.Add(card);
    }
    this.Hand.Clear();
    handDirty = true;
  }

  public void OnDeckButtonClick() {
    if (showingDeck) {
      DeckOverlay.SetActive(false);
    } else {
      ShowDeckUI(ShuffleOnShow);
    }

    showingDeck = !showingDeck;
  }

  public void OnEndTurnButtonClick() {
    phase = TurnPhase.End;
  }

  private void ShowDeckUI(bool Shuffled) {
    List<Card> DeckToShow = ActiveDeck;

    foreach (Transform child in DeckOverlay.transform) {
      GameObject.Destroy(child.gameObject);
    }

    if (Shuffled) {
      Shuffle(DeckToShow);
    }

    foreach (Card card in DeckToShow) {
      GameObject cardGO = Instantiate(cardVisualPrefab, DeckOverlay.transform);
      CardVisualUI visual = cardGO.GetComponent<CardVisualUI>();
      visual.Init(card);
    }

    DeckOverlay.SetActive(true);
  }

  public void Shuffle(List<Card> list)  {  
    int n = list.Count;  
    while (n > 1) {  
      n--;  
      int k = RNG.Next(n + 1);  
      Card value = list[k];  
      list[k] = list[n];  
      list[n] = value;  
    }  
  }
}
