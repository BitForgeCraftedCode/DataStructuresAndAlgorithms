# Performance of built in Arrrays and Objects -- JavaScript

## Objects -- unordered key value pairs

	let instructor = {
		firstName: "Kelly",
		isInstructor: true,
		favoriteNumbers: [1,2,3,4]
	}

## use objects when

* you don't need order
* you need fast access/insertion and removal

## Big O of Objects

* Insertion - O(1)
* Removal - O(1)
* Searching - O(n) -- for example checking if 5 is a favorite number
* Access - O(1)

## Big O of Object Methods

* Object.keys - O(n)
* Object.values - O(n)
* Object.entries - O(n)
* hasOwnProperty - O(1)

## Arrays -- ordered lists

	let names = ["drew", "katie", "eric"];
	let values = [ture, {}, 2, "wow JS arrays can accept differet types of data"];

## when to use arrays

* when you need order 
* when you need fast access/insertion and removal

## Big O of arrays

* Insertion - **it depends...**
* Removal - **it depends...**
* Searching - O(n)
* Access - O(1)

## Insert and removal from array

Array.push() is O(1) -- just adding to the end 

Inserting to the beginning of an array is O(n) because the indices are now off and have to be moved

Same for removing from the beginning -- O(n) you need to re-index

`push()` and `pop()` always faster than `shift()` and `unshift()`


## Big O of array operations

* push - O(1)
* pop - O(1)
* shift - O(n)
* unshift - O(n)
* concat - O(n)
* slice - O(n)
* splice - O(n)
* sort - O(nlogN)
* forEach/map/filter/reduce/etc. - O(n)


