// -----------------------------------------------------------------------
//  <copyright company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace ZhijieLi.CommonUtility.DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ListNode<T>
    {
        private ListNode<T> Next { get; set; }

        public T Data { get; set; }
    }

    public class List<T>
    {
        public int Size { get; set; }

        public void Append(T data)
        {
            
        }
    }
}
