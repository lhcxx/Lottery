﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace LotteryBuz
{
    public class Algorithm
    {
        public void FilterByAC(int min, int max, List<LotteryStageInfo> list){
            for (int k = list.Count - 1; k >= 0; k--){
                int ac = CalculateAC(list[k]);
                if (ac < min || ac > max)
                    list.RemoveAt(k);
            }
            ReorderList(list);
        }
        public int FilterByACL(int min, int max, List<LotteryStageInfo> list){
            int res = 0;
            int ac = 0;
            for (int k = 0; k < list.Count; k++)
            {
                ac = CalculateAC(list[k]);
                if (ac < min || ac > max)
                    res++;
            }
            return res;
        }

        private int CalculateAC(LotteryStageInfo info){
            int ac = 0;
            int[] arr = new[] { Int32.Parse(info.Red1), Int32.Parse(info.Red2), Int32.Parse(info.Red3), Int32.Parse(info.Red4), Int32.Parse(info.Red5), Int32.Parse(info.Red6) };
            int[] gap = new int[15];
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 6; j++)
                {
                    gap[k++] = Math.Abs(arr[i] - arr[j]);
                }
            }
            for (int i = 0; i < 14; i++){
                for (int j = i + 1; j < 15; j++){
                    if (gap[i] == gap[j])
                        gap[j] = -1;
                }
            }
            for (int i = 0; i < 15; i++){
                if (gap[i] > 0)
                    ac++;
            }
            return ac - 5;
        }

        private void ReorderList(List<LotteryStageInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Id = (i+1).ToString();
            }
        }
       
    }
}
