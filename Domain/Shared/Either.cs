using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public class Either<TL, TR>
    {
        private readonly TL left;
        private readonly TR right;
        private readonly bool isLeft;

        public Either(TL left)
        {
            this.left = left;
            this.isLeft = true;
        }

        public Either(TR right)
        {
            this.right = right;
            this.isLeft = false;
        }

        public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
            => this.isLeft ? leftFunc(this.left) : rightFunc(this.right);
    }
}
