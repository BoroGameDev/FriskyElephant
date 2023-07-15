using UnityEngine;

namespace FriskyElephant.Cards {

  [CreateAssetMenu(menuName = "Cards/New Block Effect")]
  public class BlockEffect : Effect {
    [SerializeField]
    private int BlockAmount;
  }
}

