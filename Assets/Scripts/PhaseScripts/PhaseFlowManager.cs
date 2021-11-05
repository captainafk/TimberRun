using System;
using System.Collections.Generic;
using UnityEngine;

public class PhaseFlowManager : Singleton<PhaseFlowManager>
{
    [SerializeField] private List<BasePhase> _phases;

    private LinkedList<BasePhase> _phaseLinkedList = new LinkedList<BasePhase>();
    private LinkedListNode<BasePhase> _currentPhase;

    public Action<BasePhase> OnPhaseStarted;
    public Action<BasePhase> OnPhaseFinished;

    private void Awake()
    {
        foreach (var phase in _phases)
        {
            var phaseNode = new LinkedListNode<BasePhase>(phase);

            _phaseLinkedList.AddLast(phaseNode);
        }

        _currentPhase = _phaseLinkedList.First;
        _currentPhase.Value.OnEnterActions();
    }

    public void Traverse()
    {
        // End the game
        if (_currentPhase == null)
        {
        }

        _currentPhase.Value.OnExitActions();
        OnPhaseFinished?.Invoke(_currentPhase.Value);

        _currentPhase = _currentPhase.Next;

        _currentPhase.Value.OnEnterActions();
        OnPhaseStarted?.Invoke(_currentPhase.Value);
    }

    // For debugging purposes
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Traverse();
        }
    }
}