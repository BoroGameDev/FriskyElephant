using System;
using UnityEngine;

namespace FriskyElephant.Cards {
  public abstract class Effect : ScriptableObject {
    [SerializeField]
    protected string Description;

    public event EventHandler OnEffectCompleted;

    public override string ToString() => $"{Description}\n";

    public string GetDescription() => Description;

    public virtual void Invoke() {
      OnEffectCompleted?.Invoke(this, EventArgs.Empty);
    }
  }
}
