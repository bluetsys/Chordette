﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Chordette
{
    [Serializable]
    public class StructuralEqualityComparer : IEqualityComparer, IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            var s = x as IStructuralEquatable;
            return s == null ? object.Equals(x, y) : s.Equals(y, this);
        }

        public int GetHashCode(object obj)
        {
            var s = obj as IStructuralEquatable;
            return s == null ? EqualityComparer<object>.Default.GetHashCode(obj) : s.GetHashCode(this);
        }
    }
}