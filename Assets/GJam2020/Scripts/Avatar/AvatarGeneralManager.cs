using UnityEngine;
using GJam2020.Level.UI;
using DG.Tweening;
using System.Collections;

namespace GJam2020.Avatar {
    public class AvatarGeneralManager : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TextMeshProUGUI _stepAdd;
        public static AvatarGeneralManager Get;
        private AvatarAnimator _animator;
        private PlayerMovement _movement;
        private BodyDestruction _bodyDestruction;
        private bool _isReverse = false;
        public AnimationState AnimationState { get; private set; }

        private void Start()
        {
            Get = this;
            _animator = GetComponent<AvatarAnimator>();
            _movement = GetComponent<PlayerMovement>();
            _bodyDestruction = GetComponent<BodyDestruction>();
        }

        public void StartMovement(float timeForDisplacement)
        {
            if (!_isReverse)
            {
                _bodyDestruction.DestroyBodyPart(timeForDisplacement);
            }
            _isReverse = false;

            SetStatus(AnimationState.WALKING);
        }

        public void IsReverseCommand()
        {
            _isReverse = true;
        }

        public void StopWalking()
        {
            SetStatus(AnimationState.IDLE);
        }

        public void SetStatus(AnimationState animationState)
        {
            AnimationState = animationState;
            _animator.SetState(animationState);
        }

        public void CapturePiece(int value)
        {
            if (_plusStepCoroutine != null) StopCoroutine(_plusStepCoroutine);

            _plusStepCoroutine = StartCoroutine(LabelBehavior(value));

            for (int i = 0; i < value; i++)
            {
                _bodyDestruction.ReconstructBodyPart();
            }
        }

        private Coroutine _plusStepCoroutine;

        public void StepBack()
        {
            if (_plusStepCoroutine != null) StopCoroutine(_plusStepCoroutine);

            _plusStepCoroutine = StartCoroutine(LabelBehavior(1));
        }

        public void Dead()
        {
            LevelMenuMgr.Get().OpenGameOver();
        }

        public void Restore()
        {
            
        }

        private IEnumerator LabelBehavior(int value)
        {
            _stepAdd.transform.DOKill();
            _stepAdd.text = "+" + value;
            _stepAdd.transform.localPosition = Vector3.zero;

            _stepAdd.gameObject.SetActive(true);
            _stepAdd.transform.DOLocalMoveY(Screen.height * 0.06f, 1);
            _stepAdd.material.DOFade(1, 1);
            yield return new WaitForSeconds(1.5f);
            _stepAdd.gameObject.SetActive(false);
        }
    }
}
