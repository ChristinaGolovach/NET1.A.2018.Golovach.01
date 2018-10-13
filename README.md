# NET1.A.2018.Golovach.01  - (deadline 13.10.2018, 24.00)

# Задание
Реализовать методы быстрой сортировки и сортировки слиянием для целочисленного массива (тип проекта Class Library). 
Протестировать работу методов с использованием тестовых фреймворков NUnit и MS Tests. 
Рассмотреть вариант тестирования массивов большой размерности, элементы которых сгенерированны случайным образом.

//TODO 
Why in Logic.NUnitTests project in SortingTests.cs class NUnit framework gives error for such maner of test:

private static int[] randomArray = GenerateLargeRandomArray(1000)
 
[Test, TestCaseSource(nameof(randomArray))]
public void MergeSort_TakeUnsortedArray_ReturnSortedArray(int[] array) { .... }
