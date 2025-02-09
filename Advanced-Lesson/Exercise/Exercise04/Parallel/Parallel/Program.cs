/* Pattern theo cấp độ
1. System: phân tán, microservice,... ?
2. Software: 3 layer...?
3. Package 
4. Class-Method 
*/

using System.Diagnostics;

namespace Parallel
{
    class Program
    {
        const int Iterations = 1000;    //Số lần lặp lại
		const int ListSize = 10000;     //Số lượng số nguyên ngẫu nhiên trên mỗi danh sách

		static void Main(string[] args)
        {
			//Tạo một Random duy nhất cho toàn bộ quá trình chạy
			Random random = new Random();

            //Từ điển để đếm số lần mỗi thuật toán nhanh nhất
            Dictionary<string, int> fastestCounts = new Dictionary<string, int>
            {
                { "QuickSort", 0 },
                { "MergeSort", 0 },
                { "HeapSort", 0 },
                { "BubbleSort", 0 },
                { "BuiltIn", 0 }
            };

            //Tổng thời gian đã trôi qua để chúng ta có thể tính thời gian trung bình
            Dictionary<string, long> totalTimes = new Dictionary<string, long>
            {
                { "QuickSort", 0 },
                { "MergeSort", 0 },
                { "HeapSort", 0 },
                { "BubbleSort", 0 },
                { "BuiltIn", 0 }
            };

            for (int iter = 0; iter < Iterations; iter++)
            {
				//1. Tạo danh sách ban đầu của các số nguyên ngẫu nhiên
				List<int> original = new List<int>(ListSize);
                for (int i = 0; i < ListSize; i++)
                {
                    original.Add(random.Next());
                }

				//2. Sao chép danh sách gốc thành năm danh sách riêng biệt (mỗi danh sách cho một thuật toán)
				List<int> listQuick = new List<int>(original);
                List<int> listMerge = new List<int>(original);
                List<int> listHeap = new List<int>(original);
                List<int> listBubble = new List<int>(original);
                List<int> listBuiltIn = new List<int>(original);

				//3. Tạo năm nhiệm vụ sắp xếp song song

				//QuickSort
				var taskQuick = Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    QuickSort(listQuick, 0, listQuick.Count - 1);
                    sw.Stop();
                    return Tuple.Create("QuickSort", sw.ElapsedMilliseconds);
                });

				//MergeSort (MergeSort của trả về một danh sách được sắp xếp mới)
				var taskMerge = Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    listMerge = MergeSort(listMerge);
                    sw.Stop();
                    return Tuple.Create("MergeSort", sw.ElapsedMilliseconds);
                });

                //HeapSort
                var taskHeap = Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    HeapSort(listHeap);
                    sw.Stop();
                    return Tuple.Create("HeapSort", sw.ElapsedMilliseconds);
                });

                //BubbleSort
                var taskBubble = Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    BubbleSort(listBubble);
                    sw.Stop();
                    return Tuple.Create("BubbleSort", sw.ElapsedMilliseconds);
                });

                //Built-in Sort
                var taskBuiltIn = Task.Run(() =>
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    listBuiltIn.Sort();
                    sw.Stop();
                    return Tuple.Create("BuiltIn", sw.ElapsedMilliseconds);
                });

				//4. Chờ tất cả các Task hoàn thành và nhận thời gian
				Task.WaitAll(taskQuick, taskMerge, taskHeap, taskBubble, taskBuiltIn);

				//Thu thập kết quả trong một danh sách
				var results = new List<Tuple<string, long>>
                {
                    taskQuick.Result,
                    taskMerge.Result,
                    taskHeap.Result,
                    taskBubble.Result,
                    taskBuiltIn.Result
                };

				//Xác định thuật toán nào là nhanh nhất cho lần lặp này
                //(Tính bằng mili giây trôi qua thấp nhất)
				var fastest = results.OrderBy(t => t.Item2).First();
                fastestCounts[fastest.Item1]++;

				//Tích lũy tổng thời gian cho tính toán trung bình sau này
				foreach (var result in results)
                {
                    totalTimes[result.Item1] += result.Item2;
                }

				//In thời gian cho mỗi lần lặp lại
				Console.WriteLine(
                    $"Iteration {iter + 1}: " +
                    $"QuickSort = {taskQuick.Result.Item2} ms, " +
                    $"MergeSort = {taskMerge.Result.Item2} ms, " +
                    $"HeapSort = {taskHeap.Result.Item2} ms, " +
                    $"BubbleSort = {taskBubble.Result.Item2} ms, " +
                    $"BuiltIn = {taskBuiltIn.Result.Item2} ms. " +
                    $"Fastest: {fastest.Item1}");
            }

			//5. Sau tất cả các lần lặp lại, hiển thị số liệu thống kê cuối cùng
			Console.WriteLine("\nFinal Statistics:");
            Console.WriteLine("Algorithm\tFastest Count\tAverage Time (ms)");
            foreach (var algo in fastestCounts.Keys)
            {
                double avgTime = totalTimes[algo] / (double)Iterations;
                Console.WriteLine($"{algo}\t\t{fastestCounts[algo]}\t\t{avgTime:F2}");
            }

			//Chờ người dùng nhập dữ liệu trước khi đóng (tùy chọn)
			Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        #region Sorting Algorithm Implementations

        /// <summary>
        /// Implements QuickSort on a List in place.
        /// </summary>
        static void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (list[j] <= pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, right);
            return i + 1;
        }

        /// <summary>
        /// Implements MergeSort and returns a new sorted list.
        /// </summary>
        static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;
            List<int> left = list.GetRange(0, mid);
            List<int> right = list.GetRange(mid, list.Count - mid);

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                {
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    result.Add(right[j]);
                    j++;
                }
            }
            // Append remaining elements, if any
            result.AddRange(left.Skip(i));
            result.AddRange(right.Skip(j));
            return result;
        }

        /// <summary>
        /// Implements HeapSort on a List in place.
        /// </summary>
        static void HeapSort(List<int> list)
        {
            int n = list.Count;

            // Build the heap (rearrange the list)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(list, n, i);

            // One by one extract an element from the heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                Swap(list, 0, i);

                // Call max heapify on the reduced heap
                Heapify(list, i, 0);
            }
        }

        static void Heapify(List<int> list, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && list[left] > list[largest])
                largest = left;

            if (right < n && list[right] > list[largest])
                largest = right;

            if (largest != i)
            {
                Swap(list, i, largest);
                Heapify(list, n, largest);
            }
        }

        /// <summary>
        /// Implements BubbleSort on a List in place.
        /// </summary>
        static void BubbleSort(List<int> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                        swapped = true;
                    }
                }
                // If no two elements were swapped by inner loop, then break
                if (!swapped)
                    break;
            }
        }

        /// <summary>
        /// Swaps two elements in a list.
        /// </summary>
        static void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        #endregion
    }
}
