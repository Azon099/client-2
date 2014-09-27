﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenFX.Core
{
    public class Model
    {
        private int m_hash;
        private string m_name;

        public Model(int hash)
        {
            m_hash = hash;
            m_name = String.Empty;
        }

        public Model(uint hash)
        {
            m_hash = Convert.ToInt32(hash);
            m_name = string.Empty;
        }

        public Model(string modelName)
        {
            m_name = modelName;
            m_hash = Function.Call<int>(Natives.GET_HASH_KEY, m_name);
        }

        public uint Handle
        {
            get
            {
                return Convert.ToUInt32(m_hash);
            }
        }

        public int Hash
        {
            get
            {
                return m_hash;
            }
        }

        public bool isInMemory
        {
            get
            {
                try
                {
                    return Function.Call<bool>(Natives.HAS_MODEL_LOADED, m_hash);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool isCollisionDataInMemory
        {
            get
            {
                return Function.Call<bool>(Natives.HAS_COLLISION_FOR_MODEL_LOADED, m_hash);
            }
        }

        public bool isValid
        {
            get
            {
                if (m_hash == 0) return false;
                try
                {
                    return Function.Call<bool>(Natives.HAS_MODEL_LOADED, m_hash);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void LoadToMemory()
        {
            if (m_hash == 0) return;
            try
            {
                Function.Call(Natives.REQUEST_MODEL, m_hash);
            }
            catch { }
        }

        public bool LoadToMemoryNow(int timeout)
        {
            // Dummy, don't think this'll work with Citizen straightaway
            return false;
        }

        public bool LoadToMemoryNow()
        {
            return LoadToMemoryNow(1000);
        }

        public void LoadCollisionDataToMemory()
        {
            if (m_hash == 0) return;
            Function.Call(Natives.REQUEST_COLLISION_FOR_MODEL, m_hash);
        }

        public bool LoadCollisionDataToMemoryNow(int timeout)
        {
            // Dummy, don't think this'll work with Citizen straightaway
            return false;
        }

        public void AllowDisposeFromMemory()
        {
            if (m_hash == 0) return;
            Function.Call(Natives.MARK_MODEL_AS_NO_LONGER_NEEDED, m_hash);
        }

        /*public void GetDimensions(ref Vector3 MinVector, ref Vector3 MaxVector)
        {
            Pointer pV1 = typeof(Vector3);
            Pointer pV2 = typeof(Vector3);
            Vector3 v1, v2;

            Function.Call(Natives.GET_MODEL_DIMENSIONS, pHash, v1, v1);

            v1 = (Vector3)pV1;
            v2 = (Vector3)pV2;

            MinVector.X = v1.X; MinVector.Y = v1.Y; MinVector.Z = v1.Z;
            MaxVector.X = v2.X; MaxVector.Y = v2.Y; MaxVector.Z = v2.Z;
        }

        public Vector3 GetDimensions()
        {
            Pointer pV1 = typeof(Vector3);
            Pointer pV2 = typeof(Vector3);
            Vector3 v1, v2;

            Function.Call(Natives.GET_MODEL_DIMENSIONS, pHash, pV1, pV2);

            return new Vector3(v2.X - v1.X, v2.Y - v1.Y, v2.Z - v1.Z);
        }*/

        public bool isBike
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_BIKE, m_hash);
            }
        }

        public bool isBoat
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_BOAT, m_hash);
            }
        }

        public bool isCar
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_CAR, m_hash);
            }
        }

        public bool isHelicopter
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_HELI, m_hash);
            }
        }

        public bool isPed
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_PED, m_hash);
            }
        }

        public bool isPlane
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_PLANE, m_hash);
            }
        }

        public bool isTrain
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_TRAIN, m_hash);
            }
        }

        public bool isVehicle
        {
            get
            {
                if (m_hash == 0) return false;
                return Function.Call<bool>(Natives.IS_THIS_MODEL_A_VEHICLE, m_hash);
            }
        }

        public Model BasicCopModel
        {
            get
            {
                Pointer model = typeof(int);
                Function.Call(Natives.GET_CURRENT_BASIC_COP_MODEL, model);
                return new Model((int)model);
            }
        }

        public Model CurrentCopModel
        {
            get
            {
                Pointer model = typeof(int);
                Function.Call(Natives.GET_CURRENT_COP_MODEL, model);
                return new Model((int)model);
            }
        }

        public Model BasicPoliceCarModel
        {
            get
            {
                Pointer model = typeof(int);
                Function.Call(Natives.GET_CURRENT_BASIC_POLICE_CAR_MODEL, model);
                return new Model((int)model);
            }
        }

        public Model CurrentPoliceCarModel
        {
            get
            {
                Pointer model = typeof(int);
                Function.Call(Natives.GET_CURRENT_POLICE_CAR_MODEL, model);
                return new Model((int)model);
            }
        }

        public Model TaxiCarModel
        {
            get
            {
                Pointer model = typeof(int);
                Function.Call(Natives.GET_CURRENT_TAXI_CAR_MODEL, model);
                return new Model((int)model);
            }
        }

        public Model GetWeaponModel(Weapon wep)
        {
            Pointer model = typeof(int);
            Function.Call(Natives.GET_WEAPONTYPE_MODEL, (int)wep, model);
            return new Model((int)model);
        }
    }
}
