                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Permutation
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            CreatePartsByFreezingEachElementOnce("aba");

                            PrintPossiblePermutations(false);
                            Console.WriteLine("---------------");

                            PrintPossiblePermutations(true);
                            Console.ReadLine();
                        }

                        static void PrintPossiblePermutations(bool unique)
                        {
                            var allPermutations = new List<string>();
                            foreach (var item in _listWithFreezedKey)

                                if (item.Item2.Count() == 2)
                                {
                                    allPermutations.Add(CreateSting(String.Join(",", item.Item1), item.Item2[0], item.Item2[1]));
                                    allPermutations.Add(CreateSting(String.Join(",", item.Item1), item.Item2[1], item.Item2[0]));
                                }

                            if (unique)
                            {
                                var uniuePermutations = allPermutations.Distinct();
                                   PrintPermutations(uniuePermutations.ToList());
                                Console.WriteLine(uniuePermutations.Count());
                            }
                            else
                            {
                                   PrintPermutations(allPermutations);
                                Console.WriteLine(allPermutations.Count());
                            }

                        }

                        static void PrintPermutations(List<string> permutations)
                        {
                            int i = 1;
                            foreach (var item in permutations)
                            {
                                Console.WriteLine(string.Format("{0}    :{1}", i, item));
                                i++;
                            }
                        }

                        static List<Tuple<List<char>, List<char>>> _listWithFreezedKey = new List<Tuple<List<char>, List<char>>>();

                        static void CreatePartsByFreezingEachElementOnce(string str, List<char> indexToFreeze = null)
                        {
                            List<Tuple<List<char>, List<char>>> _innerlistWithFreezedKey = new List<Tuple<List<char>, List<char>>>();

            
                            var arr = str.ToCharArray().ToList();
                            var copy = arr;
                            if (indexToFreeze == null)
                            {
                                indexToFreeze = new List<char>();
                            }
                            for (int i = 0; i < arr.Count(); i++)
                            {
                                copy = str.ToCharArray().ToList();
                                var nth = arr[i];
                                copy.RemoveAt(i);

                                indexToFreeze.Add(nth);

                                _listWithFreezedKey.Add(new Tuple<List<char>, List<char>>(indexToFreeze.ToList(), copy));
                                _innerlistWithFreezedKey.Add(new Tuple<List<char>, List<char>>(indexToFreeze.ToList(), copy));

                                indexToFreeze.RemoveAt(indexToFreeze.Count() - 1);
                            }

                            foreach (var item in _innerlistWithFreezedKey)
                            {                              
                                    List<char> l = item.Item2;
                                    CreatePartsByFreezingEachElementOnce(String.Join("", l), item.Item1);
                             }


                            }

                            static string CreateSting(string frezedPart, char swapChar1, char swapChar2)
                            {
                                return frezedPart + "," + swapChar1 + "," + swapChar2;
                            }
                    }
                }
