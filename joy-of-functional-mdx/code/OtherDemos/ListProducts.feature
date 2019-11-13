Feature: ListProducts
	As a vending machine administrator
	I want to understand the products in my machine
	So that I'm not clueless

Scenario: Product Count
	Given I have the following products:
	| Name         | Cost |
	| Pepsi        | 2.00 |
	| Mountain Dew | 2.50 |
	And I am at the vending machine with the products
	When I get the product count
	Then the product count should be 2

Scenario: Product Names
	Given I have the following products:
	| Name         | Cost |
	| Pepsi        | 2.00 |
	| Mountain Dew | 2.50 |
	And I am at the vending machine with the products
	When I get the current products
	Then the products should include Pepsi
		And the products should include Mountain Dew
		And the products should not include Coke
