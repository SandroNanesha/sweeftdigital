using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweeftDigitalSolutions
{
    //#6
    class ConstantRemoveTimeClass
    {
        List<int> arr;
        Dictionary<int, int> map;

        public ConstantRemoveTimeClass()
        {
            arr = new List<int>();
            map = new Dictionary<int, int>();
            
        }


        public void AddElem(int elem)
        {
            if (map.ContainsKey(elem))
                return;

            int index = arr.Count;
            arr.Add(elem);
            map.Add(elem, index);
        }

        public void RemoveElem(int elem)
        {
            if (!map.ContainsKey(elem))
                return;

            int index = map[elem];
            map.Remove(elem);

            int last = arr.Count - 1;

            Swap(arr, index, last);
            arr.RemoveAt(last);

            map[arr[index]] = index;
        }

        private static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        public override string ToString()
        {
            String res = "";

            for(int i=0; i<arr.Count; i++)
            {
                res += arr[i].ToString() + ',';
            }
            if(arr.Count !=0)
                return res.Substring(0, res.Length - 1);
            return "";
        }
    }
}
