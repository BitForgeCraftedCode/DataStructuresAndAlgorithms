# Big O Definition

We say that an algorithm is **O(f(n))** if the number of simple operations the computer has to do is
eventually less than a constant times **f(n)**, as **n** increases.

Definition: A theoretical measure of the execution of an algorithm, usually the time or memory needed, given the problem size n, which is usually the number of items. Informally, saying some equation f(n) = O(g(n)) means it is less than some constant multiple of g(n). The notation is read, "f of n is big oh of g of n".

[formal definition here](https://xlinux.nist.gov/dads/HTML/bigOnotation.html)

It is a way of measuring how complex the algortihm is or how many operations must be done for the given algorithm.
Count the operations. The more complex the algorthim the longer it will take to run. Time complexitey

The same idea can be applied to space complexity: how much pc memory do we need to allocate for our code/algorthim.

technically this is called auxiliary space compexity: the space required by the algorthim, NOT including space taken up by the inputs.

* f(n) could be linear f(n) = n
* f(n) could be quadratic f(n) = n^2
* f(n) could be constant f(n) = 1
* f(n) could be something entirely different.

For example the two functions below to find the sum of the first n natural numbers.

* in a loop, the complexity is the length of the loop times the complexity of whatever happens inside the loop

## 1st function 
	int AddUpTo(int n)
	{
		int total = 0; //1 assignment 1 declaration
		for(int i = 1; i <= n; i++) //1 assignment 1 declaration n+1 comparisons i++ has n additions n assignments 
		{
			total += i; //n additions n assignments
			//total = total + i; 
		}
		return total; //1 return
	}
	// 2 + 2 + n+1 +2n + 2n + 1
	// hence we have 5n + 6 or a linear 
	Console.WriteLine(AddUpTo(3));
	
	function addUpTo(n) {
		let total = 0; //1 assignment 
		for (let i = 1; i <= n; i++) {
			total += i; //n additions and n assignments
		}
		return total;
	}

	var t1 = performance.now();
	addUpTo(1000000000);
	var t2 = performance.now();
	console.log(`Time Elapsed: ${(t2 - t1) / 1000} seconds.`);

This function has 5n + 2 operations 
Thus a Big O of n O(n) -- f(n) = 5n + 2 is linear

## 2nd function
	function addUpTo(n) {
	  return n * (n + 1) / 2;
	}

	var time1 = performance.now();
	addUpTo(1000000000);
	var time2 = performance.now();
	console.log(`Time Elapsed: ${(time2 - time1) / 1000} seconds.`);

This function has 3 simple operations no matter how big n is. (multiply, add, and divide) always 3 operations
Thus a Big O of 1 O(1) -- f(n) = 3 is constant

## Another example nested loops

	function printAllPairs(n) {
		for(var i = 0; i < n; i++){		
			for(var j = 0; j < n; j++){
				console.log(i, j);
			}
		}
	}

console log will run n^2 times. If n=5 there will be 25 write lines

Big O of n^2 O(n^2) -- f(n) is quadratic.

## Constants and Small terms don't matter

* O(n + 10) = 0(n)
* O(1000n + 50) = O(n)
* O(n^2 + 5n + 8) = O(n^2)

## Constant Execution Time

* Variable declarations
* Variable assignment is constant
* Arithmetic operation are constant -- addition or multiplication take the pc the same amount of time
* Comparison statements
* Accessing elements in an array (by index) or object (by key) is constant
* Calling functions/methods
* Returning values

## Performance Classification

* Constant O(1)
* Logarithm O(log(n))
* Linear O(n)
* n-log-n O(n log(n))
* Quadratic O(n^2)
* Cubic O(^3)
* Exponential O(2^n)

## Space Complexity Rules of Thumb

* Most primitives (booleans, numbers, undefined, null) are constant space
* Strings require O(n) space (where n is the string length)
* Reference types are generally O(n), where n is the length (for arrays) or the number of keys (for objects)

## example space complexity function

	function sum(arr) {
		let total = 0;
		for(let i = 0; i < arr.length; i++) {
			total += arr[i];
		}
		return total;
	}

The above function only has two primitive variables (total and i) thus the Big O for space complexity is O(1) always the same no matter the size of the input.
don't forget we exclude the input variable

	function double(arr) {
		let newArr = [];
		for(let i = 0; i < arr.length; i++) {
			newArr.push(2*arr[i]);
		}
		return newArr;
	}

as arr grows newArr grows proportionally space complexity is O(n)

## log is inverse operation of exponents

log2(value) = exponent  =>  2^exponent = value

some algorthims have log complexity

* searching algorithms
* sorting algorithms
* recursive algorithms have log space complexity

## Recap

* To analyze the performance of an algorithm, we use Big O Notation
* Big O Notation can give us a high level understanding of the time or space complexity of an algorithm
* Big O Notation doesn't care about percision, only about general trends (linear, quadratic constant)
* The time or space complexity depends only on the algorthim, not the hardware used to run the algorithm

