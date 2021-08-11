using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace TestProjectOne
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            BaseExample<string> data = new BaseExample<string>("name_235");
            BaseExample<int> data1 = new SaveData<int>(3775);
            SaveData<Guid> data2 = new SaveData<Guid>(Guid.NewGuid());
        }
    }
}