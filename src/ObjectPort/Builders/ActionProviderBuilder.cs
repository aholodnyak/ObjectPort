﻿#region License
//Copyright(c) 2016 Dmytro Mukalov

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

namespace ObjectPort.Builders
{
    using Common;
    using System;
    using System.IO;
    using System.Linq.Expressions;

    internal abstract class ActionProviderBuilder<T> : MemberSerializerBuilder, ICompiledActionProvider<T>
    {
        public Action<T, BinaryWriter> GetSerializerAction(Type memberType, ParameterExpression valueExp, ParameterExpression writerExp)
        {
            return Expression.Lambda<Action<T, BinaryWriter>>(
                GetSerializerExpression(memberType, valueExp, writerExp), valueExp, writerExp).Compile();
        }

        public Func<BinaryReader, T> GetDeserializerAction(Type memberType, ParameterExpression readerExp)
        {
            return Expression.Lambda<Func<BinaryReader, T>>(
                GetDeserializerExpression(memberType, readerExp), readerExp).Compile();
        }
    }
}
