
using System;

using UnityEngine;

namespace FarmerSim.Mud
{
    public interface ICrop
    {
        event Action<ICrop> OnSnipped;

        void Grow(float riseDelta);

        void Snip();

        Vector3 GetCropPackInstantiatePosition();
    }
}