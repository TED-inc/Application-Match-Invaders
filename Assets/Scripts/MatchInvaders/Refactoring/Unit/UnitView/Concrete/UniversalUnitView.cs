using System;
using UnityEngine;
using UnityEngine.UI;
using TEDinc.MatchInvaders.Effect;
using TEDinc.MatchInvaders.Effect.Concrete;

namespace TEDinc.MatchInvaders.Unit.Concrete
{
    public sealed class UniversalUnitView : MonoBehaviour, IUnitView
    {
        public IReadUnitModel UnitModel { get; private set; }
        public IReadUnitController UnitController { get; private set; }

        private IReadUnitPostionModel unitPostionModel;
        private IReadUnitHealthModel unitHealthModel;
        private IReadUnitWeaponModel unitWeaponModel;

        [SerializeField]
        private Image groupImage;
        [SerializeField]
        private Vector2 effectSpawnOffset;
        [SerializeField]
        private Vector2 effectSpawnDirection = Vector2.up;
        [SerializeField]
        private UniversalEffectSource effectSoursePrototype;

        public void ApplyEffect(IEffect effect) =>
            UnitController.ApplyEffect(effect);

        public void Setup(IReadUnitModel unitModel, IReadUnitController unitController)
        {
            UnitModel = unitModel;
            UnitController = unitController;

            if (UnitModel.ContainsSubModel(UnitSubModelType.Position))
            {
                unitPostionModel = UnitModel.GetSubModel<IReadUnitPostionModel>(UnitSubModelType.Position);
                transform.localPosition = unitPostionModel.Position.Value;
                unitPostionModel.Position.OnChange += OnModelChangePosition;
            }
            if (UnitModel.ContainsSubModel(UnitSubModelType.Health))
            {
                unitHealthModel = UnitModel.GetSubModel<IReadUnitHealthModel>(UnitSubModelType.Health);
                unitHealthModel.IsAlive.OnChange += OnModelChangeIsAlive;
            }
            if (UnitModel.ContainsSubModel(UnitSubModelType.Weapon))
            {
                unitWeaponModel = UnitModel.GetSubModel<IReadUnitWeaponModel>(UnitSubModelType.Weapon);
                unitWeaponModel.OnSpawnEffect += OnModelSpawnEffect;
            }
            if (UnitModel.ContainsSubModel(UnitSubModelType.Group))
                SetGroup(UnitModel.GetSubModel<IReadUnitGroupModel>(UnitSubModelType.Group).GroupId);
        }

        private void OnDestroy()
        {
            if (unitPostionModel != null)
                unitPostionModel.Position.OnChange -= OnModelChangePosition;
            if (unitHealthModel != null)
                unitHealthModel.IsAlive.OnChange -= OnModelChangeIsAlive;
            if (unitWeaponModel != null)
                unitWeaponModel.OnSpawnEffect -= OnModelSpawnEffect;
        }

        private void OnModelChangePosition(Vector2 position) =>
            transform.localPosition = position;

        private void OnModelChangeIsAlive(bool isAlive)
        {
            gameObject.SetActive(isAlive);
            if (!isAlive)
                Destroy(gameObject);
        }

        private void OnModelSpawnEffect(IEffect effect)
        {
            UniversalEffectSource effectSource = Instantiate(effectSoursePrototype, EffectSourceParent.Instance);
            effectSource.transform.position = transform.position + transform.TransformVector((Vector3)effectSpawnOffset);
            effectSource.transform.up = effectSpawnDirection;
            effectSource.Setup(effect);
        }

        private void SetGroup(int id)
        {
            groupImage.color = GetColor();

            Color GetColor()
            {
                switch (id)
                {
                    case 0:
                        return Color.red;
                    case 1:
                        return Color.green;
                    case 2:
                        return Color.blue;
                    case 3:
                        return Color.yellow;
                    default:
                        throw new NotImplementedException($"Not supported Id {id}");
                }
            }
        }
    }
}