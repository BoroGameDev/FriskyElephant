using UnityEngine;

namespace FriskyElephant.Cards {

  [CreateAssetMenu(menuName = "Cards/New Status Effect")]
  public class StatusEffect : Effect {
    [SerializeField]
    private StatusType Status;
    [SerializeField]
    private int StatusAmount;

    public override string ToString() {
      return $"Apply {StatusAmount} {Status}";
    }
  }
}

